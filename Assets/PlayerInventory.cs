using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour

{
    [SerializeField]
    public TextMeshProUGUI InventoryText;
    public static bool[] Player1_inv = { false, false, false, false, false };
    public static bool[] Player2_inv = { false, false, false, false, false };

    public static int Player1_BallLeft = 5;
    public static int Player2_BallLeft = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FindTheClosestBall.playerNumber == 1)
        {
            InventoryText.text = string.Join(", ", PlayerInventory.Player1_inv);
        }
        else
        {
            InventoryText.text = string.Join(", ", PlayerInventory.Player2_inv);
        }
    }

    public static void AddToInventory(string Item, string player)
    {
        int ItemNumber = int.Parse(Item);
        if (player == "player_1")
        {
            PlayerInventory.Player1_inv[ItemNumber] = true;
        }
        else
        {
            PlayerInventory.Player2_inv[ItemNumber] = true;
        }
    }
}
