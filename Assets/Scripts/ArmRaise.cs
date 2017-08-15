using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRaise : MonoBehaviour
{
    public Animator anim;
    public GameObject Hand;
    private int count = 0;
    private float _clickDelay = 0.9f;
    private float _clickTime;

    private void Start()
    {
        anim = Hand.GetComponent<Animator>();
    }

    void Update()
    {
        CheckClicks();
    }
    private void CheckClicks()
    {
        if (Input.GetMouseButtonUp(0))
        {
            count++;
            _clickTime = 0;
        }

        if (count == 0) return;

        if (_clickTime < _clickDelay)
        {
            _clickTime += Time.deltaTime;
            return;
        }

        HandleClicks(count);
        count = 0;
        _clickTime = 0;

    }
    private void HandleClicks(int count)
    {
        if (count == 5)
        {
            anim.SetTrigger("ArmRaise");
        }
    }
}


