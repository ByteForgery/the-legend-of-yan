using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour  //Yannik
{

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.setBool(isMoving, true);
    }


    void Update()
    {
        if (animator.isMoving) {
            animator.Play("running");
            Debug.Log("läuft");
        }
    }
}
