using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{

    public static string currentTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentTrigger = other.gameObject.name;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
