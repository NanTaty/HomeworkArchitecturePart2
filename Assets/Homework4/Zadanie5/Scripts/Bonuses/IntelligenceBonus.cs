using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligenceBonus : BonusDecorator
{
    private BonusModificator IntelligenceModificator => BonusConfig.IntelligenceModificator;
    
    public IntelligenceBonus(IStatProvider statProvider, BonusConfig bonusConfig) : base(statProvider, bonusConfig)
    {
    }

    protected override void ModifyStat()
    {
        Intelligence += IntelligenceModificator.IntelligenceAddition;
    }
}
