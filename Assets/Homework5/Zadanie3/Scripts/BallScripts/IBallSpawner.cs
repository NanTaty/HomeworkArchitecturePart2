using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallSpawner
{
    event Action<Ball> OnBallSpawned;

    event Action OnFinishedSpawn;

    void StartSpawn();
}
