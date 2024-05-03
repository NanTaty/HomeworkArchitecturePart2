using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "BonusConfigs", fileName = "BonusConfig")]
public class BonusConfig : ScriptableObject
{
    [SerializeField] private StrengthModificator strengthModificator;
    [SerializeField] private DexterityModificator dexterityModificator;
    [SerializeField] private IntelligenceModificator intelligenceModificator;

    public StrengthModificator StrengthModificator => strengthModificator;
    public DexterityModificator DexterityModificator => dexterityModificator;
    public IntelligenceModificator IntelligenceModificator => intelligenceModificator;

    private void OnValidate()
    {
        strengthModificator.OnValidate();
        dexterityModificator.OnValidate();
        intelligenceModificator.OnValidate();
    }
}
