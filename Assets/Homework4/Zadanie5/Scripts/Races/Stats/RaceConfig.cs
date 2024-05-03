using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "RaceSO", fileName = "Race")]
public class RaceConfig : ScriptableObject
{
    [SerializeField] private OrkRaceStats orkRaceStats;
    [SerializeField] private HumanRaceStats humanRaceStats;
    [SerializeField] private ElfRaceStats elfRaceStats;

    public OrkRaceStats OrkRaceStats => orkRaceStats;
    public HumanRaceStats HumanRaceStats => humanRaceStats;
    public ElfRaceStats ElfRaceStats => elfRaceStats;

    private void OnValidate()
    {
        orkRaceStats.OnValidate();
        humanRaceStats.OnValidate();
        elfRaceStats.OnValidate();
    }
}
