using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats : IStatProvider
{
    [SerializeField] private int _strength;
    [SerializeField] private int _dexterity;
    [SerializeField] private int _intelligence;

    public int Strength => _strength;
    public int Dexterity => _dexterity;
    public int Intelligence => _intelligence;

    public void OnValidate()
    {
        if (_strength <= 0)
        {
            _strength = 1;
        }

        if (_dexterity <= 0)
        {
            _dexterity = 1;
        }

        if (_intelligence <= 0)
        {
            _intelligence = 1;
        }
    }
}
