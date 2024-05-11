using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRace : IStatProvider
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Intelligence { get; }

    public HumanRace(Stats statProvider)
    {
        Strength = statProvider.Strength;
        Dexterity = statProvider.Dexterity;
        Intelligence = statProvider.Intelligence;
    }
}
