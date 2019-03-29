using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public static PlayerController Instance { get; private set; }

    private Vector3 playerPosition;

    private float distancePerSpaceX = 64f;
    private float distancePerSpaceY = 64f;

    private float lastInputX;
    private float lastInputY;
    private float prevLastInputX;
    private float prevLastInputY;

    // Start is called before the first frame update
    void Start()
    {
        RandomizePlayerPosition();
    }

    // No game physics; using Update instead of FixedUpdate
    void Update()
    {
        // Obtain intended player movement
        if (Input.GetKey(KeyCode.A) && transform.position == playerPosition && gameObject.transform.position.x > Globals.GRID_LIMITS[2])
        {        // Left
            playerPosition += new Vector3(-distancePerSpaceX, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && transform.position == playerPosition && gameObject.transform.position.x < Globals.GRID_LIMITS[3])
        {        // Right
            playerPosition += new Vector3(distancePerSpaceX, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) && transform.position == playerPosition && gameObject.transform.position.y < Globals.GRID_LIMITS[0])
        {        // Up
            playerPosition += new Vector3(0, distancePerSpaceY, 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.position == playerPosition && gameObject.transform.position.y > Globals.GRID_LIMITS[1])
        {        // Down
            playerPosition += new Vector3(0, -distancePerSpaceY, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);

        lastInputX = Input.GetAxis("Horizontal");
        lastInputY = Input.GetAxis("Vertical");

        // For animation blending trees
        if (Mathf.Abs(lastInputX) > Mathf.Abs(prevLastInputX) || Mathf.Abs(lastInputY) > Mathf.Abs(prevLastInputY) || Mathf.Abs(lastInputX) == 1 || Mathf.Abs(lastInputY) == 1)
        {
            PlayerAnimator.anim.SetBool("moving", true);
            if (lastInputX > 0)
            {
                PlayerAnimator.anim.SetFloat("lastMoveX", 1f);
            }
            else if (lastInputX < 0)
            {
                PlayerAnimator.anim.SetFloat("lastMoveX", -1f);
            }
            else
            {
                PlayerAnimator.anim.SetFloat("lastMoveX", 0f);
            }

            if (lastInputY > 0)
            {
                PlayerAnimator.anim.SetFloat("lastMoveY", 1f);
            }
            else if (lastInputY < 0)
            {
                PlayerAnimator.anim.SetFloat("lastMoveY", -1f);
            }
            else
            {
                PlayerAnimator.anim.SetFloat("lastMoveY", 0f);
            }
        }
        else
        {
            PlayerAnimator.anim.SetBool("moving", false);
        }
        prevLastInputX = lastInputX;
        prevLastInputY = lastInputY;
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

    public void RandomizePlayerPosition()
    {
        int playerStartX = Random.Range(-3, 4) * Globals.SPACE_SIZE;
        int playerStartY = Random.Range(-2, 3) * Globals.SPACE_SIZE;
        playerPosition = new Vector3(playerStartX, playerStartY);

        transform.position = new Vector3(playerStartX, playerStartY, 0);
    }
}
