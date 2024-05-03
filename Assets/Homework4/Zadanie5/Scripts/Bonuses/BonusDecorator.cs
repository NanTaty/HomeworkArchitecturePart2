using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusDecorator : IStatProvider
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }

    private readonly BonusConfig _bonusConfig;
    protected BonusConfig BonusConfig => _bonusConfig;

    public BonusDecorator(IStatProvider statProvider, BonusConfig bonusConfig)
    {
        Strength = statProvider.Strength;
        Dexterity = statProvider.Dexterity;
        Intelligence = statProvider.Intelligence;
        _bonusConfig = bonusConfig;
        
        ModifyStat();
    }

    protected abstract void ModifyStat();

}
