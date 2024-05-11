using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMediator : IDisposable
{
    private DefeatPanel _defeatPanel;
    private Level _level;

    public GameplayMediator(Level level, DefeatPanel defeatPanel)
    {
        _defeatPanel = defeatPanel;
        _level = level;
        _level.Defeat += OnLevelDefeat;
        _defeatPanel.OnRestartButtonClicked += DefeatPanel_OnRestartButtonClicked;
    }

    public void Dispose()
    {
        _level.Defeat -= OnLevelDefeat;
        _defeatPanel.OnRestartButtonClicked -= DefeatPanel_OnRestartButtonClicked;
    }

    private void OnLevelDefeat() => _defeatPanel.Show();

    private void DefeatPanel_OnRestartButtonClicked() => RestartLevel();

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }

    
}
