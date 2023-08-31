using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidMovement : MonoBehaviour
{

    private Vector3 startPos = new Vector3(0, 0, 0);
    private Vector3 endPos = new Vector3(0, -4, 0);
    private float speed = 2f;
    private float startTime;
    private float journeyLength;
    private bool movingToEnd = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
    }

    void Update()
    {
        float journeyTime = (Time.time - startTime) * speed;
        float fractionOfJourney = journeyTime / journeyLength;
        
        if (movingToEnd)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, fractionOfJourney);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(endPos, startPos, fractionOfJourney);
        }

        if (fractionOfJourney >= 1)
        {
            movingToEnd = !movingToEnd;
            startTime = Time.time;
        }
    }
}
