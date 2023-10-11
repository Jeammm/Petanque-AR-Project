using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TextMeshProUGUI numberText;
    private GameObject UI;
    int cnt = 1; 
    public void IsPressed() {
        cnt++;
        // if both player already throw 3 times, the game will stop.
        if(cnt == 4) {
            UI.SetActive(false);
        }
        numberText.text = "Turn " + cnt + "";
    }
    void Start()
    {
        UI = GameObject.Find("playerUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
