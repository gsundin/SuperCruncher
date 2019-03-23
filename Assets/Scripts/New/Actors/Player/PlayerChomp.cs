using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChomp : Player
{
    // Use Update to check if player is attempting to chomp
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Chomping initiated");
            int currentCorrectChomps = GridContent.Instance.numberOfCorrectChomps;
            string currentTrigger = ColliderScript.currentTrigger;

            for (int i = 0; i < GridContent.GRID_SIZE; i++)
            {
                int chompedNumber = int.Parse(GridContent.Instance.tileTexts[i].text);

                string tileTextName = GridContent.Instance.tileTexts[i].name;
                if (currentTrigger == tileTextName && GridContent.Instance.IsPrime(chompedNumber) && GridContent.Instance.tileTexts[i].enabled)
                {
                    GridContent.Instance.tileTexts[i].enabled = false;
                    GridContent.Instance.numberOfCorrectChomps++;
                    PlayerAnimator.SetValue("chomping", true);
                    //Debug.Log("You chomped a prime number, pal!");
                    break;
                }
                else if (currentTrigger == tileTextName && !GridContent.Instance.IsPrime(chompedNumber))
                {
                    GridContent.Instance.tileTexts[i].color = Color.red;
                    SoundManagerScript.PlaySound("death");
                    PlayerAnimator.SetValue("chompedIncorrectTile", true);
                    break;
                }
            }
        }
    }
}
