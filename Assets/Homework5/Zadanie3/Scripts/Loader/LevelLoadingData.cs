using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadingData
{
    private GameType _gameType;

    public GameType GameType => _gameType;

    public LevelLoadingData(GameType gameType)
    {
        _gameType = gameType;
    }

}
