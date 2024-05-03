using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitSpawner : MonoBehaviour, IFactory
{
    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private float spawnTime;

    [SerializeField] private UnitAbstractFactory _currentSpawnFactory;
    
    private Coroutine _spawn;
    public UnitAbstractFactory CurrentFactory => _currentSpawnFactory;

    public void StartWork()
    {
        StopWork();
        
        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
        {
            StopCoroutine(_spawn);
        }
    }
    
    public void SetFactory(UnitAbstractFactory factory)
    {
        _currentSpawnFactory = factory;
        Debug.Log(GetType() + " switched to " + _currentSpawnFactory.name);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            ClassType classType = (ClassType)Random.Range(0, Enum.GetValues(typeof(ClassType)).Length);
            Unit unit = _currentSpawnFactory.Get(classType);
            unit.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    
}
