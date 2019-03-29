using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesAnimator : MonoBehaviour
{
    public static LivesAnimator Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
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

    void LivesChomp()
    {

    }

    void LivesHappy()
    {

    }

    void LivesSad()
    {

    }

    void LivesDeath()
    {

    }

    void RemoveLife()
    {

    }
}
