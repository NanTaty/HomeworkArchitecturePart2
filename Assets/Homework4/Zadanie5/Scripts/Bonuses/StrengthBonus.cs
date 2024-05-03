using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBonus : BonusDecorator
{
    private StrengthModificator StrengthModificator => BonusConfig.StrengthModificator;
    
    public StrengthBonus(IStatProvider statProvider, BonusConfig bonusConfig) : base(statProvider, bonusConfig)
    {
    }

    protected override void ModifyStat()
    {
        Strength += StrengthModificator.StrengthAddition;
    }
}
