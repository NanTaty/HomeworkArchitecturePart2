using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Spawn Weight Config", fileName = "Spawn Weight config")]
public class SpawnerWeightConfig : ScriptableObject
{
    [SerializeField, Range(0, 1000)] private int _maxWeight;
    [SerializeField, Range(0, 100)] private int _orcWeight;
    [SerializeField, Range(0, 100)] private int _humanWeight;
    [SerializeField, Range(0, 100)] private int _elfWeight;
    [SerializeField, Range(0, 100)] private int _robotWeight;

    public int MaxWeight => _maxWeight;
    public int OrcWeight => _orcWeight;
    public int HumanWeight => _humanWeight;
    public int ElfWeight => _elfWeight;
    public int RobotWeight => _robotWeight;
}
