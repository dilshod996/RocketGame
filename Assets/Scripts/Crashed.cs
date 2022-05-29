using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crashed : MonoBehaviour
{
    // [SerializeField] gameObject destroyFuel;
    // [SerializeField] float delayedTime= 1f;
    // void DestroyObjectDelayed() {
    //     Destroy(gameObject, delayedTime);
    // }
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
                // DestroyObjectDelayed();
                break;
            default:
                Debug.Log("Please dont touch me");
                SceneManager.LoadScene("StartScene");
                break;

        }
    }
}
