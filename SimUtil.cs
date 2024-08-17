using UnityEngine;

public class SimUtil
{
    private static GameObject player = null;
    private static GameObject world = null;
    public static GameObject GetPlayer()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        return player;
    }
    public static GameObject GetWorld()
    {
        if (world == null) world = GameObject.FindGameObjectWithTag("Ground");

        return world;
    }
}