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
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBeen < wait)
        {
            hasBeen = Time.time - startTime;
        }
        else
        {
            if (!pushed)
            {
                transform.Translate(Vector3.up * speedOut * Time.deltaTime);
                howLong++;
                if(howLong > 60)
                {
                    pushed = true;
                    howLong = 0;
                }
            }
            else if(pushed)
            {
                transform.Translate(Vector3.up * -speedIn * Time.deltaTime);
                howLong++;
                if(howLong > 120)
                {
                    pushed = false;
                    howLong = 0;
                }
            }
        }
    }
}
