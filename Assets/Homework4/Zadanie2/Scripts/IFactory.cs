using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    UnitAbstractFactory CurrentFactory { get; }
    void SetFactory(UnitAbstractFactory factory);
}
