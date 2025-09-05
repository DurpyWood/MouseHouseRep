using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistons : MonoBehaviour
{
    public float wait = 0f;// how long it takes for the piston to move (makes them move after eachother)
    public float beforeStart = 10f; //how long the pistons should wait before the next cycle
    private int speedOut = 10;
    private int speedIn = 5;
    public int time = 1;
    public float startTime;
    private float hasBeen = 0;
    private bool pushed = false;
    private bool setTime = false; // needed a way to set the start time without some weird work around
    public float howLong = 0; //for the waiting period
    public bool lastOne = false;
    public bool resetTime = false;
    public static bool allDone = false;
    public static int allReady = 0;
    public static int allReadyOut = 0;
    private bool stillMoving = false;
    public GameObject refrancePoint;
    public GameObject outreferancePoint;
    private float refarnce;
    private float outReferance;
    
    void Start()
    {
        startTime = Time.time;
        refarnce = refrancePoint.transform.position.z;
        outReferance = outreferancePoint.transform.position.z;

    }


    void Update()
    {
        if(hasBeen < wait)
        {
            hasBeen = Time.time - startTime;
            allReady = 0;
        }
        else
        {
            if (!pushed)
            {
                if (resetTime)
                {
                    if (!setTime)
                    {
                        startTime = Time.time;
                        setTime = true;
                        howLong = Time.time - startTime;
                    }
                    else
                    {
                        if (howLong < beforeStart)
                        {
                            howLong = Time.time - startTime;
                        }
                        else
                        {
                            resetTime = false;
                        }

                    }
                    
                }
                else if (!resetTime)
                {
                    stillMoving = true;
                    transform.Translate(Vector3.up * speedOut * Time.deltaTime);
                }

                if (outReferance >= transform.position.z)
                {
                    pushed = true;
                    allReady = 0;
                    allDone = false;
                    resetTime = true;
                    setTime = false;
                }
            }
            else if(pushed)
            {
                if (allDone)
                {
                    if (stillMoving)
                    {
                        transform.Translate(Vector3.up * -speedIn * Time.deltaTime);
                    }

                    if (transform.position.z >= refarnce && stillMoving == true)
                    {
                        allReady++;
                        stillMoving = false;
                    }
                    if (allReady == 6)
                    {
                        pushed = false;
                        startTime = Time.time;
                        startTime = Time.time;
                        hasBeen = startTime - Time.time;
                    }
                }
                else if (lastOne)
                {
                    allDone = true;
                }
                
            }
        }
    }
}
