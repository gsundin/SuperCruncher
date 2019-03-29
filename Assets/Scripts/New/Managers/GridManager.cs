using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    public Vector3[] spaces;
    public Text[] texts;
    public BoxCollider2D[] colliders;

    public static GridManager Instance { get; private set; }

    //TODO: make this all programmatic
    //private float[] gridTranslationsX = {-3f, -2f, -1f, 0f, 1f, 2f, 3f};
    //private float[] gridTranslationsY =      {-2f, -1f, 0f, 1f, 2f};

    // Initialize position, name, and colliders for all grid spaces
    void Start()
    {
        SetColliderNames();
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

    private void SetColliderNames()
    {
        for (int i = 0; i < Globals.GRID_SIZE; i++)
        {
            colliders[i].name = "text" + i;
        }
    }

    public void SetSpaceText(int[] content)
    {
        for (int i = 0; i < Globals.GRID_SIZE; i++)
        {
            texts[i].text = content[i].ToString();
        }
    }

    public void ReEnableTexts()
    {
        for (int i = 0; i < Globals.GRID_SIZE; i++)
        {
            texts[i].enabled = true;
        }
    }
}
