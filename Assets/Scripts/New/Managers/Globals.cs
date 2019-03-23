using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to reference constant variables that don't belong in any one script
public class Globals : MonoBehaviour
{
    // Game world variables
    public static int GRID_SIZE = 35;
    public static float ACTOR_SPEED = 512f;
    public static float DISTANCE_PER_MOVE = 64f;
    public float[] GRID_LIMITS = { 128f, -128f, -192, 192 };

    //TODO: Learn how to use singletons to replace static global variables
    //public static Globals Instance { get; private set; }


}
