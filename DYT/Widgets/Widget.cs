using System.Collections.Generic;
using UnityEngine;

namespace DYT.Widgets
{
    public class Widget
    {
        #region 构造器相关属性
        public List<Widget> children;
        public object callbacks;
        public string name;
        public EntityScript inst;
        public bool enabled;
        public bool shown;
        public bool focus;
        public bool focus_target;
        public object[] focus_flow;
        public List<List<object>> focus_flow_args;
        #endregion

        public Widget(string name)
        {
            children = new List<Widget>();
            callbacks = new object();
            this.name = name ?? "widget";
            inst = MainFunctions.CreateEntity();
            inst.widget = this;
            
            inst.AddTag("widget");
            inst.AddTag("UI");
            inst.entity.name = name;
            inst.entity.AddComponent<CanvasRenderer>();
            //self.inst.entity:CallPrefabConstructionComplete()
            
            inst.AddComponent("UIAnim");

            enabled = true;
            shown = true;
            focus = false;
            focus_target = false;

            focus_flow = new object[4];
            focus_flow_args = new List<List<object>>
            {
                new List<object>(), new List<object>(), new List<object>(), new List<object>()
            };
        }
    }
}