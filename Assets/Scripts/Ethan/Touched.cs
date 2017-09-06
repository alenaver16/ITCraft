using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Controller))]
    [RequireComponent(typeof(Move))]
    // Class that controls touches
    class Touched : MonoBehaviour
    {
        private Move move;  // variable of Move class
        private Controller controller;  // variable of Controller class

        void Start()
        {
            move = GetComponent<Move>(); // initialize a variable to access funtions from class Move
            controller = GetComponent<Controller>(); // initialize a variable to access funtions from class Move
        }

        private float minDist = 0.5f; // minimum length of swipe
        private float startTime; // time of start touch
        private float finishTime; // time of end touch
        private Vector3 startPos; // position of start touch
        private Vector3 finishPos; // position of end touch
        private Vector2 dist; // distance between start and end touch 
        private float swipeDist; //distance between start and end touch
        private float swipeTime; //time between start and end touch

        //Function that check count of clicks
        public void GetTouch()
        {
            if (Input.touchCount == 1)
            {
                OneTouch();
            }
            if (Input.touchCount == 2)
            {
                TwoTouch();
            }
        }
        // Function that controls swipes
        private void OneTouch()
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

                if (swipeTime < controller.MaxTime && swipeDist > minDist)
                {
                    Swipe(); // Invocation function that detect in which direction was swipe
                }
            }
            controller.PassedTime = 0; return;
        }
        // Function that controls jumping
        private void TwoTouch() {
            Touch touch_1 = Input.GetTouch(0);
            Touch touch_2 = Input.GetTouch(1);

            if (touch_1.phase == TouchPhase.Began && touch_2.phase == TouchPhase.Began)
            {
                move.Jump(); controller.FlagRun = true; controller.PassedTime = 0; return;
            }
        }
        // Function that determinate moving direction
        private void Swipe()
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
                    move.Stop(); controller.FlagRun = true;
                }
            }
        }
    }
}
