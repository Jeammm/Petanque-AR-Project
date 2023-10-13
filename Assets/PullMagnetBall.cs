using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PullMagnetBall : MonoBehaviour
{
    private bool PowerActivated = false;
    private bool DonePulling = false;

    public float pullForce = 6.0f;

    public TextMeshProUGUI WarningText;

    public void UsePullMagnetPower()
    {
        if (FindTheClosestBall.ThrownThisTurn)
        {
            WarningText.text = "You can use Magnet Ball on the next turn.";
            return;
        }
        PowerActivated = true;
        if (FindTheClosestBall.playerNumber == 1)
        {
            PlayerInventory.Player1_inv[3] = false;
        }
        else
        {
            PlayerInventory.Player2_inv[3] = false;
        }
    }

    public void MoveTheBall()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PowerActivated && FindTheClosestBall.ThrownThisTurn && !DonePulling)
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
                GameObject target = FindTheClosestBall.thrownObjects[0];
                GameObject currentBall = FindTheClosestBall.thrownObjects[FindTheClosestBall.ballCount - 1];

                Vector3 direction = currentBall.transform.position - target.transform.position;

                direction.Normalize();

                // Calculate the velocity vector to apply to the target
                Vector3 velocity = direction * pullForce;

                // Apply the velocity to move the target towards the currentBall
                Rigidbody rb = target.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = velocity;
                    DonePulling = true;
                }
            }
        }
    }
}
