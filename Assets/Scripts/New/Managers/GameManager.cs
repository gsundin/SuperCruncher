using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Responsible for controlling the game through the other scripts
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int previousNumberOfCorrectChomps;
    public int currentNumberOfCorrectChomps;
    public int currentNumberOfIncorrectChomps;
    public int currentNumberOfAnswers = Globals.GRID_SIZE;
    public int currentNumberOfCorrectAnswers;
    public int[] numberRange = new int[2];

    private string rule = "primes";
    private int[] numberSet;

    void Start()
    {
        InitializeGridStats();
        StartGame();
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            Instance = this;
        }
    }

    void StartGame()
    {
        currentNumberOfAnswers = Globals.GRID_SIZE;
        numberSet = NumberSet.Generate(currentNumberOfAnswers, currentNumberOfCorrectAnswers, numberRange, rule);
        GridManager.Instance.SetSpaceText(numberSet);
        SoundManager.Instance.Play("level_start");
    }

    public void CorrectChomp()
    {
        // Level has been cleared
        if (currentNumberOfCorrectChomps == currentNumberOfCorrectAnswers)
        {
            SoundManager.Instance.Play("level_clear2");
            PlayerAnimator.anim.Play("Player_Happy");
            Invoke("LevelClear", 3);
        }
        else if (currentNumberOfCorrectChomps > previousNumberOfCorrectChomps && currentNumberOfCorrectChomps != currentNumberOfCorrectAnswers)
        {
            ScoreManager.Instance.AddToScore(Globals.POINTS_PER_CHOMP);
            SoundManager.Instance.Play("chomp");
            PlayerAnimator.anim.Play("Player_Chomp");
        }
        previousNumberOfCorrectChomps = currentNumberOfCorrectChomps;
    }

    public void IncorrectChomp()
    {
        currentNumberOfIncorrectChomps++;
        PlayerAnimator.anim.SetBool("upset", true);

        if (currentNumberOfIncorrectChomps < 3)
        {
            SoundManager.Instance.Play("hurt");
            PlayerAnimator.anim.Play("Player_Sad");
        }
        else if (currentNumberOfIncorrectChomps >= 3)
        {
            SoundManager.Instance.Play("game_over");
            PlayerAnimator.anim.Play("Player_Death");
            Invoke("GameOver", 3);
        }
    }

    // The player has lost the game; go to main menu
    void GameOver()
    {
        StartGame();
        InitializeGridStats();
        numberSet = NumberSet.Generate(currentNumberOfAnswers, currentNumberOfCorrectAnswers, numberRange, rule);
        GridManager.Instance.SetSpaceText(numberSet);
        SoundManager.Instance.Play("level_start");
        ScoreManager.Instance.SetScore(0);
        SceneManager.LoadScene("MainMenuScene");
        
    }

    void LevelClear()
    {
        StartGame();
        InitializeGridStats();
        numberSet = NumberSet.Generate(currentNumberOfAnswers, currentNumberOfCorrectAnswers, numberRange, rule);
        GridManager.Instance.SetSpaceText(numberSet);
        SoundManager.Instance.Play("level_start");
        // REPLENISH LIVES
        // MAKE SURE TO HAVE DELAY
    }

    void InitializeGridStats()
    {
        PlayerController.Instance.RandomizePlayerPosition();
        GridManager.Instance.ReEnableTexts();
        currentNumberOfIncorrectChomps = 0;
        currentNumberOfCorrectChomps = 0;
        previousNumberOfCorrectChomps = -1;
        //currentNumberOfCorrectAnswers = Random.Range(Globals.NUMBER_OF_ANSWERS_DIFFICULTY[0], Globals.NUMBER_OF_ANSWERS_DIFFICULTY[4]);
        currentNumberOfCorrectAnswers = Random.Range(1, 10);
        numberRange[0] = 0;
        numberRange[1] = Globals.PRIMES_DIFFICULTY[1];
    }
}
