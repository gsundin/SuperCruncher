using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for all prime number-related methods
public class Primes : NumberSet
{
    // Returns true if input is a prime number
    public static bool Is(int number)
    {
        if (number < 2)
            return false;
        if (number == 2)
            return true;
        if (number % 2 == 0)
            return false;
        for (int i = 3; i <= Mathf.Sqrt(number); i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
