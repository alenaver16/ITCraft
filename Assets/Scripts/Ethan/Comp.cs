using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Controller))]
    [RequireComponent(typeof(Move))]
    // Class that controls button's click
    class Comp : MonoBehaviour
    {
        private Move move; // variable of Move class
        private Controller controller;  // variable of Controller class

        void Start()
        {
            move = GetComponent<Move>(); // initialize a variable to access funtions from class Move
            controller = GetComponent<Controller>(); // initialize a variable to access funtions from class Move
        }
        //Function that detect which button has touched and invocate appropriate method from class Move
        public void Motion()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                move.Run(); controller.PassedTime = 0; return; 
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                move.Stop(); controller.PassedTime = 0; controller.FlagRun = true; return;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                move.RunLeft(); controller.PassedTime = 0; return;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                move.RunRight(); controller.PassedTime = 0; return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                move.Jump(); controller.PassedTime = 0;  return;
            }

        }
    }
}
