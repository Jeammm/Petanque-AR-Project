using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool[] Player1_inv = { false, false, false, false, false };
    public static bool[] Player2_inv = { false, false, false, false, false };

    public static int Player1_BallLeft = 5;
    public static int Player2_BallLeft = 5;
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void AddToInventory(string Item)
    {
        int ItemNumber = int.Parse(Item);
        if (FindTheClosestBall.playerNumber == 1)
        {
            PlayerInventory.Player1_inv[ItemNumber] = true;
        }
        else
        {
            PlayerInventory.Player2_inv[ItemNumber] = true;
        }
    }
}
