using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Image textHighlighter;
    [SerializeField]
    private RectTransform textHighlighterRect;
    [SerializeField]
    private Text[] menuText;

    private float textWidth;
    private int cursor;

    // Start is called before the first frame update
    void Start()
    {
        cursor = 0;
        moveHighlighter();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtain directional input
        if (Input.GetKeyDown(KeyCode.W) && cursor > 0)
        {
            cursor--;
            moveHighlighter();
        }
        if (Input.GetKeyDown(KeyCode.S) && cursor < 4)
        {
            cursor++;
            moveHighlighter();
        }

        // Player is selecting a menu option
        if (Input.GetKeyDown(KeyCode.Return) && cursor >= 0 && cursor <= 4)
        {
            Debug.Log("Selection has been made");
            select();
        }
    }

    void moveHighlighter()
    {
        allWhiteText();

        switch (cursor)
        {
            case 0:
                textWidth = CalculateLengthOfMessage(menuText[0]) * 0.1f;
                textHighlighter.rectTransform.sizeDelta = new Vector2(textWidth, 30);
                textHighlighter.rectTransform.anchoredPosition = menuText[0].rectTransform.position;
                menuText[0].color = Color.black;
                break;
            case 1:
                textWidth = CalculateLengthOfMessage(menuText[1]) * 0.1f;
                textHighlighter.rectTransform.sizeDelta = new Vector2(textWidth, 30);
                textHighlighter.rectTransform.anchoredPosition = menuText[1].rectTransform.position;
                menuText[1].color = Color.black;
                break;
            case 2:
                textWidth = CalculateLengthOfMessage(menuText[2]) * 0.1f;
                textHighlighter.rectTransform.sizeDelta = new Vector2(textWidth, 30);
                textHighlighter.rectTransform.anchoredPosition = menuText[2].rectTransform.position;
                menuText[2].color = Color.black;
                break;
            case 3:
                textWidth = CalculateLengthOfMessage(menuText[3]) * 0.1f;
                textHighlighter.rectTransform.sizeDelta = new Vector2(textWidth, 30);
                textHighlighter.rectTransform.anchoredPosition = menuText[3].rectTransform.position;
                menuText[3].color = Color.black;
                break;
            case 4:
                textWidth = CalculateLengthOfMessage(menuText[4]) * 0.1f;
                textHighlighter.rectTransform.sizeDelta = new Vector2(textWidth, 30);
                textHighlighter.rectTransform.anchoredPosition = menuText[4].rectTransform.position;
                menuText[4].color = Color.black;
                break;
        }
    }

    void select()
    {
        switch (cursor)
        {
            case 0:
                Debug.Log("Loading game...");
                SceneManager.LoadScene("GameScene");
                break;

            case 1:
                Debug.Log("Hall of Fame is not ready yet");
                break;

            case 2:
                Debug.Log("Information is not ready yet");
                break;

            case 3:
                Debug.Log("Options is not ready yet");
                break;

            // Quit the game
            case 4:
                Debug.Log("Quitting game...");
                Application.Quit();
                break;
        }
    }

    int CalculateLengthOfMessage(Text menuItem)
    {
        int totalLength = 0;
        Font myFont = menuItem.font;
        CharacterInfo characterInfo = new CharacterInfo();
        char[] arr = menuItem.text.ToCharArray();

        foreach (char c in arr)
        {
            myFont.GetCharacterInfo(c, out characterInfo, menuItem.fontSize);
            totalLength += characterInfo.advance;
        }
        return totalLength;
    }

    void allWhiteText()
    {
        foreach (Text t in menuText)
        {
            t.color = Color.white; 
        }
    }
}
