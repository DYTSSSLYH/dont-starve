using DYT.Tools;
using UnityEngine;
using UnityEngine.Video;

namespace DYT.Widgets
{
    [RequireComponent(typeof(VideoPlayer))]
    public class Video : Widget
    {
        private VideoPlayer VideoWidget;
        private bool loopPointReached;
        
        public new Video Init()
        {
            base.Init();
            VideoWidget = GetComponent<VideoPlayer>();
            VideoWidget.loopPointReached += source => loopPointReached = true;
            return this;
        }


        public void Load(string filename)
        {
            VideoWidget.clip = ResourcesTool.Load<VideoClip>(filename);
        }

        public bool IsDone()
        {
            return loopPointReached;
        }
    }
}