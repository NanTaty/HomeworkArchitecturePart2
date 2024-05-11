using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkRace : IStatProvider
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Intelligence { get; }

    public OrkRace(Stats statProvider)
    {
        Strength = statProvider.Strength;
        Dexterity = statProvider.Dexterity;
        Intelligence = statProvider.Intelligence;
    }
}
