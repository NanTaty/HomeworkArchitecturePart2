using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcPaladin : Orc, IPaladin
{

    public void Attack()
    {
        Debug.Log("Orc paladin attack");
    }
}
