using System;
using System.Collections.Generic;
using XLua;

// 确保有这个 using

// 新建一个脚本文件：XLuaConfig.cs（类名随意，但建议这样）
namespace DYT.Bridges
{
    public static class XLuaConfig  // 必须 public static
    {
        // 说明：
        // - 把需要“Lua 调 C#”的类型放进 LuaCallCSharp 列表
        // - 把需要“C# 调 Lua”的委托/接口签名放进 CSharpCallLua 列表
        // - 修改后执行菜单 XLua/Generate Code
        
        // [LuaCallCSharp]
        // public static List<Type> LuaCallCSharp = new List<Type>
        // {
        //     // 你在 Lua 里直接访问到的类型
        //     typeof(GameLaunch),               // Lua: CS.DYT.GameLaunch.KleiloadText(...)
        //     typeof(TheSimBridge),             // Lua: TheSim:Method(...)
        //     typeof(EntityBridge),   // 新增：允许 Lua 调用 entity:SetCanSleep(...)
        //     typeof(TheSystemServiceBridge),   // Lua: TheSystemService:SetStalling(...)
        //     typeof(TheInputProxyBridge),      // Lua: TheInputProxy:...
        //
        //     // 委托类型：Lua 将直接调用该 C# 委托（如 walltime）
        //     typeof(Func<double>),
        // };

        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>
        {
            // 仅当你从 Lua 传函数进 C# 并由 C# 回调时才需要。
            // 示例：如果 TheSimBridge 有如下签名：
            // public delegate void PersistentStringCallback(bool success, string data);
            // public delegate void SimpleCallback(bool success);
            // 则把这些委托类型加入列表：
            typeof(PersistentStringCallback),
            // typeof(SimpleCallback),

            // 如果你用系统委托来收 Lua 回调（例如 Action<bool,string>），也需要列出来：
            // typeof(System.Action<bool, string>),
            // typeof(System.Action<bool>),
        };
    }
}