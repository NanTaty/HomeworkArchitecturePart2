using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMage : Orc, IMage
{

    public void CastSpell()
    {
        Debug.Log("Cast orc spell");
    }
}
