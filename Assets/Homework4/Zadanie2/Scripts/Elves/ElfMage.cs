using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfMage : Elf, IMage
{
    public void CastSpell()
    {
        Debug.Log("Cast elf spell");
    }
}
