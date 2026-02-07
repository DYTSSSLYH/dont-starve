using System.Collections.Generic;
using DYT.Bridges;
using DYT.Consts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XLua;

namespace DYT
{
    public class EntityBridge
    {
        private readonly GameObject _gameObject = new GameObject();
        HashSet<string> tags = new HashSet<string>();

        // 记录睡眠状态，供后续真实实现使用（最小有意义实现）
        private bool _canSleep = true;
        

        public int GetGUID()
        {
            return _gameObject.GetInstanceID();
        }
        
        public void SetName(string name)
        {
            _gameObject.name = name;
        }

        public void AddTag(string tag)
        {
            if (string.IsNullOrEmpty(tag)) return;
            tags.Add(tag);
        }

        public bool HasTag(string tag)
        {
            if (string.IsNullOrEmpty(tag)) return false;
            return tags.Contains(tag);
        }

        public void RemoveTag(string tag)
        {
            if (string.IsNullOrEmpty(tag)) return;
            tags.Remove(tag);
        }

        // Lua 会调用： entity:SetCanSleep(false)
        // 我们记录状态，避免 nil 调用；不要做无意义的复杂行为
        public void SetCanSleep(bool canSleep)
        {
            _canSleep = canSleep;
            // 有意义的行为可以在后续实现（例如控制某个组件启/停）
        }

        // Lua 调用： entity:AddTransform()
        // 最小实现：确保 GameObject 有 Transform（Unity 自动有），返回 void 避免额外类型注册问题
        public void AddTransform()
        {
            // Unity 的 GameObject 自带 Transform，保证不为 null
            if (_gameObject.transform == null)
            {
                _gameObject.AddComponent<Transform>();
            }
        }
        
        public void AddUITransform()
        {
            LuaTable ents = GameLaunch.LUA_ENV.Global.Get<LuaTable>("Ents");
            LuaTable inst = ents.Get<int, LuaTable>(GetGUID());
            
            _gameObject.transform.SetParent(GameLaunch.Instance.canvas);
            RectTransform rectTransform = _gameObject.AddComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = new Vector2(Const.RESOLUTION_X, Const.RESOLUTION_Y);
            
            UITransformBridge rectTransformBridge = new UITransformBridge(rectTransform, inst);
            
            inst.Set("UITransform", rectTransformBridge);
        }
        
        public void AddTextWidget()
        {
            TextMeshProUGUI textMeshProUGUI = _gameObject.AddComponent<TextMeshProUGUI>();
            TextWidgetBridge textWidgetBridge = new TextWidgetBridge(textMeshProUGUI);
            
            LuaTable ents = GameLaunch.LUA_ENV.Global.Get<LuaTable>("Ents");
            LuaTable entityScript = ents.Get<int, LuaTable>(GetGUID());
            
            entityScript.Set("TextWidget", textWidgetBridge);
        }
        
        public void Hide(bool hide)
        {
            _gameObject.SetActive(hide);
        }
        
        public void AddImageWidget()
        {
            Image image = _gameObject.AddComponent<Image>();
            ImageWidgetBridge imageWidgetBridge = new ImageWidgetBridge(image);
            
            LuaTable ents = GameLaunch.LUA_ENV.Global.Get<LuaTable>("Ents");
            LuaTable inst = ents.Get<int, LuaTable>(GetGUID());
            
            inst.Set("ImageWidget", imageWidgetBridge);
        }

        public SplatManagerBridge AddSplatManager()
        {
            return new SplatManagerBridge();
        }

        public ShadowManagerBridge AddShadowManager()
        {
            return _gameObject.AddComponent<ShadowManagerBridge>();
        }

        public RoadManagerBridge AddRoadManager()
        {
            return new RoadManagerBridge();
        }

        public EnvelopeManagerBridge AddEnvelopeManager()
        {
            return new EnvelopeManagerBridge();
        }

        public PostProcessorBridge AddPostProcessor()
        {
            return new PostProcessorBridge();
        }

        public FontManagerBridge AddFontManager()
        {
            return _gameObject.AddComponent<FontManagerBridge>();
        }

        public InteriorManagerBridge AddInteriorManager()
        {
            return new InteriorManagerBridge();
        }

        public MapLayerManagerBridge AddMapLayerManager()
        {
            return new MapLayerManagerBridge();
        }
        
        public void CallPrefabConstructionComplete()
        {
            Debug.LogWarning("EntityBridge.cs -> CallPrefabConstructionComplete()");
        }

        public void SetClickable(bool val)
        {
            LuaTable ents = GameLaunch.LUA_ENV.Global.Get<LuaTable>("Ents");
            LuaTable inst = ents.Get<int, LuaTable>(GetGUID());
            
            LuaTable widget = inst.Get<LuaTable>("widget");
            string widgetName = widget.Get<string>("name");
            
            Debug.LogWarning(
                $"EntityBridge.cs -> SetClickable() -> widgetName:【{widgetName}】, val:【{val}】"
            );
        }

        public void SetParent(EntityBridge entityBridge)
        {
            _gameObject.transform.SetParent(entityBridge._gameObject.transform);
        }
        
        public class SplatManagerBridge { }
        public class RoadManagerBridge { }
        public class EnvelopeManagerBridge { }
        public class InteriorManagerBridge { }
        public class MapLayerManagerBridge { }
    }
}