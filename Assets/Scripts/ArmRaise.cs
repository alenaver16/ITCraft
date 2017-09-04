using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for character arm raising after 5 touched
public class ArmRaise : MonoBehaviour
{
    private Animator anim; //animator controller
  
    private int count = 0; // touch count
    private float _clickDelay = 0.9f; // maximum permissible time interval between touch
    private float _clickTime; // time interval between two touch

    private void Start()
    {
        anim = GetComponent<Animator>(); // Animator initialization 
    }

    void Update()
    {
        CheckClicks(); // Invocation a checking function 
    }
    // Function to check clicks count and time between clicks
    private void CheckClicks()
    {
        if (Input.GetMouseButtonUp(0))
        {
            count++;
            _clickTime = 0;
        }

        if (count == 0) return;

        if (_clickTime < _clickDelay) // If time between click is less then _clickDelay count new time between  touches
        {
            _clickTime += Time.deltaTime;
            return;
        }

        HandleClicks(count); // Invocation a executant function 
        count = 0;
        _clickTime = 0;

    }
    // Function to invocation trigger ArmRaise if touch count is 5
    private void HandleClicks(int count)
    {
        if (count == 5)
        {
            anim.SetTrigger("ArmRaise");
        }
    }
}


