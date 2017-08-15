using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private Animator anim;
    public GameObject character;

    public float maxTime;
    public float minDist;

    float startTime;
    float finishTime;

    Vector3 startPos;
    Vector3 finishPos;

    Vector2 dist;

    float swipeDist;
    float swipeTime;

    float passedTime;

private void Start()
{
    anim = character.GetComponent<Animator>();

}

private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("run");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("stop");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("runleft");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("runright");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("crouch");
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

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

                if( swipeTime < maxTime && swipeDist > minDist )
                {
                    swipe();
                }
            }
            passedTime = 0; return;
        }

        if (Input.touchCount == 2)
        {
            Touch touch_1 = Input.GetTouch(0);
            Touch touch_2 = Input.GetTouch(1);

            if (touch_1.phase == TouchPhase.Began && touch_2.phase == TouchPhase.Began)
            {
                anim.SetTrigger("jump");
                passedTime = 0; return;
            }
            
        }

        if(passedTime < maxTime)
        {
            passedTime += Time.deltaTime; return;
        }
        else if(passedTime > maxTime)
        {
            anim.SetTrigger("crouch");
            passedTime = 0; return;
        }
}
    public void swipe()
    {
        dist = finishPos - startPos;
        if(Mathf.Abs(dist.x) > Mathf.Abs(dist.y))
        {
            if (dist.x > 0)
            {
                anim.SetTrigger("runright"); 
            }
            if (dist.x < 0)
            {
                anim.SetTrigger("runleft"); 
            }
        }
        else if (Mathf.Abs(dist.x) < Mathf.Abs(dist.y))
        {
            
            if (dist.y > 0)
            {
                anim.SetTrigger("run");
            }
            if (dist.y < 0)
            {
                anim.SetTrigger("stop");
            }
        }
    }
}
