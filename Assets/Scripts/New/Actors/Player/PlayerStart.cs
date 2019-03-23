using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player starts on a random space (which will be empty)
public class PlayerStart : Player

{
    void Start()
    {
        int playerStartX = Random.Range(-3, 4) * Globals.GRID_SIZE;
        int playerStartY = Random.Range(-2, 3) * Globals.GRID_SIZE;

        transform.position = new Vector3(playerStartX, playerStartY);
    }
}
