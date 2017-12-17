﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

    // Variables set in the inspector
    public float WalkSpeed = 3;
    public float RunSpeed = 5;
    public float JumpForce = 300;

    // Booleans used to coordinate with the animator's state machine
    bool Running;
    bool Moving;
    bool Grounded;
    bool Falling;
    bool Jumping;

    // References to other components (can be from other game objects!)
    Animator Animator;
    Rigidbody2D RigidBody2D;

    void Start()
    {
        // Get references to other components and game objects
        RigidBody2D = GetComponent<Rigidbody2D>();
        // TODO: Get Animator Reference
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveCharacter();
        CheckFalling();
        CheckGrounded();

        // Update animator's variables
        Animator.SetBool("Isrunning", Running);
        Animator.SetBool("Ismoving", Moving);
        // TODO: Set Animator for Grounded
        Animator.SetBool("Isgrounded", Grounded);
        // TODO: Set Animator for Falling
        Animator.SetBool("Isfalling", Falling);
        Animator.SetBool("Isjumping", Jumping);
    }



    private void MoveCharacter()
    {
        // Check if we are running or not
        // TODO: Check if the player wants Mario to run (see input manager)
        //       and set the value of "Running" accordingly
        //       Use Input and the intellisence
        if (Input.GetKey("left shift"))
        { Running = true; }
        else Running = false;

        if (Input.GetKey("space"))
        { Jumping = true; }
        else Jumping = false;

        // Determine movement speed
        float moveSpeed = Running ? RunSpeed : WalkSpeed;
        //Change value    (  IF   )    TRUE    :   FALSE   ;

        // Check for movement
        Moving = Input.GetButton("Horizontal"); //returns true or false if pressed.
        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        FaceDirection(new Vector2(direction, 0));

        // Check if we can jump
        if (Grounded && Input.GetButtonDown("Jump"))
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce);
        }

    }

    private void CheckFalling()
    {
        Falling = RigidBody2D.velocity.y < 0.0f;
    }

    private void CheckGrounded()
    {
        Grounded = RigidBody2D.velocity.y == 0.0f;
    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)  //Don't change look.
            return;

        // Flip the sprite (NOTE: Vector3.forward is positive Z in 3D. The Sprite is on XY plane!)
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
    }
}
