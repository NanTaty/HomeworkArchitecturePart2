using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "RaceSO", fileName = "Race")]
public class RaceConfig : ScriptableObject
{
    [SerializeField] private Stats orkRaceStats;
    [SerializeField] private Stats humanRaceStats;
    [SerializeField] private Stats elfRaceStats;

    public Stats OrkRaceStats => orkRaceStats;
    public Stats HumanRaceStats => humanRaceStats;
    public Stats ElfRaceStats => elfRaceStats;

    private void OnValidate()
    {
        orkRaceStats.OnValidate();
        humanRaceStats.OnValidate();
        elfRaceStats.OnValidate();
    }
}
