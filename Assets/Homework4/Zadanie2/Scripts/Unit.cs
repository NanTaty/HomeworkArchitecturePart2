using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(GetType());
    }
}
