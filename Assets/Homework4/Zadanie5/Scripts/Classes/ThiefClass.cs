using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefClass : ClassDecorator
{
    private ClassModificator ThiefClassModificator => ClassConfig.ThiefClassModificator;
    
    public ThiefClass(IStatProvider statProvider, ClassConfig classConfig) : base(statProvider, classConfig)
    {
    }

    protected override void ModifyStat()
    {
        Dexterity *= ThiefClassModificator.DexterityMultiplier;
    }
}
