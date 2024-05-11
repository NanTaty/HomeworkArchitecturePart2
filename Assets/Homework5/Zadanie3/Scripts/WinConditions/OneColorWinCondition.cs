using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OneColorWinCondition : VictoryCondition
{
    private BallType _winColor;
    private int _count;
    
    public OneColorWinCondition(IBallList ballList, IBallSpawner ballSpawner) : base(ballList, ballSpawner)
    {
    }

    protected override void BallSpawnerOnFinishedSpawn()
    {
        base.BallSpawnerOnFinishedSpawn();
        _winColor = Balls.First().BallType;
        _count = Balls.Count(ball => ball.BallType == _winColor);
        
        Debug.Log("Для победы надо собрать шары с цветом: " + _winColor);
    }

    protected override void Ball_OnBallClicked(BallType ballType)
    {
        if (ballType != _winColor)
            return;
        
        if (--_count != 0)
            return;
        
        Finish();
    }

    
}
