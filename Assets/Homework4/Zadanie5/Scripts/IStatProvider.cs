using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatProvider
{
    int Strength { get; }
    int Dexterity { get; }
    int Intelligence { get; }
}
