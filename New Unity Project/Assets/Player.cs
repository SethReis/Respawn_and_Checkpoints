using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private Land_Movement landMovement;
    private Respawn respawn;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        landMovement = gameObject.GetComponent<Land_Movement>();
        respawn = gameObject.GetComponent<Respawn>();
    }
    void OnCollisionEnter2D(Collision2D col)
    { // TODO: refine this velocity check, this one goes off for ceilings and walls.
        if (col.gameObject.CompareTag("Clip") && (this.transform.GetComponent<Rigidbody2D>().velocity.y < 0.1))
        {
            grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Clip"))
        {
            grounded = false;
        }
    }

    public bool getGrounded()
    {
        return grounded;
    }
}
