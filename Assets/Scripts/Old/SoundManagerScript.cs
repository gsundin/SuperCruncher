using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip chomp, death, level_start, level_clear2;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        chomp = Resources.Load<AudioClip>("chomp");
        death = Resources.Load<AudioClip>("death");
        level_start = Resources.Load<AudioClip>("level_start");
        level_clear2 = Resources.Load<AudioClip>("level_clear2");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "chomp":
                audioSrc.PlayOneShot(chomp);
                break;

            case "death":
                audioSrc.PlayOneShot(death);
                break;

            case "level_start":
                audioSrc.PlayOneShot(level_start);
                break;

            case "level_clear2":
                audioSrc.PlayOneShot(level_clear2);
                break;
        }
    }
}
