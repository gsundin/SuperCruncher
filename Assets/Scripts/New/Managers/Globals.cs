using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to reference constant variables that don't belong in any one script
public class Globals : MonoBehaviour
{
    // Grid variables
    public static int GRID_ROWS = 7;
    public static int GRID_COLS = 5;
    public static int GRID_SIZE = GRID_ROWS * GRID_COLS;
    public static float ACTOR_SPEED = 512f;
    public static float DISTANCE_PER_MOVE = 64f;
    public static int SPACE_SIZE = 64;
    public static float[] GRID_LIMITS = { 128f, -128f, -192, 192 };

    // Game variables
    public static int MIN_CORRECT_ANSWERS = 10;
    public static int MAX_CORRECT_ANSWERS = 20;
    public static int POINTS_PER_CHOMP = 5;
    public static int[] NUMBER_OF_ANSWERS_DIFFICULTY = {8, 12, 16, 20, 24, 28, 32, 35};
    public static int[] PRIMES_DIFFICULTY = {3, 5, 9, 14, 21, 30, 50, 90};


    //TODO: Learn how to use singletons to replace static global variables
    //public static Globals Instance { get; private set; }


}
