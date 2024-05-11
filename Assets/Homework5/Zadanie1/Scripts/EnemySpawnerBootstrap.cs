using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerBootstrap : MonoBehaviour
{
    [SerializeField] private float spawnCooldown;
    [SerializeField] private List<Transform> spawnPoints;

    private EnemySpawner _enemySpawner;

    [Inject]
    private void Construct(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    private void Awake()
    {
        _enemySpawner.Initialize(spawnPoints, spawnCooldown);
    }
}
