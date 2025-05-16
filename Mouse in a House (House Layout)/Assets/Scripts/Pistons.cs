using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistons : MonoBehaviour
{
    public float wait = 0f;
    private int speedOut = 10;
    private int speedIn = 5;
    public int time = 1;
    public float startTime;
    private float hasBeen = 0;
    private bool pushed = false;
    public int howLong = 0;
    public bool lastOne = false;
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

    // Update is called once per frame
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
                
                stillMoving = true;
                transform.Translate(Vector3.up * speedOut * Time.deltaTime);
                if(outReferance >= transform.position.z)
                {
                    pushed = true;
                    allReady = 0;  
                    allDone = false;           
                }
            }
            else if(pushed)
            {
                if(allDone)
                {
                    if(stillMoving)
                    {
                        transform.Translate(Vector3.up * -speedIn * Time.deltaTime);
                    }
                    
                    if(transform.position.z >= refarnce && stillMoving == true)
                    {
                        allReady++;
                        stillMoving = false;
                    }
                    if(allReady == 6)
                    {
                        pushed = false;
                        startTime = Time.time;
                        hasBeen = startTime - Time.time;
                    }
                }
                else if(lastOne)
                {
                    allDone = true;
                }
                
            }
        }
    }
}
