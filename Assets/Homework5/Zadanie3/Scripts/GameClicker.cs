using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameClicker : ITickable, IDisposable
{
    private Camera _camera;
    private bool _canClick = false;

    private IBallSpawner _ballSpawner;
    private VictoryCondition _victoryCondition;

    public GameClicker(IBallSpawner ballSpawner, VictoryCondition victoryCondition)
    {
        _camera = Camera.main;
        _ballSpawner = ballSpawner;
        _victoryCondition = victoryCondition;
        
        _ballSpawner.OnFinishedSpawn += BallSpawner_OnFinishedSpawn;
        _victoryCondition.OnFinished += VictoryCondition_OnFinished;
    }
    
    public void Dispose()
    {
        _ballSpawner.OnFinishedSpawn -= BallSpawner_OnFinishedSpawn;
        _victoryCondition.OnFinished -= VictoryCondition_OnFinished;
    }

    private void VictoryCondition_OnFinished()
    {
        _canClick = false;
    }

    private void BallSpawner_OnFinishedSpawn()
    {
        _canClick = true;
    }

    public void Tick()
    {
        
        if (_canClick == false)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                if (hit.collider.TryGetComponent(out IClickable ball))
                {
                    ball.Click();
                }
            }
        }
    }

    
}
