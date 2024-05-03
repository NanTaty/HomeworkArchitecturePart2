using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private RaceConfig raceConfig;
    [SerializeField] private ClassConfig classConfig;
    [SerializeField] private BonusConfig bonusConfig;

    private void Awake()
    {
        playerStats.Initialize(new IntelligenceBonus(new MageClass(new ElfRace(raceConfig.ElfRaceStats), classConfig), bonusConfig));
        Debug.Log("Strength: " + playerStats.Strength + " Dexterity: " + playerStats.Dexterity + " Intelligence: " + playerStats.Intelligence);
    }
}
