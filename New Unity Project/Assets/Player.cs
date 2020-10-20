using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private Land_Movement landMovement;
    private Respawn respawn;
    // Start is called before the first frame update
    void Start()
    {
        landMovement = gameObject.GetComponent<Land_Movement>();
        respawn = gameObject.GetComponent<Respawn>();
    }
}
