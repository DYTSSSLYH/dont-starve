namespace DYT.Widgets
{
    public class BroadcastingWidget : Widget
    {
        private bool initialized;

        private void Start()
        {
            initialized = false;
            
            StartUpdating();
        }
    }
}