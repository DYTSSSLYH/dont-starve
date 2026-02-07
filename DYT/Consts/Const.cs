using System;

namespace DYT.Consts
{
    public class Const
    {
        public const int
            RESOLUTION_X = 1280,
            RESOLUTION_Y = 720;
        
        public const int ANCHOR_MIDDLE = 0,
            ANCHOR_LEFT = 1,
            ANCHOR_RIGHT = 2,
            ANCHOR_TOP = 1,
            ANCHOR_BOTTOM = 2;

        public enum ScaleMode
        {
            SCALEMODE_NONE = 0,
            SCALEMODE_FILLSCREEN = 1,
            SCALEMODE_PROPORTIONAL = 2,
            SCALEMODE_FIXEDPROPORTIONAL = 3,
            SCALEMODE_FIXEDSCREEN_NONDYNAMIC = 4 
        }

        public const int SCALEMODE_NONE = 0,
            SCALEMODE_FILLSCREEN = 1,
            SCALEMODE_PROPORTIONAL = 2,
            SCALEMODE_FIXEDPROPORTIONAL = 3,
            SCALEMODE_FIXEDSCREEN_NONDYNAMIC = 4;
    }
}