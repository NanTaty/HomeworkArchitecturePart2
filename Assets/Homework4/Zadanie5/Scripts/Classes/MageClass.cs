using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageClass : ClassDecorator
{
    private ClassModificator MageClassModificator => ClassConfig.MageClassModificator;
    public MageClass(IStatProvider statProvider, ClassConfig classConfig) : base(statProvider, classConfig)
    {
        
    }

    protected override void ModifyStat()
    {
        Intelligence *= MageClassModificator.IntelligenceMultiplier;
    }
}
