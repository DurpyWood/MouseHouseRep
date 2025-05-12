using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingingBalls : MonoBehaviour
{
    public float speed = 100f;
    private bool right = true;
    private float amountRotate = 0f;
    public int waitTime;
    private float startTime;
    private float timePassed = 0;
    private float speedMax;
    void Start()
    {
        speedMax = speed;
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

            if ( 0<speed<speedMax && right)
            {
                speed -= 3;
            }
            else if(speed == 0 && right)
            {

            }

            if (amountRotate == 100)  //checks to see if the rotation needs to be flipped
            {
                right = false;
            }
            else if (amountRotate == -100)
            {
                right = true;
            }
        }
        
        
    }
}
