using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Factories/ElfFactory", fileName = "ElfFactory")]
public class ElfFactory : UnitAbstractFactory
{
    [SerializeField] private Elf elfMage, elfPaladin;

    public override Unit Get(ClassType type)
    {
        Elf elfToSpawn = Instantiate(GetClass(type));
        return elfToSpawn;
    }

    private Elf GetClass(ClassType type)
    {
        switch (type)
        {
            case ClassType.Mage:
                return elfMage;
            case ClassType.Paladin:
                return elfPaladin;
            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
