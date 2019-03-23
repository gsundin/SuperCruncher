using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to tell when player has collided with a Troggle
// Also used to tell which space the player is currently on
public class PlayerCollider : Player
{
    public static string currentTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger touched: " + other.gameObject.name);
        currentTrigger = other.gameObject.name;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }
}