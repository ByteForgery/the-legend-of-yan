using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour  //Yannik
{
    private PlayerMovement movement;
    private Animator animator;
    private bool isMoving;
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }


    void FixedUpdate()
    {
        if (movement.MoveInput != null) {
            Debug.Log("läuft");
        }
    }
}
