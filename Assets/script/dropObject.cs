using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class dropObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool powerActivated = false;

    [SerializeField]
    public GameObject objectToFall;

    public void ActivatePower()
    {
        powerActivated = true;
        if (FindTheClosestBall.playerNumber == 1)
        {
            PlayerInventory.Player1_inv[1] = false;
        }
        else
        {
            PlayerInventory.Player2_inv[1] = false;
        }
    }

    private void Update()
    {
        if (powerActivated && Input.touchCount > 0)
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
                    GameObject newObjectToFall = Instantiate(objectToFall, touchPosition, Quaternion.identity);
                    Rigidbody rb = newObjectToFall.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    powerActivated = false;
                }
            }
        }
    }
}