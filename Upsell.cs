using System;
using DYT;

public class Upsell
{
    public static bool DEMO_QUITTING = false;

    public static bool IsGamePurchased()
    {
        return MainFunctions.Purchases != null && MainFunctions.Purchases.Contains("GAME");
    }
    
    public static void UpdateGamePurchasedState(Action<bool> complete_callback)
    {
        complete_callback?.Invoke(IsGamePurchased());
    }
}