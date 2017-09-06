using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Touched))]
[RequireComponent(typeof(Comp))]
public class Controller : MonoBehaviour {

    private Move move; // variable of Move class
    private Touched touched; // variable of Touched class
    private Comp comp; // variable of Comp class

    private static float passedTime; // time interval between two touch
    public  float PassedTime
    {
        get { return passedTime; }
        set { passedTime = value; }
    }

    private static bool flagRun = true; // variable to checing character's motion
    public  bool FlagRun
    {
        get { return flagRun; }
        set { flagRun = value; }
    }

    private static bool flagSit = true; // variable to checing character's motion
    public bool FlagSit
    {
        get { return flagSit; }
        set { flagSit = value; }
    }

    private Animator anim; //animator controller
    public Animator Animator
    {
        get { return this.anim; }
    }

    private float maxTime = 10; // maximum permissible time interval between touch
    public float MaxTime
    {
        get { return this.maxTime; }
        set { this.maxTime = value; }
    }
    void Start()
    {
        anim = GetComponent<Animator>(); // Animator initialization
        move = GetComponent<Move>(); // Initialize a variable to access funtions from class Move
        comp = GetComponent<Comp>(); // Initialize a variable to access funtions from class Comp
        touched = GetComponent<Touched>(); // Initialize a variable to access funtions from class Touched
    }
    void Update()
    {
        // Action if user touch on screen
        touched.GetTouch(); 
        comp.Motion();        
        
        //Checking passed time between actions
        CheckTime();
    }

    //Function that check passed time between actions
    private void CheckTime()
    {
        if ((passedTime < maxTime && flagRun))
        {
            passedTime += Time.deltaTime; return;
        }
        if (passedTime > maxTime) // if passed 10 sec character will crouch
        {
            move.Crouch(); passedTime = 0; flagRun = false; return;
        }
    }
}
