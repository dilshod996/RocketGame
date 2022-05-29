using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float speedRocket = 2f;
    [SerializeField] float speedRotation = 5f;
    Rigidbody myrg;
    // Start is called before the first frame update
    void Start()
    {
        myrg = GetComponent<Rigidbody>();
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
            myrg.AddRelativeForce(0, speedRocket * Time.deltaTime, 0);
 
        }

    }
    void ObjectPosition()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ChangeRotation(speedRotation);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ChangeRotation(-speedRotation);

        }
    }

    void ChangeRotation(float wayRotation)
    {
        myrg.freezeRotation = true;
        transform.Rotate(Vector3.forward * wayRotation * Time.deltaTime);
        myrg.freezeRotation = false;
    }
}
