using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StealOpponentPower : MonoBehaviour
{
    private int PowerCount = 0;
    private int PowerStealNum;
    private List<int> PowerNum = new List<int>();
    private int UserNumber;
    public TextMeshProUGUI NoPowerToStealText;
    // Start is called before the first frame update
    public void StealPower() {
        if (FindTheClosestBall.playerNumber == 1)
        {
            UserNumber = 1;
            for(int i=0; i<5; i++)
            {
                if (PlayerInventory.Player2_inv[i])
                {
                    PowerCount++; //Check the number of power opponent have
                    PowerNum.Add(i);
                }
            }
            //check if opponent has no power
            if(PowerCount == 0) {
                NoPowerToStealText.text = "Opponet has no power to be stolen.";
                return;
            }

            PowerStealNum = Random.Range(0, PowerCount); //the power index to steal
            PlayerInventory.Player2_inv[PowerNum[PowerStealNum]] = false; //inactive opponent power
            PlayerInventory.Player1_inv[2] = false;
            PlayerInventory.Player1_inv[PowerNum[PowerStealNum]] = true; //Active my power
        }
        else
        {
            UserNumber = 2;
            for(int i=0; i<5; i++)
            {
                if (PlayerInventory.Player1_inv[i])
                {
                    PowerCount++; //Check the number of power opponent have
                    PowerNum.Add(i);
                }
            }

            if(PowerCount == 0) {
                NoPowerToStealText.text = "Opponet has no power to be stolen.";
                return;
            }

            PowerStealNum = Random.Range(0, PowerCount); //the power index to steal
            PlayerInventory.Player1_inv[PowerNum[PowerStealNum]] = false; //inactive opponent power
            PlayerInventory.Player2_inv[2] = false;
            PlayerInventory.Player2_inv[PowerNum[PowerStealNum]] = true; //Active my power
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UserNumber != FindTheClosestBall.playerNumber)
        {
            NoPowerToStealText.text = "";
        }
    }
}
