using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VictoryCondition : IDisposable
{
    protected IReadOnlyCollection<IBall> Balls;
    private readonly IBallList _ballList;
    private readonly IBallSpawner _ballSpawner;

    public event Action OnFinished;

    protected VictoryCondition(IBallList ballList, IBallSpawner ballSpawner)
    {
        _ballList = ballList;
        _ballSpawner = ballSpawner;
        
        _ballSpawner.OnFinishedSpawn += BallSpawnerOnFinishedSpawn;
    }

    protected virtual void BallSpawnerOnFinishedSpawn()
    {
        Balls = _ballList.BallList;
        foreach (var ball in Balls)
        {
            ball.OnBallClicked += Ball_OnBallClicked;
        }
    }

    protected abstract void Ball_OnBallClicked(BallType ballType);

    protected void Finish()
    {
        OnFinished?.Invoke();

        foreach (var ball in Balls)
        {
            ball.OnBallClicked -= Ball_OnBallClicked;
            ball.Deactivate();
        }
        Debug.Log("Win!");
    }

    public void Dispose()
    {
        _ballSpawner.OnFinishedSpawn -= BallSpawnerOnFinishedSpawn;
    }
}
