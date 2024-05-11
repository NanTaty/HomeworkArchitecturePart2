using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : ClassDecorator
{
    private ClassModificator WarriorClassModificator => ClassConfig.WarriorClassModificator;
    
    public WarriorClass(IStatProvider statProvider, ClassConfig classConfig) : base(statProvider, classConfig)
    {
    }

    protected override void ModifyStat()
    {
        Strength *= WarriorClassModificator.StrengthMultiplier;
    }
}
