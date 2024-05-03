using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Factories/OrcFactory", fileName = "OrcFactory")]
public class OrcFactory : UnitAbstractFactory
{
    [SerializeField] private Orc orcMage, orcPaladin;
    public override Unit Get(ClassType type)
    {
        Orc orcToSpawn = Instantiate(GetClass(type));
        return orcToSpawn;
    }

    private Orc GetClass(ClassType type)
    {
        switch (type)
        {
            case ClassType.Mage:
                return orcMage;
            case ClassType.Paladin:
                return orcPaladin;
            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
