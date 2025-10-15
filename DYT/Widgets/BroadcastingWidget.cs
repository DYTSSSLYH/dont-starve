namespace DYT.Widgets
{
    public class BroadcastingWidget : WidgetSelf
    {
        private bool initialized;

        private void Start()
        {
            initialized = false;
            
            StartUpdating();
        }
    }
}