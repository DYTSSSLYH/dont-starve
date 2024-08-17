using System;
using DYT.Widgets;

namespace DYT.Screens
{
    public class MovieDialog : Screen
    {
        private Action cb;
        private bool do_fadeback;
        private Video video;
        private float end_delay;
        
        public MovieDialog Init(string movie_path, Action callback, bool do_fadeback)
        {
            base.Init();

            cb = callback;
            this.do_fadeback = do_fadeback;

            video = transform.Find("Video").GetComponent<Video>().Init();
            if (!string.IsNullOrWhiteSpace(movie_path)) video.Load(movie_path);

            end_delay = 2;

            if (video && video.IsDone()) MainFunctions.SetPause(true);
            
            return this;
        }
    }
}