using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code adapted from https://www.youtube.com/watch?v=7JjzhhC06xw
public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    public CameraBoundary boundary;


    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // camera start position
        Vector3 startPos = transform.position;

        // player current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.leftLimit, boundary.rightLimit),
            Mathf.Clamp(transform.position.y, boundary.bottomLimit, boundary.topLimit),
            transform.position.z
            );
    }
}
