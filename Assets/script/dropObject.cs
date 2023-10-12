using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class dropObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool notused = true;
    private bool powerActivated = false;

    [SerializeField] GameObject objectToFall;

    public void ActivatePower() {
        powerActivated = true;
    }

    private void Update()
    {   
        if (powerActivated && Input.touchCount > 0 && notused)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 touchPosition = hit.point;
                    touchPosition.y += 7.0f;

                    // Instantiate the object at the touch position
                    GameObject newObjectToFall =  Instantiate(objectToFall, touchPosition,Quaternion.identity);
                    Rigidbody rb = newObjectToFall.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    notused=false;
                }
            }
        }
    }
}
