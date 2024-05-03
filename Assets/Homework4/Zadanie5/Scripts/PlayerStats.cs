using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private IStatProvider _statProvider;
    
    private int _strength;
    private int _dexterity;
    private int _intelligence;
    
    public int Strength => _strength;
    public int Dexterity => _dexterity;
    public int Intelligence => _intelligence;
    
    public void Initialize(IStatProvider statProvider)
    {
        _strength = statProvider.Strength;
        _dexterity = statProvider.Dexterity;
        _intelligence = statProvider.Intelligence;
    }
}
