using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Collider2D player;
    private Boolean beenSavedAt;
    private Boolean active;
    private Animator anim;

    void Start()
    {
        player = null;
        beenSavedAt = false;
        active = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (active)
        {
            if (player.gameObject.GetComponent<Land_Movement>().getVelocity().y == 0)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    anim.SetTrigger("BeingSavedAt");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().name == "Player")
        {
            player = col;
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().name == "Player")
        {
            player = null;
            active = false;
        }
    }

    public Boolean getBeenSavedAt()
    {
        return beenSavedAt;
    }

    public void setBeenSavedAt(Boolean newVal)
    {
        beenSavedAt = newVal;
    }
}
