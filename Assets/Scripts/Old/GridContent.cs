using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridContent : MonoBehaviour
{
    [SerializeField]
    public const int GRID_SIZE = 35;
    public Font commodore64;

    public Text[] tileTexts;
    public static GridContent Instance { get; private set; }
    //public BoxCollider2D[] textBoxes;

    private string[] gridContent;
    private int minCorrectAnswers = 10;
    private int maxCorrectAnswers = 20;
    public int numberOfCorrectAnswers;
    public int numberOfCorrectChomps = 0;

    // Set range for all number sets
    private int[] range = {0,30};


    // Start is called before the first frame update
    void Start()
    {
        // Populate grid with prime set
        SetTileTexts(GeneratePrimes(range));
        SoundManagerScript.PlaySound("level_clear2");
    }

    // Update is called once per frame
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

    // Display text on tiles
    void SetTileTexts(int[] content)
    {
        for (int tile = 0; tile < tileTexts.Length; tile++)
        {
            tileTexts[tile].text = content[tile].ToString();
        }
    }

    // Generate prime number set (correct/incorrect)
    int[] GeneratePrimes(int[] range)
    {
        // Number of primes on the grid for current level
        numberOfCorrectAnswers = Random.Range(minCorrectAnswers, maxCorrectAnswers);
        //Debug.Log("numberOfCorrectAnswers = " + numberOfCorrectAnswers);

        int[] primes = new int[GRID_SIZE];

        // Generate correct answers
        for (int i = 0; i < numberOfCorrectAnswers; i++)
        {
            int primeNumber = 4;
            while (!IsPrime(primeNumber))
            {
                primeNumber = Random.Range(range[0], range[1]);
            }
            primes[i] = primeNumber;
        }

        // Generate incorrect answers
        for (int i = numberOfCorrectAnswers; i < GRID_SIZE; i++)
        {
            int notPrimeNumber = 2;
            while (IsPrime(notPrimeNumber))
            {
                notPrimeNumber = Random.Range(range[0], range[1]);
            }
            primes[i] = notPrimeNumber;
        }

        // Shuffle array to randomize placement on grid
        ShuffleArray(primes);

        return primes;
    }

    // Randomizes array order using Fisher-Yates algoritm
    int[] ShuffleArray(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            int temp = array[i];
            array[i] = array[r];
            array[r] = temp;
        }
        return array;
    }

    // Returns true if input is a prime number
    public bool IsPrime(int number)
    {
        if (number < 2)
            return false;
        if (number == 2)
            return true;
        if (number % 2 == 0)
            return false;
        for (int i = 3; i <= Mathf.Sqrt(number); i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
