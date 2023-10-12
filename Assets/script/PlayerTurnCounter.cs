using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnCounter : MonoBehaviour
{
    // public static FindTheClosestBall Winner;

    // [SerializeField]
    // public static TextMeshProUGUI numberText;

    // [SerializeField]
    // public static TextMeshProUGUI playerIndicator;

    // private static GameObject UI;
    // public static int cnt = 1;
    // public static int playerNumber = 1;

    // public void IsPressed()
    // {
    //     if (Winner.GameEnded)
    //     {
    //         Debug.Log("Game ended");
    //         return;
    //     }
    //     cnt++;
    //     // if both players already threw 3 times, the game will stop.
    //     if (cnt == 4)
    //     {
    //         // UI.SetActive(false);
    //         Winner.FindClosestObjectToFirstBall();
    //         return;
    //     }
    //     numberText.text = "Turn " + cnt + "";
    // }

    // public static void ThrowBall()
    // {
    //     if (Winner.GameEnded)
    //     {
    //         Debug.Log("Game ended");
    //         return;
    //     }
    //     // if both players already threw 3 times, the game will stop.
    //     if (cnt == 4)
    //     {
    //         Winner.FindClosestObjectToFirstBall();
    //         return;
    //     }

    //     if (playerNumber == 1)
    //     {
    //         playerNumber = 2;
    //     }
    //     else
    //     {
    //         cnt++;
    //         playerNumber = 1;
    //     }

    // }

    // void Start()
    // {
    //     UI = GameObject.Find("playerUI");
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     playerIndicator.text = "Player " + playerNumber;
    //     numberText.text = "Turn " + cnt + "";
    // }
}

