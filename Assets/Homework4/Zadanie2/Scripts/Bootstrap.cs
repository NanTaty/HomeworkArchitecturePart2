using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private List<UnitSpawner> spawners;
    [SerializeField] private FactorySwitcher factorySwitcher;

    private void Awake()
    {
        factorySwitcher.Initialize(spawners);
        InitializeSpawners();
    }

    private void InitializeSpawners()
    {
        foreach (var spawner in spawners)
        {
            spawner.StartWork();
        }
    }
}
