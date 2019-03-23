using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiples : NumberSet
{
    public static bool Is(int multiple, int factor)
    {
        if (factor % multiple == 0) return true;
        else return false;
    }
}
