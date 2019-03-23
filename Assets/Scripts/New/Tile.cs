using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Template class for all tiles on the grid
// Tiles are "disabled" when chomped, and are then re-valued and enabled for the next level to limit garbage
[CreateAssetMenu(fileName = "New Tile", menuName = "Space")]
public class Tile : ScriptableObject
{
    // The number/word seen on grid by the player
    public Text text;

    // The position of the tile on the grid
    public Vector3 position;

    // Trigger collider used to detect when player enters this tile
    public BoxCollider2D collider;
}
