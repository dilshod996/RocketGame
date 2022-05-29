using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crashed : MonoBehaviour
{
    // [SerializeField] gameObject destroyFuel;
    [SerializeField] float delayedTime= 1f;
    Rocket myrocket;
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
                ComingBackFirstSCene();  
                break; 
            case "Fuel":
                Debug.Log("You picked up fuel");
                // DestroyObjectDelayed();
                break;
            default:
                Debug.Log("Please dont touch me");
                Invoke("NextScene", delayedTime);
                GetComponent<Rocket>().enabled = false;
                GetComponent<AudioSource>().enabled = false;
                break;

        }
    }
    void ComingBackFirstSCene(){
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = indexScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    void NextScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene);
    }
}
