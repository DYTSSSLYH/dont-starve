public class EmitterManager
{
    public class Emitters
    {
        public object limitedLifetimes = new object();
        public object infiniteLifetimes = new object();
    }

    public static Emitters awakeEmitters = new Emitters();
    public static Emitters sleepingEmitters = new Emitters();
}