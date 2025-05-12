using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sillymode : MonoBehaviour
{
    public float speed = 100f;
    private bool right = true;
    private float amountRotate = 0f;
    public int waitTime;
    private float startTime;
    private float timePassed = 0;

    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if(timePassed < waitTime)
        {
            timePassed = Time.time - startTime; // makes the balls wait a little
        }
        else
        {
            if(right) // how it rotates
            {
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                amountRotate += 1;
            }
            else if(!right)
            {
                transform.Rotate(Vector3.up * -speed * Time.deltaTime);
                amountRotate -= 1;
            }

            if(right && amountRotate > 0) // simulates force/gravity
            {
                speed -= 3;
            }
            else if(!right && amountRotate > 0)
            {
                speed += 3;
            }
            else if(!right && amountRotate < 0)
            {
                speed -= 3;
            }
            else if(right && amountRotate < 0)
            {
                speed += 3;
            }

            if (amountRotate == 200)  //checks to see if the rotation needs to be flipped
            {
                right = false;
            }
            else if (amountRotate == -200)
            {
                right = true;
            }
        }
        
        
    }
}