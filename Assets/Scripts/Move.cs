using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EthanController))]

//Class that controls Ethan's triggers
public class Move : MonoBehaviour
{
    private Animator anim; //animator controller
    void Update()
    {
        anim = GetComponent<EthanController>().Animator; // initialize a variable to access animator controller from class EthanController
    }
    // Function to invocation run trigger 
    public void Run() { anim.SetTrigger("run"); }
    // Function to invocation stop trigger 
    public void Stop() { anim.SetTrigger("stop"); }
    // Function to invocation run left trigger 
    public void RunLeft() { anim.SetTrigger("runleft"); }
    // Function to invocation run right trigger 
    public void RunRight() { anim.SetTrigger("runright"); }
    // Function to invocation jump trigger 
    public void Jump() { anim.SetTrigger("jump"); }
    // Function to invocation crouch trigger 
    public void Crouch() { anim.SetTrigger("crouch"); }
}

