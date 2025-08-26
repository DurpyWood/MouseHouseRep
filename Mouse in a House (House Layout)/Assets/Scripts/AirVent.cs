using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    public bool inRange;
    public Transform playerCheck;
    public GameObject player;
    public float playerRadius = 0.55f;
    public LayerMask playerMask;
    public Vector3 velocity;

    void Update()
    {
        inRange = Physics.CheckSphere(playerCheck.position, playerRadius, playerMask);
        if(inRange == true)
        {
            velocity.y += 2.0f;
        }
    }
}
