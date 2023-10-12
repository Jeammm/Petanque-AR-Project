using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCount : MonoBehaviour
{
    [SerializeField]
    public static TextMeshProUGUI BallLeftCount;
    // Start is called before the first frame update

    void Start()
    {
        BallLeftCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void UpdateBallLeft()
    {
        if (FindTheClosestBall.playerNumber == 1)
        {
            BallLeftCount.text = "Ball left: " + PlayerInventory.Player1_BallLeft;
        }
        else
        {
            BallLeftCount.text = "Ball left: " + PlayerInventory.Player2_BallLeft;
        }
    }

}
