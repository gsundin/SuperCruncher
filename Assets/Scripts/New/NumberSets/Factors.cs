using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factors : NumberSet
{
    public static bool Is(int factor, int multiple)
    {
        if (factor % multiple == 0) return true;
        else return false;
    }
}
