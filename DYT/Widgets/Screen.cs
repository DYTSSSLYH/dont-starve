namespace DYT.Widgets
{
    public class Screen : Widget
    {
        private object handlers;
        
        protected Widget default_focus;

        public Screen Init()
        {
            base.Init();
            handlers = new object();
            return this;
        }
        
        public void OnDestroy()
        {
            Kill();
        }
        
        public virtual void OnUpdate(float dt)
        {
        }
        
        public void OnBecomeInactive(){}
        
        public void OnBecomeActive(){}

        public bool SetDefaultFocus()
        {
            if (default_focus != null)
            {
                default_focus.SetFocus();
                return true;
            }

            return false;
        }
    }
}