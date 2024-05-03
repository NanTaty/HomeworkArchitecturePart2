using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfRace : IStatProvider
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Intelligence { get; }

    public ElfRace(ElfRaceStats statProvider)
    {
        Strength = statProvider.Strength;
        Dexterity = statProvider.Dexterity;
        Intelligence = statProvider.Intelligence;
    }
}
