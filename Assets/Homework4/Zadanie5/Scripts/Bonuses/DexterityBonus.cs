using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DexterityBonus : BonusDecorator
{
    private BonusModificator DexterityModificator => BonusConfig.DexterityModificator;
    
    public DexterityBonus(IStatProvider statProvider, BonusConfig bonusConfig) : base(statProvider, bonusConfig)
    {
    }

    protected override void ModifyStat()
    {
        Dexterity += DexterityModificator.DexterityAddition;
    }
}
