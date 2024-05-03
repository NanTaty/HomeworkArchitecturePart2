using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClassDecorator : IStatProvider
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }

    private readonly ClassConfig _classConfig;
    protected ClassConfig ClassConfig => _classConfig;

    public ClassDecorator(IStatProvider statProvider, ClassConfig classConfig)
    {
        Strength = statProvider.Strength;
        Dexterity = statProvider.Dexterity;
        Intelligence = statProvider.Intelligence;
        _classConfig = classConfig;
        
        ModifyStat();
    }

    protected abstract void ModifyStat();
    
}
