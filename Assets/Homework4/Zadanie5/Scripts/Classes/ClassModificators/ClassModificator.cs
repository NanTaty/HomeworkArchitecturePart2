using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClassModificator
{
    [SerializeField] private int strengthMultiplier;
    [SerializeField] private int dexterityMultiplier;
    [SerializeField] private int intelligenceMultiplier;

    public int StrengthMultiplier => strengthMultiplier;
    public int DexterityMultiplier => dexterityMultiplier;
    public int IntelligenceMultiplier => intelligenceMultiplier;

    public void OnValidate()
    {
        if (strengthMultiplier <= 0)
        {
            strengthMultiplier = 1;
        }

        if (dexterityMultiplier <= 0)
        {
            dexterityMultiplier = 1;
        }

        if (intelligenceMultiplier <= 0)
        {
            intelligenceMultiplier = 1;
        }
    }
}
