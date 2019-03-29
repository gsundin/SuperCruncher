﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioClip chomp, hurt, level_start, level_clear2, game_over;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        chomp = Resources.Load<AudioClip>("chomp");
        hurt = Resources.Load<AudioClip>("hurt");
        level_start = Resources.Load<AudioClip>("level_start");
        level_clear2 = Resources.Load<AudioClip>("level_clear2");
        game_over = Resources.Load<AudioClip>("game_over");

        audioSrc = GetComponent<AudioSource>();
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

    public void Play(string clip)
    {
        switch (clip)
        {
            case "chomp":
                audioSrc.PlayOneShot(chomp);
                break;

            case "hurt":
                audioSrc.PlayOneShot(hurt);
                break;

            case "level_start":
                audioSrc.PlayOneShot(level_start);
                break;

            case "level_clear2":
                audioSrc.PlayOneShot(level_clear2);
                break;

            case "game_over":
                audioSrc.PlayOneShot(game_over);
                break;
        }
    }
}
