using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyBall : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Rigidbody BallInArrayrigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SlippyPower.State == 1)
        {
            //Turn into SlippyFloor
            if (rigidbody != null)
            {
                rigidbody.angularDrag = 0.00001f;
                rigidbody.drag = 1;
                for (int i = 0; i < FindTheClosestBall.ballCount; i++) 
                {
                    BallInArrayrigidbody = FindTheClosestBall.thrownObjects[i].GetComponent<Rigidbody>();
                    BallInArrayrigidbody.angularDrag = 0.00001f;
                    BallInArrayrigidbody.drag = 1;
                }
            }
            else
            {
                // StateText.text = "No MeshCollider component";
                Debug.LogError("No MeshCollider component found on GroundPrefab.");
            }
        }
        else
        {
            //Bring the normal Floor back
            if (rigidbody != null)
            {
                rigidbody.angularDrag = 10;
                rigidbody.drag = 2;
                for (int i = 0; i < FindTheClosestBall.ballCount; i++) 
                {
                    BallInArrayrigidbody = FindTheClosestBall.thrownObjects[i].GetComponent<Rigidbody>();
                    BallInArrayrigidbody.angularDrag = 10;
                    BallInArrayrigidbody.drag = 2;
                }
            }
            else
            {
                // StateText.text = "No MeshCollider component";
                Debug.LogError("No MeshCollider component found on GroundPrefab.");
            }
        }
    }
}