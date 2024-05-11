using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameMediator : IDisposable
{
    private GameOverPanel _gameOverPanel;
    private IBallSpawner _ballSpawner;
    private BallListManager _ballListManager;
    private VictoryCondition _victoryCondition;
    private SceneLoader _sceneLoader;

    public BallGameMediator(GameOverPanel gameOverPanel, IBallSpawner ballSpawner, BallListManager ballListManager, VictoryCondition victoryCondition, SceneLoader sceneLoader)
    {
        _gameOverPanel = gameOverPanel;
        _ballSpawner = ballSpawner;
        _ballListManager = ballListManager;
        _victoryCondition = victoryCondition;
        _sceneLoader = sceneLoader;

        _gameOverPanel.OnRestartClick += GameOverPanel_OnRestartClick;
        _gameOverPanel.OnMenuBtnClick += GameOverPanel_OnMenuBtnClick;
        _victoryCondition.OnFinished += VictoryCondition_OnFinished;
    }

    private void VictoryCondition_OnFinished()
    {
        _gameOverPanel.Show();
    }

    public void Dispose()
    {
        _gameOverPanel.OnRestartClick -= GameOverPanel_OnRestartClick;
        _gameOverPanel.OnMenuBtnClick -= GameOverPanel_OnMenuBtnClick;
    }
    
    private void GameOverPanel_OnMenuBtnClick()
    {
        _sceneLoader.Load(SceneID.MainMenu);
    }

    private void GameOverPanel_OnRestartClick()
    {
        _ballListManager.ClearList();
        _ballSpawner.StartSpawn();
    }

    
}
