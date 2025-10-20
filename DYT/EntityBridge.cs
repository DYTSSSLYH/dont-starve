using System.Collections.Generic;
using UnityEngine;

namespace DYT
{
    public class EntityBridge
    {
        public GameObject gameObject;
        HashSet<string> tags = new HashSet<string>();

        // 记录睡眠状态，供后续真实实现使用（最小有意义实现）
        private bool _canSleep = true;

        public EntityBridge()
        {
            gameObject = new GameObject();
        }

        public int GetGUID()
        {
            return gameObject.GetInstanceID();
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
            if (gameObject.transform == null)
            {
                gameObject.AddComponent<Transform>();
            }
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

        // 下列方法返回最小 stub，避免 Lua 要求的字段为 nil
        public SplatManagerBridge AddSplatManager()
        {
            return new SplatManagerBridge();
        }

        public ShadowManagerBridge AddShadowManager()
        {
            return new ShadowManagerBridge();
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
            return new FontManagerBridge();
        }

        public InteriorManagerBridge AddInteriorManager()
        {
            return new InteriorManagerBridge();
        }

        public MapLayerManagerBridge AddMapLayerManager()
        {
            return new MapLayerManagerBridge();
        }
        public class SplatManagerBridge { }
        public class ShadowManagerBridge { }
        public class RoadManagerBridge { }
        public class EnvelopeManagerBridge { }
        public class PostProcessorBridge { }
        public class FontManagerBridge { }
        public class InteriorManagerBridge { }
        public class MapLayerManagerBridge { }
    }
}