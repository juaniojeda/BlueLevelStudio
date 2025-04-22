using System.Collections.Generic;
using UnityEngine;

public static class BallManager
{
    private static List<BallController> activeBalls = new List<BallController>();

    public static void RegisterBall(BallController ball)
    {
        if (!activeBalls.Contains(ball))
        {
            activeBalls.Add(ball);
        }
    }

    public static void UnregisterBall(BallController ball)
    {
        if (activeBalls.Contains(ball))
        {
            activeBalls.Remove(ball);
        }
    }

    public static List<BallController> GetBalls()
    {
        return activeBalls;
    }

    public static void ClearAllBalls()
    {
        activeBalls.Clear();
    }
}