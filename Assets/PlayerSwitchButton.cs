using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSwitchButton : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI PlayerTurnBanner;
    [SerializeField]
    public TextMeshProUGUI TurnCountBanner;

    void Start()
    {

    }

    public void IsPressed()
    {
        FindTheClosestBall.ThrownThisTurn = false;

        if (FindTheClosestBall.GameEnded)
        {
            Debug.Log("Game ended");
            return;
        }


        if (FindTheClosestBall.playerNumber == 1)
        {
            if (PlayerInventory.Player2_BallLeft == 0)
            {
                FindTheClosestBall.GameEnded = true;
                return;
            }
            FindTheClosestBall.playerNumber = 2;
        }
        else
        {
            if (PlayerInventory.Player1_BallLeft == 0)
            {
                FindTheClosestBall.GameEnded = true;
                return;
            }
            FindTheClosestBall.playerNumber = 1;
        }

        FindTheClosestBall.TurnCount++;
        BallCount.UpdateBallLeft();
    }

    void Update()
    {
        if (!FindTheClosestBall.GameEnded)
        {
            TurnCountBanner.text = "Turn " + FindTheClosestBall.TurnCount;
            PlayerTurnBanner.text = "Player " + FindTheClosestBall.playerNumber;
            return;
        }
        if (FindTheClosestBall.GameEnded && !FindTheClosestBall.WinnerDeclared)
        {
            PlayerTurnBanner.text = "Calculating...";

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
                print("Done here");
                FindTheClosestBall.FindClosestObjectToFirstBall();
                PlayerTurnBanner.text = "Player " + FindTheClosestBall.winner + " win!!!";
            }
        }
    }
}
