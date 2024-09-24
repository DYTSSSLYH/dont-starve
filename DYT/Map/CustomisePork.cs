namespace DYT.Map
{
    public class CustomisePork : Customise
    {
        private static Customise INSTANCE;
        
        public static Customise Instance()
        {
            if (INSTANCE != null) return INSTANCE;

            INSTANCE = new CustomisePork();
            return INSTANCE;
        }
    }
}