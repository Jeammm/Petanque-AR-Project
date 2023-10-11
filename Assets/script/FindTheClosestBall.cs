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

    public static int ballCount = 0;

    private static int cnt = 0;
    public static int playerNumber = 2;

    public static int winner = 0;

    // Add this function to initialize the array
    private void Start()
    {
        thrownObjects.Clear(); // Clear the list at the start
    }

    public static void ThrowObject(GameObject objectToThrow)
    {
        thrownObjects.Add(objectToThrow); // Add the object to the list
        ballCount = thrownObjects.Count; // Update ballCount using the list size
        Debug.Log("Ball Count: " + ballCount);

        if (playerNumber == 1)
        {
            playerNumber = 2;
        }
        else
        {
            cnt++;
            playerNumber = 1;
        }

        if (cnt == 4)
        {
            GameEnded = true;
        }
    }

    public static void FindClosestObjectToFirstBall()
    {
        if (ballCount < 2)
        {
            // If there are fewer than 2 objects, there's nothing to compare.
            return;
        }


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
        // numberText.text = "Player " + winner + " win!!!";
    }

    void Update()
    {

        if (GameEnded)
        {
            bool allStopped = true;

            foreach (GameObject go in thrownObjects)
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
                FindClosestObjectToFirstBall();
                Debug.Log("All rigid bodies are stopped.");
                // Do something here, like returning true or performing an action.
            }


            numberText.text = "Player " + winner + " win!!!";
            return;
        }
        numberText.text = "Turn " + cnt;
        playerIndicator.text = "Player " + playerNumber;
    }
}
