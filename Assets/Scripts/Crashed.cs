using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crashed : MonoBehaviour
{
    // [SerializeField] gameObject destroyFuel;
    [SerializeField] float delayedTime= 1f;
    [SerializeField] AudioClip crashedSound;
    [SerializeField] AudioClip succesSound;
    [SerializeField] gameObject deathObject;
    bool isTransitioning = false;
    Rocket myrocket;
    AudioSource myaudio;
    void Start() {
        myrocket = GetComponent<Rocket>();
        myaudio = GetComponent<AudioSource>();

    }
    // void DestroyObjectDelayed() {
    //     Destroy(gameObject, delayedTime);
    // }
    void OnCollisionEnter(Collision other) {
        string tagName = other.gameObject.tag;
        if (isTransitioning){ return; }
        switch (tagName)
        {
            case "Start":
                Debug.Log("Lets start the game");
                break;
            case "Finish":
                Succes();
                break; 
            case "Fuel":
                Debug.Log("You picked up fuel");
                // DestroyObjectDelayed();
                break;
            default:
                GameOver();
                break;

        }
    }
    void NextScene(){
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = indexScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    void LoadAgainTheScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene);
    }
    void Succes()
    {
        isTransitioning = true;
        myaudio.Stop();
        Invoke("NextScene", delayedTime);
        myrocket.enabled = false;
        myaudio.PlayOneShot(succesSound);
       
    }
    void GameOver()
    {
        isTransitioning= true;
        myaudio.Stop();
        Invoke("LoadAgainTheScene", delayedTime);
        myaudio.PlayOneShot(crashedSound);
        myrocket.enabled = false;
        
        
    }
}
