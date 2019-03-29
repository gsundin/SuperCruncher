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
            int currentCorrectChomps = GameManager.Instance.currentNumberOfCorrectChomps;
            string currentTrigger = ColliderScript.currentTrigger;

            for (int i = 0; i < GridContent.GRID_SIZE; i++)
            {
                int chompedNumber = int.Parse(GridManager.Instance.texts[i].text);
                
                string spaceName = GridManager.Instance.texts[i].name;
                if (currentTrigger == spaceName && Primes.Is(chompedNumber) && GridManager.Instance.texts[i].enabled)
                {
                    GridManager.Instance.texts[i].enabled = false;
                    GameManager.Instance.currentNumberOfCorrectChomps++;
                    GameManager.Instance.CorrectChomp();
                    break;
                }
                else if (currentTrigger == spaceName && !Primes.Is(chompedNumber))
                {
                    GridManager.Instance.texts[i].enabled = false;
                    GameManager.Instance.IncorrectChomp();
                    break;
                }
            }
        }
    }
}
