using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlippyPower : MonoBehaviour
{
    // Start is called before the first frame update
    public static int State = 0; //Not activate power yet
    private int playerState = 2; //indicate when we should cancel power
    private int PowerUser;
    public TextMeshProUGUI StateText;
    public void UseSlippyPower() {
        PowerUser = FindTheClosestBall.playerNumber;
        playerState = 0;
        State = 1; //Activate power

        StateText.text = "State " + State;

    }
    public void CancelSlippyPower() {
        State = 0;
        StateText.text = "State " + State;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == 0) {
            if(FindTheClosestBall.playerNumber != PowerUser) {
                playerState = 1; //Now Opponent turn
                // StateText.text = "State " + playerState;
            }
        }
        if(playerState == 1) {
            if(FindTheClosestBall.playerNumber == PowerUser) {
                playerState = 2; //Now my turn
                CancelSlippyPower();
                // StateText.text = "State " + playerState;
            }
        }
    }
}
