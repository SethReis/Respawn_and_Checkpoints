using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Respawn : Player
{
    Vector2 respawnLoc;
    private Boolean canSave;
    private Collider2D currentCheckPoint;
    private Animator anim;
    private Rigidbody2D rigidBody;
    
    void Start()
    {
        canSave = false;
        currentCheckPoint = null;
        anim = GetComponent<Animator>();
        rigidBody = transform.GetComponent<Rigidbody2D>();
        respawnLoc = transform.position;
    }

    void Update()
    {
        if (canSave)
        {
            if (rigidBody.velocity.y == 0)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    rigidBody.velocity = new Vector2(0, 0);
                    if (currentCheckPoint.gameObject.GetComponent<CheckPoint>().getBeenSavedAt() == false)
                    {
                        anim.SetBool("SavingAtCheckpoint", true);
                        currentCheckPoint.gameObject.GetComponent<CheckPoint>().setBeenSavedAt(true);
                    }
                    else
                    {
                        anim.SetBool("ResaveCheckpoint", true);
                    }
                    Vector2 newLoc = currentCheckPoint.transform.position;
                    ChangeSpawnPoint(newLoc);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().tag == "DeathTrigger")
        {
            ReloadSpawnPoint();
        }

        if (col.GetComponent<Collider2D>().tag == "CheckPoint")
        {
            canSave = true;
            currentCheckPoint = col;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().tag == "CheckPoint")
        {
            canSave = false;
            currentCheckPoint = null;
        }
    }

    void ReloadSpawnPoint()
    {
        rigidBody.position = respawnLoc;
        rigidBody.velocity = new Vector2(0, 0); 
    }

    void ChangeSpawnPoint(Vector2 newLoc)
    {
        respawnLoc = newLoc;
    }


}
