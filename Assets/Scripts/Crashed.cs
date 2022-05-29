using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crashed : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("You touch to Obstacle");
        }
    }
}
