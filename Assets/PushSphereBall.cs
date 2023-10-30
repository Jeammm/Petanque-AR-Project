using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PushSphereBall : MonoBehaviour
{
    private bool PowerActivated = false;
    private bool DonePushing = false;

    public float pushForce = 4f;
    public float pushRadius = 2f;

    public TextMeshProUGUI WarningText;

    public void UsePushSpherePower()
    {
        if (FindTheClosestBall.ThrownThisTurn)
        {
            WarningText.text = "You can use Push Sphere Ball on the next turn.";
            return;
        }
        PowerActivated = true;
        if (FindTheClosestBall.playerNumber == 1)
        {
            PlayerInventory.Player1_inv[4] = false;
        }
        else
        {
            PlayerInventory.Player2_inv[4] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerActivated && FindTheClosestBall.ThrownThisTurn && !DonePushing)
        {
            bool allStopped = true;
            foreach (GameObject go in FindTheClosestBall.thrownObjects)
            {
                Rigidbody rb = go.GetComponent<Rigidbody>();

                if (rb != null && rb.velocity.magnitude > 0.01f)
                {
                    allStopped = false;
                    return;
                    // break; // No need to continue checking if one is moving
                }
            }
            if (allStopped)
            {
                GameObject currentBall = FindTheClosestBall.thrownObjects[FindTheClosestBall.ballCount - 1];
                Collider[] hitColliders = Physics.OverlapSphere(currentBall.transform.position, pushRadius);
                foreach (Collider po in hitColliders){
                    if (po.gameObject != gameObject)
                    {
                        if (po.gameObject.CompareTag("Target Ball")) {
                            continue;
                        }

                        // Calculate the direction from the pusher to the pushed object.
                        Vector3 PushPosition = po.transform.position - currentBall.transform.position;
                        // PushPosition.y+=0.05f;
                        Vector3 direction = (PushPosition).normalized;
                        direction.y+=1f;
                        Vector3 velocity = direction*pushForce;
                        // Apply the force to the pushed object's Rigidbody.
                        Rigidbody rb = po.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                        //rb.AddForce(direction * pushForce, ForceMode.Force);
                        rb.velocity = velocity;
                        }
                    }
                }

                DonePushing = true;
            }
        }
    }
}