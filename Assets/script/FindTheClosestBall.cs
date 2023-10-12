using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindTheClosestBall : MonoBehaviour
{
    public static List<GameObject> thrownObjects = new List<GameObject>(); // Use a List to dynamically add objects

    [SerializeField]
    public TextMeshProUGUI numberText;

    [SerializeField]
    public TextMeshProUGUI playerIndicator;

    public static bool GameEnded = false;

    public static bool WinnerDeclared = false;

    public static int ballCount = 0;

    public static int TurnCount = 1;
    public static int playerNumber = 1;

    public static int winner = 0;

    public static bool ThrownThisTurn = false;

    // Add this function to initialize the array
    private void Start()
    {
        thrownObjects.Clear(); // Clear the list at the start
    }

    public static void ThrowObject(GameObject objectToThrow)
    {
        // Debug.Log("Ball Count: " + ballCount);

        thrownObjects.Add(objectToThrow); // Add the object to the list
        ballCount = thrownObjects.Count; // Update ballCount using the list size
        BallCount.UpdateBallLeft();
    }

    public static void FindClosestObjectToFirstBall()
    {
        GameObject firstBall = thrownObjects[0];
        float closestDistance = Vector3.Distance(firstBall.transform.position, thrownObjects[1].transform.position);
        int closestObject = 1;

        for (int i = 2; i < ballCount; i++)
        {
            float distance = Vector3.Distance(firstBall.transform.position, thrownObjects[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = i;
            }
        }
        winner = 2 - (closestObject % 2);
        WinnerDeclared = true;


        // numberText.text = "Player " + winner + " win!!!";
    }


}
