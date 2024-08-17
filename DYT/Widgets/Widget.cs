using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DYT.Widgets
{
    [RequireComponent(typeof(EntityScript))]
    public class Widget : MonoBehaviour
    {
        public Func<string> GetHelpText { get; private set; }
        public Action DoFocusHookups { get; private set; }
        
        private List<Widget> children;
        protected EntityScript inst;
        private bool shown;
        protected bool focus;
        protected bool focus_target;
        private object[] focus_flow;
        private List<List<object>> focus_flow_args;

        private Widget parent;
        private Widget focus_forward;
        private Widget next_in_tab_order;
        
        public Widget Init()
        {
            children = new List<Widget>();
            inst = GetComponent<EntityScript>().Init();
            
            inst.AddTag("widget");
            inst.AddTag("UI");
            
            inst.AddComponent("uianim", GetComponent<UIAnim>());

            enabled = true;
            shown = true;
            focus = false;
            focus_target = false;

            focus_flow = new object[4];
            focus_flow_args = new List<List<object>>{new(), new(), new(), new()};
            
            return this;
        }
        
        
        public void MoveToBack(){}
        
        public void MoveToFront(){}
        
        public bool OnFocusMove(int dir, bool down)
        {
            if (!focus) return false;
            
            foreach (Widget child in children)
            {
                if (child.focus && child.OnFocusMove(dir, down)) return true;
            }

            if (down && focus_flow[dir] != null)
            {
                object dest = focus_flow[dir];
                if (dest != null && dest.GetType() == typeof(Action))
                {
                    dest.GetType().GetMethod("Invoke").Invoke(this, null);
                }

                Widget destWidget = (Widget)dest;
                // Can we pass the focus down the chain if we are disabled/hidden?
                if (dest != null && destWidget.IsVisible() && destWidget.enabled)
                {
                    if (focus_flow_args[dir].Count > 0) SetFocus();
                    else SetFocus();

                    return true;
                }
            }
            
            return false;
        }

        public bool IsVisible()
        {
            if (!shown) return false;

            if (parent != null) return parent.IsVisible();

            return true;
        }

        public bool OnRawKey(object key, object down)
        {
            if (EventSystem.current.currentSelectedGameObject != gameObject) return false;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (EventSystem.current.currentSelectedGameObject == child.gameObject
                    || child.GetComponent<Widget>().OnRawKey(key, down))
                {
                    return true;
                }
            }

            return false;
        }

        public bool OnTextInput(string text)
        {
            if (EventSystem.current.currentSelectedGameObject != gameObject) return false;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (EventSystem.current.currentSelectedGameObject == child.gameObject
                    || child.GetComponent<Widget>().OnTextInput(text))
                {
                    return true;
                }
            }

            return false;
        }

        public bool OnControl(int control, bool down)
        {
            if (EventSystem.current.currentSelectedGameObject != gameObject) return false;
            
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (EventSystem.current.currentSelectedGameObject == child.gameObject
                    || child.GetComponent<Widget>().OnControl(control, down))
                {
                    return true;
                }
            }

            return false;
        }


        public virtual void Enable()
        {
            enabled = true;
            OnEnable();
        }

        public virtual void Disable()
        {
            enabled = false;
            OnDisable();
        }

        public void OnEnable(){}

        public void OnDisable(){}
        
        public void RemoveChild(Widget child)
        {
            if (child == null) return;

            children.Remove(child);
            child.parent = null;
            child.transform.SetParent(null);
        }
        
        public void KillAllChildren()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Widget child = transform.GetChild(i).GetComponent<Widget>();
                RemoveChild(child);
                child.Kill();
            }
        }
        
        
        public Widget AddChild(Widget child)
        {
            if (child.parent != null) child.parent.children.Remove(child);
            
            children.Add(child);
            child.parent = this;
            child.transform.SetParent(transform);
            return child;
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
            shown = false;
            OnHide();
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            shown = true;
            OnShow();
        }

        public void Kill()
        {
            StopUpdating();
        }

        public void SetPosition(Vector3 pos)
        {
            RectTransform rectTransform = (RectTransform)transform;
            rectTransform.anchoredPosition3D = pos;
        }
        public void SetPosition(float x, float y, float z = 0)
        {
            SetPosition(new Vector3(x, y, z));
        }
        
        
        public void SetScale(Vector3 pos)
        {
            RectTransform rectTransform = (RectTransform)transform;
            rectTransform.localScale = pos;
        }
        public void SetScale(float x, float? y = null, float? z = null)
        {
            SetScale(new Vector3(x, y.GetValueOrDefault(x), z.GetValueOrDefault(x)));
        }
        
        public void OnShow(){}
        
        public void OnHide(){}
        
        public void StartUpdating()
        {
            Main.TheFrontEnd.StartUpdatingWidget(this);
        }
        
        public void StopUpdating()
        {
            Main.TheFrontEnd.StopUpdatingWidget(this);
        }

        #region focus management
        
        public virtual void OnGainFocus(){}
        
        public virtual void OnLoseFocus(){}

        public void SetFocusChangeDir(int dir, Widget widget, params object[] objectArray)
        {
            if (focus_flow[0] == null) next_in_tab_order = widget;

            focus_flow[dir] = widget;

            if (objectArray.Length > 0) focus_flow_args[dir] = new List<object>(objectArray);
        }
        
        public Widget GetDeepestFocus()
        {
            if (!focus) return null;

            foreach (Widget child in children)
            {
                if (child.focus) return child;
            }

            return this;
        }

        public void ClearFocus()
        {
            if (!focus) return;

            focus = false;
            OnLoseFocus();
            foreach (Widget child in children)
            {
                if (child.focus) child.ClearFocus();
            }
        }

        public void SetFocusFromChild(Widget from_child)
        {
            foreach (Widget child in children)
            {
                if (child != from_child && child.focus) child.ClearFocus();
            }

            if (!focus)
            {
                focus = true;
                OnGainFocus();
                
                if (parent) parent.SetFocusFromChild(this);
            }
        }

        /// <summary>
        /// 主要作用为调用 OnGainFocus()
        /// </summary>
        public void SetFocus()
        {
            if (focus_forward)
            {
                focus_forward.SetFocus();
                return;
            }

            if (!focus)
            {
                focus = true;
                
                OnGainFocus();
                
                if (parent) parent.SetFocusFromChild(this);
            }
            
            foreach (Widget child in children) child.ClearFocus();
        }

        #endregion
        
        

        public virtual void Awake()
        {
        }

        public virtual void Start()
        {
        }
    }
}