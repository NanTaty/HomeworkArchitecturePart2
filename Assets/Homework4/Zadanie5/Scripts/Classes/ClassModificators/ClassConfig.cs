using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ClassConfigs", fileName = "ClassConfig")]
public class ClassConfig : ScriptableObject
{
    [SerializeField] private ClassModificator mageClassModificator;
    [SerializeField] private ClassModificator thiefClassModificator;
    [SerializeField] private ClassModificator warriorClassModificator;

    public ClassModificator MageClassModificator => mageClassModificator;
    public ClassModificator ThiefClassModificator => thiefClassModificator;
    public ClassModificator WarriorClassModificator => warriorClassModificator;

    private void OnValidate()
    {
        mageClassModificator.OnValidate();
        thiefClassModificator.OnValidate();
        warriorClassModificator.OnValidate();
    }
}
