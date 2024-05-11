using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "BonusConfigs", fileName = "BonusConfig")]
public class BonusConfig : ScriptableObject
{
    [SerializeField] private BonusModificator strengthModificator;
    [SerializeField] private BonusModificator dexterityModificator;
    [SerializeField] private BonusModificator intelligenceModificator;

    public BonusModificator StrengthModificator => strengthModificator;
    public BonusModificator DexterityModificator => dexterityModificator;
    public BonusModificator IntelligenceModificator => intelligenceModificator;

    private void OnValidate()
    {
        strengthModificator.OnValidate();
        dexterityModificator.OnValidate();
        intelligenceModificator.OnValidate();
    }
}
