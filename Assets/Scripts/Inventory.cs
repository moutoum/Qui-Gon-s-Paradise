using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int opals = 0;
    public int sapphires = 0;
    public int keys = 0;
    
    public void AddOpals(int amount)
    {
        opals += amount;
    }

    public bool UseOpal()
    {
        if (opals <= 0) return false;
        opals -= 1;
        return true;
    }

    public void AddSapphires(int amount)
    {
        sapphires += amount;
    }

    public bool UseSapphire()
    {
        if (sapphires <= 0) return false;
        sapphires -= 1;
        return true;
    }

    public void AddKey()
    {
        keys += 1;
    }

    public bool UseKey()
    {
        if (keys <= 0) return false;
        keys -= 1;
        return true;
    }
}
