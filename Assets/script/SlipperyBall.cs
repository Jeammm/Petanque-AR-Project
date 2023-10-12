using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyBall : MonoBehaviour
{
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SlippyPower.State == 1) {
            //Turn into SlippyFloor
            if (rigidbody != null) {
                rigidbody.angularDrag = 0.00001f;
                rigidbody.drag = 1;
            } 
            else {
                // StateText.text = "No MeshCollider component";
                Debug.LogError("No MeshCollider component found on GroundPrefab.");
            }
        }
        else {
            //Bring the normal Floor back
            if (rigidbody != null) {
                rigidbody.angularDrag = 10;
                rigidbody.drag = 2;
            } 
            else {
                // StateText.text = "No MeshCollider component";
                Debug.LogError("No MeshCollider component found on GroundPrefab.");
            }
        }
    }
}
