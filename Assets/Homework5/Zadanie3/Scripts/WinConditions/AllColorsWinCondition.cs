using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllColorsWinCondition : VictoryCondition
{
    private int _count;
    
    public AllColorsWinCondition(IBallList ballList, IBallSpawner ballSpawner) : base(ballList, ballSpawner)
    {
    }

    protected override void BallSpawnerOnFinishedSpawn()
    {
        base.BallSpawnerOnFinishedSpawn();
        _count = Balls.Count;
        Debug.Log("Для победы надо лопнуть все шары");
    }

    protected override void Ball_OnBallClicked(BallType ballType)
    {
        if (--_count != 0)
        {
            return;
        }
        
        Finish();
    }

    
}
