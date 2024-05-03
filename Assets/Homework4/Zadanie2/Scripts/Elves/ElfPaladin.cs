using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfPaladin : Elf, IPaladin
{
    public void Attack()
    {
        Debug.Log("Elf paladin attack");
    }
}
