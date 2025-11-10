using System;
using UnityEngine;

namespace DYT
{
    /// <summary>
    /// TheSystemServiceBridge
    /// 作用（推测自 Klei 原行为）：
    /// - 向引擎声明“当前处于阻塞/繁忙阶段”（如载入、IO、解压、初始化等），
    ///   在该阶段临时调整引擎参数以提升交互响应、降低不必要的渲染/同步开销。
    /// - 结束阻塞后恢复原有设置。
    ///
    /// 设计要点：
    /// - 不改动 Time.timeScale（避免影响游戏模拟）。
    /// - 提升后台加载优先级、关闭 vSync、下调目标帧率为 30（可按需修改）。
    /// - 通过事件让上层显示/隐藏加载指示 UI。
    ///
    /// Lua 注入示例（在任何 require 之前）：
    ///   luaEnv.Global.Set("TheSystemService", new DYT.TheSystemServiceBridge());
    /// </summary>
    public class TheSystemServiceBridge
    {
        // 当前是否处于“阻塞/繁忙”状态
        private bool _stalling;

        // 进入阻塞前保存的引擎关键设置，便于恢复
        private ThreadPriority _prevLoadingPriority = ThreadPriority.Normal;
        private int _prevVsync = -1;
        private int _prevTargetFrameRate = -1;

        /// <summary>
        /// 当阻塞状态变化时回调（true=进入阻塞，false=结束阻塞）
        /// 可在此事件中显示/隐藏转圈/遮罩等 UI
        /// </summary>
        public event Action<bool> OnStallingChanged;

        /// <summary>
        /// Lua 调用：TheSystemService:SetStalling(true/false)
        /// - true：进入阻塞阶段，临时调参以保证响应性
        /// - false：退出阻塞阶段，恢复原设置
        /// </summary>
        public void SetStalling(bool stalling)
        {
            if (_stalling == stalling)
                return;

            _stalling = stalling;

            if (stalling)
            {
                // 进入阻塞：保存当前设置并应用“阻塞模式”参数
                _prevLoadingPriority = Application.backgroundLoadingPriority;
                _prevVsync = QualitySettings.vSyncCount;
                _prevTargetFrameRate = Application.targetFrameRate;

                // 提升后台加载优先级（资源 IO/解压更快）
                Application.backgroundLoadingPriority = ThreadPriority.High;

                // 关闭垂直同步，减少与显示器刷新率同步带来的阻塞
                QualitySettings.vSyncCount = 0;

                // 下调目标帧率以降低 CPU/GPU 压力，同时保持 UI 基本流畅
                // 若之前无限制（-1）或过高（>30），则设为 30
                if (_prevTargetFrameRate <= 0 || _prevTargetFrameRate > 30)
                    Application.targetFrameRate = 30;

                // 可选：防止设备在长阻塞时自动休眠（如需）
                // Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            else
            {
                // 退出阻塞：恢复进入前的设置
                Application.backgroundLoadingPriority = _prevLoadingPriority;

                if (_prevVsync >= 0)
                    QualitySettings.vSyncCount = _prevVsync;

                Application.targetFrameRate = _prevTargetFrameRate;

                // 可选：恢复系统睡眠策略（如上面改了的话）
                // Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }

            // 通知上层（UI/逻辑）状态变化
            try
            {
                OnStallingChanged?.Invoke(_stalling);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[TheSystemServiceBridge] OnStallingChanged 回调异常: {e}");
            }

            Debug.LogWarning($"TheSystemService.cs -> SetStalling() -> stalling='{stalling}'");
        }

        /// <summary>
        /// 查询当前是否处于阻塞阶段
        /// </summary>
        public bool IsStalling() => _stalling;
    }
}