using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f; //it calculates speed of object

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }//Epsilon stands for tiny number near to Zero
        float onCycles = Time.time / period;
        const float tau = (float)(Math.PI * 2f); // it means 2 p which is greek alphabetical hyroglif 2p = 360
        float rawSinWave = (float)Math.Sin(onCycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f; //rawSinWave moves between 0  and 1 for this reason I add one
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}
