using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : ITickable
{
    private float _spawnCooldown;

    private List<Transform> _spawnPoints;

    private float _startSpawnCooldown;

    private bool isSpawnActive = false;

    private EnemyFactory _enemyFactory;

    public EnemySpawner(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    public void Initialize(List<Transform> spawnPoints, float spawnCooldown)
    {
        _spawnCooldown = spawnCooldown;
        _spawnPoints = spawnPoints;
        _startSpawnCooldown = _spawnCooldown;
        
        StartWork();
    }

    public void StartWork()
    {
        _spawnCooldown = _startSpawnCooldown;
        isSpawnActive = true;
    }

    public void StopWork()
    {
        isSpawnActive = false;
    }

    public void Tick()
    {
        if (isSpawnActive == false)
            return;

        _spawnCooldown -= Time.deltaTime;

        if (_spawnCooldown <= 0)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            _spawnCooldown = _startSpawnCooldown;
        }
    }
}
