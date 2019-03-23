using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSet
{
    private string[] ruleSets = new string[]
    {
        "primes",
        "multiples",
        "factors",
        "challenge"
        //equality
        //inequality
    };

    // Generates number set based on rule set
    private int[] Generate(int numberOfAnswers, int numberOfCorrectAnswers, int[] numberRange, string rule)
    {
        int[] set = new int[numberOfAnswers];

        // If mode is challenge, a random ruleset will be chosen
        if (rule == "challenge") { rule = ruleSets[Random.Range(0, ruleSets.Length - 1)]; }
        
        // Generate correct/incorrect answers per rule set
        int possibleAnswer;
        switch (rule)
        {
            case "primes":
                for (int i = 0; i < numberOfCorrectAnswers; i++)
                {
                    do { possibleAnswer = Random.Range(numberRange[0], numberRange[1]); }
                    while (!Primes.Is(possibleAnswer));
                    set[i] = possibleAnswer;
                }
                for (int i = numberOfCorrectAnswers; i < numberOfAnswers; i++)
                {
                    do { possibleAnswer = Random.Range(numberRange[0], numberRange[1]); }
                    while (Primes.Is(possibleAnswer));
                    set[i] = possibleAnswer;
                }
                break;

            case "multiples":
                int factor = Random.Range(0, 10);
                for (int i = 0; i < numberOfCorrectAnswers; i++)
                {
                    do { possibleAnswer = Random.Range(numberRange[0], numberRange[1]); }
                    while (!Multiples.Is(possibleAnswer, factor));
                    set[i] = possibleAnswer;
                }
                for (int i = numberOfCorrectAnswers; i < numberOfAnswers; i++)
                {
                    do { possibleAnswer = Random.Range(numberRange[0], numberRange[1]); }
                    while (Multiples.Is(possibleAnswer, factor));
                    set[i] = possibleAnswer;
                }
                break;

            case "factors":
                int multiple = Random.Range(0, 10);
                for (int i = 0; i < numberOfCorrectAnswers; i++)
                {
                    do { possibleAnswer = Random.Range(numberRange[0], numberRange[1]); }
                    while (!Multiples.Is(possibleAnswer, multiple));
                    set[i] = possibleAnswer;
                }
                for (int i = numberOfCorrectAnswers; i < numberOfAnswers; i++)
                {
                    do { possibleAnswer = Random.Range(numberRange[0], numberRange[1]); }
                    while (Multiples.Is(possibleAnswer, multiple));
                    set[i] = possibleAnswer;
                }
                break;
        }
        return set;
    }

    // Randomizes array order using Fisher-Yates algoritm
    private int[] Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            int temp = array[i];
            array[i] = array[r];
            array[r] = temp;
        }
        return array;
    }
}
