// using System;
// using System.Collections.Generic;
// using DYT.Widgets;
// using UnityEngine;
// using UnityEngine.Assertions;
//
// namespace DYT
// {
//     public class EntityScript
//     {
//         #region 构造器相关属性
//         public GameObject entity;
//         public Dictionary<string, Component> components;
//         public int GUID;
//         public float spawntime;
//         public bool persists;
//         public bool inlimbo;
//         public string name;
//         public object data;
//         public object listeners;
//         public object updatecomponents;
//         public object inherentactions;
//         public object event_listeners;
//         public object event_listening;
//         public List<Periodic> pendingtasks;
//         public object children;
//         public int age;
//         public object ininterior;
//         #endregion
//
//         #region 显式定义属性
//         public static object StopUpdatingComponents = new object();
//         public static object nearsightednames = null;
//         
//         private object BehaviourTrees = new object();
//         private object StateGraphs = new object();
//         private Dictionary<string, Type> Components = new Dictionary<string, Type>();
//         private Dictionary<string, bool> nearsighted_key_blacklist = new Dictionary<string, bool>
//         {
//             ["NIL"] = true,
//             ["DARKNESS"] = true,
//             ["CHARLIE"] = true,
//             ["HUNGER"] = true,
//             ["COLD"] = true,
//             ["HOT"] = true,
//             ["SHENANIGANS"] = true,
//             ["RESURRECTION_PENALTY"] = true,
//             ["DROWNING"] = true,
//             ["BURNT"] = true,
//             ["UNKNOWN"] = true,
//             
//             ["WARBUCKS"] = true,
//             ["DEVTOOL"] = true,
//         };
//         #endregion
//
//         #region 隐式定义属性
//         public Widget widget;
//         #endregion
//
//         #region 自定义属性
//         public List<string> tagList = new List<string>();
//         #endregion
//         
//         public EntityScript(GameObject entity)
//         {
//             this.entity = entity;
//             components = new Dictionary<string, Component>();
//             GUID = entity.GetInstanceID();
//             spawntime = MainFunctions.GetTime();
//             persists = true;
//             inlimbo = false;
//             name = null;
//         
//             data = null;
//             listeners = null;
//             updatecomponents = null;
//             inherentactions = null;
//             event_listeners = null;
//             event_listening = null;
//             pendingtasks = null;
//             children = null;
//             age = 0;
//             ininterior = null;
//         }
//
//         
//         #region tag相关操作
//         public void AddTag(string tag)
//         {
//             tagList.Add(tag);
//         }
//         
//         public bool RemoveTag(string tag)
//         {
//             return tagList.Remove(tag);
//         }
//         
//         public bool HasTag(string tag)
//         {
//             return tagList.Contains(tag);
//         }
//         #endregion
//
//         #region component相关操作
//         private Type LoadComponent(string name)
//         {
//             if (!Components.ContainsKey(name)) Components[name] = Type.GetType($"DYT.Components.{name}");
//
//             return Components[name];
//         }
//
//         public void AddComponent(string name)
//         {
//             //-- assert(self.components[name] == nil, "component "..name.." already exists in prefab!")
//             if (components.ContainsKey(name))
//                 DebugPrint.print($"component {name} already exists in prefab!");
//             Type cmp = LoadComponent(name);
//             Assert.IsNotNull(cmp, $"component {name} does not exist!");
//
//             Component loadedcmp = (Component)Activator.CreateInstance(cmp, this);
//             components.Add(name, loadedcmp);
//             List<ActionParams> postInitFns = ModManager.GetPostInitFns("ComponentPostInit", name);
//             
//             foreach (ActionParams fn in postInitFns) fn.Invoke(loadedcmp, this);
//         }
//         #endregion
//     }
// }