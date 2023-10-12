using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour

{
    [SerializeField]
    public TextMeshProUGUI InventoryText;
    public static bool[] Player1_inv = { false, false, false, false, false };
    public static bool[] Player2_inv = { false, false, false, false, false };

    [SerializeField]
    public GameObject SlipperyButton;
    [SerializeField]
    public GameObject SummonItemButton;
    [SerializeField]
    public GameObject Power3Button;
    [SerializeField]
    public GameObject Power4Button;
    [SerializeField]
    public GameObject Power5Button;

    public static Button slipperyButton;
    public static Button summonItemButton;
    public static Button power3Button;
    public static Button power4Button;
    public static Button power5Button;

    public static int Player1_BallLeft = 5;
    public static int Player2_BallLeft = 5;
    // Start is called before the first frame update
    void Start()
    {
        slipperyButton = SlipperyButton.GetComponent<Button>();
        summonItemButton = SummonItemButton.GetComponent<Button>();
        power3Button = Power3Button.GetComponent<Button>();
        power4Button = Power4Button.GetComponent<Button>();
        power5Button = Power5Button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindTheClosestBall.playerNumber == 1)
        {
            // InventoryText.text = string.Join(", ", PlayerInventory.Player1_inv);
            slipperyButton.interactable = PlayerInventory.Player1_inv[0];
            summonItemButton.interactable = PlayerInventory.Player1_inv[1];
            power3Button.interactable = PlayerInventory.Player1_inv[2];
            power4Button.interactable = PlayerInventory.Player1_inv[3];
            power5Button.interactable = PlayerInventory.Player1_inv[4];
        }
        else
        {
            // InventoryText.text = string.Join(", ", PlayerInventory.Player2_inv);
            slipperyButton.interactable = PlayerInventory.Player2_inv[0];
            summonItemButton.interactable = PlayerInventory.Player2_inv[1];
            power3Button.interactable = PlayerInventory.Player2_inv[2];
            power4Button.interactable = PlayerInventory.Player2_inv[3];
            power5Button.interactable = PlayerInventory.Player2_inv[4];
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
