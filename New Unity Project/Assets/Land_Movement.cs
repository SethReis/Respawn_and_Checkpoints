using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class Land_Movement : Player
{
    private int topSpeed;
    private Animator anim;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        topSpeed = 30;
        anim = GetComponent<Animator>();
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("SavingAtCheckpoint") && !anim.GetBool("ResaveCheckpoint"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int jumpVel = 100;
                rigidBody.AddForce(Vector2.up * jumpVel);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                int rightVel = 1;
                rigidBody.AddForce(Vector2.right / rightVel);

                if (rigidBody.velocity.x >= topSpeed)
                {
                    rigidBody.velocity = rigidBody.velocity.normalized * topSpeed;
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                int leftVel = 1;
                rigidBody.AddForce(Vector2.left / leftVel);

                if (rigidBody.velocity.x <= -topSpeed)
                {
                    rigidBody.velocity = rigidBody.velocity.normalized * topSpeed;
                }
            }
        }
        
    }

    public Vector2 getVelocity()
    {
        return rigidBody.velocity;
    }
}
