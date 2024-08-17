using System.Collections.Generic;
using DYT.Tools;
using UnityEngine;

namespace DYT.Widgets
{
    public class LoadingWidget : Widget
    {
        private static string LOADER_ATLAS_FMT = "Images/bg_loading_{0}";
    
        private static void GetOneAtlasPerImage_tex(string atlas_fmt, string item, out string atlas, out string tex)
        {
            atlas = string.Format(atlas_fmt, item);
            tex = item;
        }

        public static Sprite GetLoaderAtlasAndTex(string item)
        {
            GetOneAtlasPerImage_tex(LOADER_ATLAS_FMT, item, out string atlas, out string tex);
            Sprite loadSprite = ResourcesTool.LoadSprite(atlas, tex);
            return loadSprite == null
                // No crash.
                ? ResourcesTool.LoadSprite("Images/bg_loading_loading_newhorizons", "loading_newhorizons")
                : loadSprite;
        }
    
    
    
        public bool is_enabled { get; set; }
    
    
        private Transform _rootClassic;
        private UnityEngine.UI.Image _image;
    
        private List<string> bg_loading_images = Constant.BG_LOADING_IMAGES.MAIN_GAME;
        private bool forceShowNextFrame;
        private string image_random;
        private UnityEngine.UI.Image active_image;
        private string cached_string;
        private int elipse_state;
        private float cached_fade_level;
        private float step_time;

    
    
        public void ShowNextFrame()
        {
            forceShowNextFrame = true;
        }

        public void SetEnabled(bool enabled)
        {
            is_enabled = enabled;

            if (enabled)
            {
                _rootClassic.gameObject.SetActive(true);
            
                Show();
                StartUpdating();
            }
            else
            {
                Hide();
                StopUpdating();
            }
        }


        public override void Awake()
        {
            base.Awake();
        
            _rootClassic = transform.Find("RootClassic");
            _image = _rootClassic.Find("Image").GetComponent<UnityEngine.UI.Image>();
        }

        public override void Start()
        {
            base.Start();
        
            foreach (List<string> images in Constant.BG_LOADING_IMAGES.DLCS) bg_loading_images.AddRange(images);
            forceShowNextFrame = false;
            is_enabled = false;
            image_random = Util.GetRandomItem(bg_loading_images);
        
            _image.sprite = GetLoaderAtlasAndTex(image_random);

            active_image = _image;

            cached_string = "";
            elipse_state = 0;
            cached_fade_level = 0.0f;
            step_time = MainFunctions.GetTime();
        }
    }
}