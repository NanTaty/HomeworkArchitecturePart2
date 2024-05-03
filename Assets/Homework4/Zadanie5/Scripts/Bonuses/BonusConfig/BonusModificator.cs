using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BonusModificator
{
    [SerializeField] private int strengthAddition;
    [SerializeField] private int dexterityAddition;
    [SerializeField] private int intelligenceAddition;

    public int StrengthAddition => strengthAddition;
    public int DexterityAddition => dexterityAddition;
    public int IntelligenceAddition => intelligenceAddition;

    public void OnValidate()
    {
        if (strengthAddition < 0)
        {
            strengthAddition = 0;
        }

        if (dexterityAddition < 0)
        {
            dexterityAddition = 0;
        }

        if (intelligenceAddition < 0)
        {
            intelligenceAddition = 0;
        }
    }
}
