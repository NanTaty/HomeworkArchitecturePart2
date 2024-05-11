using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallListManager : IBallList, IDisposable
{
    private List<Ball> _ballList;

    public List<Ball> BallList => _ballList;

    private IBallSpawner _ballSpawner;

    public BallListManager(IBallSpawner ballSpawner)
    {
        _ballList = new List<Ball>();
        _ballSpawner = ballSpawner;
        
        _ballSpawner.OnBallSpawned += BallSpawner_OnBallSpawned;
    }

    private void BallSpawner_OnBallSpawned(Ball ball)
    {
        AddBall(ball);
    }

    public void AddBall(Ball ball) => _ballList.Add(ball);

    public void Remove(Ball ball) => _ballList.Remove(ball);

    public void ClearList() => _ballList.Clear();

    public void Dispose()
    {
        _ballSpawner.OnBallSpawned -= BallSpawner_OnBallSpawned;
    }
}
