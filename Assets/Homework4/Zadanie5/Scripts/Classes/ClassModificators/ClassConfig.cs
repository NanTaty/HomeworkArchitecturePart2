using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ClassConfigs", fileName = "ClassConfig")]
public class ClassConfig : ScriptableObject
{
    [SerializeField] private MageClassModificator mageClassModificator;
    [SerializeField] private ThiefClassModificator thiefClassModificator;
    [SerializeField] private WarriorClassModificator warriorClassModificator;

    public MageClassModificator MageClassModificator => mageClassModificator;
    public ThiefClassModificator ThiefClassModificator => thiefClassModificator;
    public WarriorClassModificator WarriorClassModificator => warriorClassModificator;

    private void OnValidate()
    {
        mageClassModificator.OnValidate();
        thiefClassModificator.OnValidate();
        warriorClassModificator.OnValidate();
    }
}
