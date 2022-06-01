using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float speedRocket = 2f;
    [SerializeField] float speedRotation = 5f;
    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem rocketLeftParticles;
    [SerializeField] ParticleSystem rocketRightParticles;
    [SerializeField] ParticleSystem rocketJetParticles;
    Rigidbody myrg;
    AudioSource myaudio;
    // Start is called before the first frame update
    void Start()
    {
        myrg = GetComponent<Rigidbody>();
        myaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMovement();
        ObjectPosition();
    }
    void ObjectMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // myrg.AddRelativeForce(Vector3.up); // Vector3.up means it changes Vector3 position only for y(0, 1, 0)
           FlyingRocket();
        }
        else
        {
            myaudio.Stop();
            rocketJetParticles.Stop();
            
        }

    }
    void FlyingRocket(){
            myrg.AddRelativeForce(0, speedRocket * Time.deltaTime, 0);
            if (!myaudio.isPlaying)
            {
                myaudio.PlayOneShot(engineSound);
                
            }
            if (!rocketJetParticles.isPlaying)
            {
                rocketJetParticles.Play();
            }
    }
    void ObjectPosition()
    {
        if (Input.GetKey(KeyCode.A))
        {
            TurningToLeft();         
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurningToRight();
        }
        else {
            rocketLeftParticles.Stop();
            rocketRightParticles.Stop();
        }
    }
    void TurningToLeft()
    {
        ChangeRotation(speedRotation);
        if (!rocketLeftParticles.isPlaying)
        {
            rocketLeftParticles.Play();
        }
    }
    void TurningToRight()
    {
        ChangeRotation(-speedRotation);
        if (!rocketRightParticles.isPlaying)
        {
            rocketRightParticles.Play();
        }
    }

    void ChangeRotation(float wayRotation)
    {
        myrg.freezeRotation = true;
        transform.Rotate(Vector3.forward * wayRotation * Time.deltaTime);
        myrg.freezeRotation = false;
    }


}
