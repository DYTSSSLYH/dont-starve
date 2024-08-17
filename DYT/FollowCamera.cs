using DYT.Prefabs;
using UnityEngine;

namespace DYT
{
    public class FollowCamera
    {
        private GameObject inst;
        private GameObject target;
        private Vector3 currentpos;
        private int distance;
        private object time_since_zoom;
        private Vector3 targetpos;
        private Vector3 targetoffset;
        private int? headingtarget;
        private int fov;
        private int pangain;
        private int headinggain;
        private int distancegain;
        private int zoomstep;
        private int distancetarget;
        private int mindist;
        private int maxdist;
        private int mindistpitch;
        private int maxdistpitch;
        private bool paused;
        private object shake;
        private bool controllable;
        private bool cutscene;
        private int? heading;
        private float pitch;

        
        public FollowCamera(GameObject inst = null)
        {
            this.inst = inst;
            target = null;
            currentpos = Vector3.zero;
            distance = 30;
            SetDefault();
            Snap();
            time_since_zoom = null;
        }


        public void SetDefault()
        {
            targetpos = Vector3.zero;
            targetoffset = new Vector3(0, 1.5f, 0);

            if (!headingtarget.HasValue) headingtarget = 45;

            fov = 35;
            pangain = 4;
            headinggain = 20;
            distancegain = 1;

            zoomstep = 4;
            distancetarget = 30;

            mindist = 15;
            maxdist = 50; //40

            mindistpitch = 30;
            maxdistpitch = 60; //60
            paused = false;
            shake = null;
            controllable = true;
            cutscene = false;

            if (SimUtil.GetWorld() != null && SimUtil.GetWorld().GetComponent<World>().IsCave())
            {
                mindist = 15;
                maxdist = 35;
                mindistpitch = 25;
                maxdistpitch = 40;
                distancetarget = 25;
            }
            
            if (target != null) SetTarget(target);
        }

        public void SetTarget(GameObject inst)
        {
            target = inst;
            targetpos = target.transform.position;
        }

        public void Apply()
        {
            // dir
            float dx = -Mathf.Cos(pitch * Mathf.Deg2Rad) * Mathf.Cos(heading.GetValueOrDefault(0) * Mathf.Deg2Rad);
            float dy = -Mathf.Sin(pitch * Mathf.Deg2Rad);
            float dz = -Mathf.Cos(pitch * Mathf.Deg2Rad) * Mathf.Sin(heading.GetValueOrDefault(0) * Mathf.Deg2Rad);
            
            // pos
            float px = dx * (-distance) + currentpos.x;
            float py = dy * (-distance) + currentpos.y;
            float pz = dz * (-distance) + currentpos.z;
            
            TheSim.instance.SetCameraPos(px, py, pz);
            TheSim.instance.SetCameraDir(dx, dy, dz);
            TheSim.instance.SetCameraFOV(fov);
        }

        private float lerp(float lower, float upper, float t)
        {
            if (t > 1) t = 1;
            else if (t < 0) t = 0;

            return lower + (upper - lower) * t;
        }

        public void Snap()
        {
            if (target != null) targetpos = target.transform.position + targetoffset;
            else targetpos = targetoffset;

            currentpos = targetpos;
            heading = headingtarget;
            distance = distancetarget;

            float percent_d = (distance - mindist) / ((float)(maxdist - mindist));
            pitch = lerp(mindistpitch, maxdistpitch, percent_d);
            
            Apply();
        }
    }
}