using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
    // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position; 
    }

    void LateUpdate()
    {
    // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position + offset;  
    }
}
