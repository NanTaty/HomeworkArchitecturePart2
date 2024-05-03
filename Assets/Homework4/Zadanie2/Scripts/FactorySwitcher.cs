using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySwitcher : MonoBehaviour
{
    [SerializeField] private OrcFactory orcFactory;
    [SerializeField] private ElfFactory elfFactory;
    private List<IFactory> _factories;

    public void Initialize(List<UnitSpawner> spawners)
    {
        _factories = new List<IFactory>();

        for (int i = 0; i < spawners.Count; i++)
        {
            IFactory factory = spawners[i].GetComponent<IFactory>();
            _factories.Add(factory);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var factory in _factories)
            {
                if (factory.CurrentFactory == orcFactory)
                {
                    factory.SetFactory(elfFactory);
                }
                else
                {
                    factory.SetFactory(orcFactory);
                }
            }
        }
    }
}
