using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // player
    //public Transform playerToFollow;

    // walls
    public Transform Firstwall;
    public Transform Lastwall;

    // camera rules
    public float Height;
    public float Zoom;
    public float max;
    public float min;

    void Start()
    {
        min = Firstwall.position.x + 15f;
        max = Lastwall.position.x - 15f;
    }

    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) 
        {
            // if players position > min and player position < max
            if (player.transform.position.x > min && player.transform.position.x < max)
            {
                // change camera's position = players position.x height.y zoom.z
                transform.position = new Vector3(player.transform.position.x, Height, Zoom);
            }
        }
    }
}
