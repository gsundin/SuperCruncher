using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : Player
{
    public static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // X and Y go from [-1, 1], used for moving animations
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Also used for moving animations
        anim.SetFloat("SpeedX", inputX);
        anim.SetFloat("SpeedY", inputY);
    }

    // Overloaded static methods to set static animator parameters
    public static void SetValue(string name, float value)
    {
        anim.SetFloat(name, value);
    }

    public static void SetValue(string name, bool value)
    {
        anim.SetBool(name, value);
    }

    public static void SetValue(string name, int value)
    {
        anim.SetInteger(name, value);
    }

    public static void SetValue(string name)
    {
        anim.SetTrigger(name);
    }
}
