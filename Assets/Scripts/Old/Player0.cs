using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player0 : MonoBehaviour
{
    [SerializeField]
    private float speed = 512f;
    private const int TILE_SIZE = 64;

    public int playerStartX;
    public int playerStartY;
    public Vector3 playerPosition;

    private Animator anim;

    // Bounds for actor movement
    [SerializeField]
    private float[] areaLimits = {128f, -128f, -192, 192};

    private float horizontalDistanceToMove = 64f;
    private float verticalDistanceToMove = 64f;

    private float lastInputX;
    private float lastInputY;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        playerStartX = Random.Range(-3, 4) * TILE_SIZE;
        playerStartY = Random.Range(-2, 3) * TILE_SIZE;
        playerPosition = new Vector3(playerStartX, playerStartY);

        transform.position = new Vector3(playerStartX, playerStartY, 0);
        Debug.Log("Player starting position: [" + playerStartX + ", " + playerStartY + "]");
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        anim.SetFloat("SpeedX", inputX);
        anim.SetFloat("SpeedY", inputY);
    }

    void FixedUpdate()
    {
        // Chomp tile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentCorrectChomps = GridContent.Instance.numberOfCorrectChomps;
            string currentTrigger = ColliderScript.currentTrigger;
            //Debug.Log(currentTrigger);

            for (int i = 0; i < GridContent.GRID_SIZE; i++)
            {
                int chompedNumber = int.Parse(GridContent.Instance.tileTexts[i].text);
                //Debug.Log("Chomping down on " + chompedNumber + "!");
                string tileTextName = GridContent.Instance.tileTexts[i].name;
                if (currentTrigger == tileTextName && GridContent.Instance.IsPrime(chompedNumber) && GridContent.Instance.tileTexts[i].enabled)
                {
                    // Correct chomp: make text invisible, play chomp animation/sound, increment correct chomps
                    GridContent.Instance.tileTexts[i].enabled = false;
                    GridContent.Instance.numberOfCorrectChomps++;
                    anim.SetBool("chomping", true);
                    //Debug.Log("You chomped a prime number, pal!");
                    break;
                }
                else if (currentTrigger == tileTextName && !GridContent.Instance.IsPrime(chompedNumber))
                {
                    // Incorrect chomp: make text red, play hurt animation/sound
                    GridContent.Instance.tileTexts[i].color = Color.red;
                    SoundManagerScript.PlaySound("death");
                    anim.SetBool("chompedIncorrectTile", true);
                    //Debug.Log("You chomped on the wrong number, buddy!");
                    break;
                }
            }

            if (GridContent.Instance.numberOfCorrectChomps >= GridContent.Instance.numberOfCorrectAnswers)
            {
                // Victory!
                //anim.SetBool("happy", true);
                SoundManagerScript.PlaySound("level_clear2");
                //Debug.Log("Victory!");
            }
            else if ( currentCorrectChomps < GridContent.Instance.numberOfCorrectChomps)
            {
                SoundManagerScript.PlaySound("chomp");
            }

            //Debug.Log("Correct answers: " + GridContent.Instance.numberOfCorrectAnswers);
            //Debug.Log("Correct chomps: " + GridContent.Instance.numberOfCorrectChomps);
        }
        else
        {
            anim.SetBool("chomping", false);
            anim.SetBool("chompedIncorrectTile", false);
        }

        // Obtain intended player movement
        if (Input.GetKey(KeyCode.A) && transform.position == playerPosition && gameObject.transform.position.x > areaLimits[2])
        {        // Left
            playerPosition += new Vector3(-horizontalDistanceToMove, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && transform.position == playerPosition && gameObject.transform.position.x < areaLimits[3])
        {        // Right
            playerPosition += new Vector3(horizontalDistanceToMove, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) && transform.position == playerPosition && gameObject.transform.position.y < areaLimits[0])
        {        // Up
            playerPosition += new Vector3(0, verticalDistanceToMove, 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.position == playerPosition && gameObject.transform.position.y > areaLimits[1])
        {        // Down
            playerPosition += new Vector3(0, -verticalDistanceToMove, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);

        lastInputX = Input.GetAxis("Horizontal");
        lastInputY = Input.GetAxis("Vertical");

        // For animation blending trees
        if (lastInputX != 0 || lastInputY != 0)
        {
            anim.SetBool("moving", true);
            if (lastInputX > 0)
            {
                anim.SetFloat("lastMoveX", 1f);
            }
            else if (lastInputX < 0)
            {
                anim.SetFloat("lastMoveX", -1f);
            }
            else
            {
                anim.SetFloat("lastMoveX", 0f);
            }

            if (lastInputY > 0)
            {
                anim.SetFloat("lastMoveY", 1f);
            }
            else if (lastInputY < 0)
            {
                anim.SetFloat("lastMoveY", -1f);
            }
            else
            {
                anim.SetFloat("lastMoveY", 0f);
            }
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

}
