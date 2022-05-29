using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crashed : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        string tagName = other.gameObject.tag;
        switch (tagName)
        {
            case "Start":
                Debug.Log("Lets start the game");
                break;
            case "Finish":
                Debug.Log("You finished");   
                break; 
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                Debug.Log("Please dont touch me");
                break;

        }
    }
}
