using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Camera : MonoBehaviour
{
    Player player;
    Camera camera;
    CameraFollow2D cameraScript;

    /// <summary>
    /// Require that the player be on the ground for the trigger to go off.
    /// </summary>
    [SerializeField]
    bool RequirePlayerGrounded;

    [SerializeField]
    CameraBoundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        camera = Camera.main;
        cameraScript = camera.GetComponent<CameraFollow2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TriggerWithOptionGrounded(col);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        TriggerWithOptionGrounded(col);
    }
    /// <summary>
    /// Trigger a new camera view.
    /// </summary>
    /// <param name="col"></param>
    void TriggerWithOptionGrounded(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (!RequirePlayerGrounded || (RequirePlayerGrounded && player.getGrounded()))
            {
                // Set new camera boundary
                cameraScript.boundary = boundary;
                //Debug.Log("I AM the senate.");
            }
            //else Debug.Log("Not yet.");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.lossyScale);
    }
}
