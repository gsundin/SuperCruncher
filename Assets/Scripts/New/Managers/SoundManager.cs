﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    // All sounds, available to all classes
    public static AudioClip chomp, death, level_start,
                            level_clear2, beep, game_over,
                            troggle_warning;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Used to initialize all sounds
    private void Start()
    {
        chomp = Resources.Load<AudioClip>("chomp");
        death = Resources.Load<AudioClip>("death");
        level_start = Resources.Load<AudioClip>("level_start");
        level_clear2 = Resources.Load<AudioClip>("level_clear2");
        beep = Resources.Load<AudioClip>("beep");
        game_over = Resources.Load<AudioClip>("game_over");
        troggle_warning = Resources.Load<AudioClip>("troggle_warning");
    }

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }

}