using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terresquall;
using System;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private Rigidbody rigidBody;
    public int speed;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = VirtualJoystick.GetAxis("Horizontal") * speed;
        float z = VirtualJoystick.GetAxis("Vertical") * speed;
        Vector3 vector = new Vector3(x, 0f, z);

        // if we are moving joystick reset NavMesh path
        if (vector != Vector3.zero)
        {
            navMeshAgent.ResetPath();
        }
        rigidBody.velocity = vector;
        //rigidBody.AddForce(vector);
    }

    public void StopMovement()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.ResetPath();
        }
    }
}
