using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Move))]

public class EthanController : MonoBehaviour
{
    private Animator anim; //animator controller
    private Move move; // variable of Move class

    private float maxTime = 10; // maximum permissible time interval between touch
    private float minDist = 0.5f; // minimum length of swipe

    private float startTime; // time of start touch
    private float finishTime; // time of end touch

    private Vector3 startPos; // position of start touch
    private Vector3 finishPos; // position of end touch

    private Vector2 dist; // distance between start and end touch 

    private float swipeDist; //distance between start and end touch
    private float swipeTime; //time between start and end touch

    private float passedTime; // time interval between two touch

    private bool flag = true; // variable to checing character's motion
    // Animator property
    public Animator Animator
    {
        get { return this.anim;}
    }

    void Start()
    {
        anim = GetComponent<Animator>(); // Animator initialization
        move = GetComponent<Move>(); // initialize a variable to access funtions from class Move
    }

    void Update()
    {
        // Action if  user touch on scrin
        if (Input.touchCount > 0)
        {
            // Action if touch count is 1
            if (Input.touchCount == 1)
            {

                Touch touch = Input.GetTouch(0); // get count of touch

                if (touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;
                    startPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    finishTime = Time.time;
                    finishPos = touch.position;

                    swipeDist = (startPos - finishPos).magnitude;
                    swipeTime = startTime - finishTime;

                    if (swipeTime < maxTime && swipeDist > minDist)
                    {
                        swipe(); // Invocation function that detect in which direction was swipe
                    }
                }
                passedTime = 0; return;
            }
            // Action if touch count is 2
            if (Input.touchCount == 2)
            {

                Touch touch_1 = Input.GetTouch(0);
                Touch touch_2 = Input.GetTouch(1);

                if (touch_1.phase == TouchPhase.Began && touch_2.phase == TouchPhase.Began)
                {
                    move.Jump(); passedTime = 0; return;
                }

            }
        }
        // Actions if user click on button
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            move.Run(); passedTime = 0; return;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            move.Stop(); passedTime = 0; flag = true; return;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move.RunLeft(); passedTime = 0; return;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            move.RunRight(); passedTime = 0; return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move.Jump(); passedTime = 0; return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            move.Crouch(); passedTime = 0; return;
        }
        //Checing passed time between actions
        if (passedTime < maxTime && flag)
        {
            passedTime += Time.deltaTime; return;
        }
        else if (passedTime > maxTime) // if passed 10 sec character will crouch
        {
            move.Crouch(); passedTime = 0; flag = false; return;
        }
    }
    // Function that controll the swipe direction and invocation a function depending on the direction
    public void swipe()
    {
        dist = finishPos - startPos;
        if (Mathf.Abs(dist.x) > Mathf.Abs(dist.y))
        {
            if (dist.x > 0)
            {
                move.RunRight();

            }
            if (dist.x < 0)
            {
                move.RunLeft();
            }
        }
        else if (Mathf.Abs(dist.x) < Mathf.Abs(dist.y))
        {

            if (dist.y > 0)
            {
                move.Run();
            }
            if (dist.y < 0)
            {
                move.Stop(); flag = true;
            }
        }
    }
}
