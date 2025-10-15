using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using Unity.SharpZipLib.Utils;
using Unity.SharpZipLib.Zip;
using UnityEngine;
using UnityEngine.Networking;
using XLua;
using ZipFile = Unity.SharpZipLib.Zip.ZipFile;

namespace DYT
{
    public class GameLaunch : MonoBehaviour
    {
        [Header("UI 可选：拖一个 Slider 进来显示进度")]
        [SerializeField] UnityEngine.UI.Slider slider;

        public string RES_ZIP = "dont_starve_copy.zip";          // StreamingAssets 里的资源包
        static string FlagFile => $"{Application.persistentDataPath}/.unpacked";

        /* 公开事件：解压完成 / 启动完成 */
        public static event Action onUnpackDone;   // 可在这里切 UI
        public static event Action onLuaStartDone; // Lua 已 ready

        /* 单例供外部取 LuaEnv */
        public static LuaEnv luaEnv { get; private set; }

        private IEnumerator Start()
        {
            string flag = Path.Combine(Application.persistentDataPath, ".unpacked");
            if (!File.Exists(flag))
            {
                string tempZip = Path.Combine(Application.persistentDataPath, RES_ZIP);

                // 1. 把 StreamingAssets 里的大文件 **流式拷贝** 到可写目录
                yield return CopyStreamingAssetsToTemp();

                // 2. **分段解压** 临时文件
                yield return UnzipWithFileStream(tempZip, Application.persistentDataPath);

                // 3. 清理临时 zip
                File.Delete(tempZip);
                File.WriteAllText(flag, "1");

                Debug.Log(">>> 大 ZIP 本地解压完成");
            }

            StartLua();
        }
        
        /* 1. 流式拷贝（>2 GB 也安全） */
        IEnumerator CopyStreamingAssetsToTemp()
        {
            // Android 真机：jar:file:/// 路径，必须用 UnityWebRequest 读取
            using (var uwr = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, RES_ZIP)))
            {
                // **关键**：不下载到内存，直接写文件
                uwr.downloadHandler = new DownloadHandlerFile(Path.Combine(Application.persistentDataPath, RES_ZIP), false);
                uwr.SendWebRequest();

                while (!uwr.isDone)
                {
                    if (slider) slider.value = uwr.downloadProgress;
                    yield return null;
                }
                if (uwr.result != UnityWebRequest.Result.Success)
                    throw new Exception("拷贝失败: " + uwr.error);
            }
            Debug.Log(">>> 大文件已拷贝到临时目录");
        }

        /* 核心：FileStream + SharpZipLib 解压 */
        IEnumerator UnzipWithFileStream(string zipPath, string targetDir)
        {
            using (var fs   = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
            using (var zip  = new ZipFile(fs))        // SharpZipLib 入口
            {
                long totalBytes = 0;
                long doneBytes  = 0;

                // 先算总大小
                foreach (ZipEntry e in zip)
                    if (!e.IsDirectory) totalBytes += e.Size;

                foreach (ZipEntry entry in zip)
                {
                    if (entry.IsDirectory) continue;

                    string outPath = Path.Combine(targetDir, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    using (var zs = zip.GetInputStream(entry))   // 文件流读
                    using (var ds = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[100 * 1024 * 1024]; // 100 MB 缓冲区
                        int read;
                        while ((read = zs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ds.Write(buffer, 0, read);
                            doneBytes += read;

                            float p = (float)doneBytes / totalBytes;
                            if (slider) slider.value = p;
                            yield return null; // 每写一块就让出
                        }
                    }
                }
            }
            Debug.Log(">>> FileStream+SharpZipLib 解压完成 → " + targetDir);
        }

        /* 2. 启动 xLua 并设置路径 */
        void StartLua()
        {
            luaEnv = new LuaEnv();

            // 让 Lua 从 persistentDataPath 加载脚本
            luaEnv.AddLoader((ref string filepath) =>
            {
                filepath = filepath.Replace(".", "/") + ".lua";
                string full = Path.Combine(Application.persistentDataPath, "scripts", filepath);
                return File.Exists(full) ? File.ReadAllBytes(full) : null;
            });

            // 注入 C# 桥接类（示例）
            luaEnv.Global.Set("TheSim", typeof(TheSimBridge));
            luaEnv.Global.Set("DATA",  typeof(DataPath));

            // 启动主脚本
            luaEnv.DoString("require 'main'");

            onLuaStartDone?.Invoke();
            Debug.Log(">>> Lua 虚拟机启动完成");
        }

        void OnDestroy()
        {
            luaEnv?.Dispose();
            luaEnv = null;
        }
    }

    /* 供 Lua 调用的示例桥 */
    public static class DataPath
    {
        public static string Root => Application.persistentDataPath;
    }

    [XLua.LuaCallCSharp]
    public static class TheSimBridge
    {
        public static string LoadTexture(string relPath)
        {
            // 这里只是返回路径，真正解码可再包一层
            return Path.Combine(DataPath.Root, relPath);
        }
    }
}