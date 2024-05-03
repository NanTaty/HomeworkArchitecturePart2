using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class UnitAbstractFactory : ScriptableObject
{
    public abstract Unit Get(ClassType type);
}
