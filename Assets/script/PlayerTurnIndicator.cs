using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnIndicator : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI PlayerTurnBanner;

    [SerializeField]
    public TextMeshProUGUI TurnCountBanner;

    public Material PlayerMat1;
    public Material PlayerMat2;
    public Material Mat3;

    CanvasRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindTheClosestBall.GameEnded)
        {
            if (renderer != null)
            {
                if (FindTheClosestBall.playerNumber == 1)
                {
                    renderer.SetMaterial(PlayerMat1, 0);
                }
                else
                {
                    renderer.SetMaterial(PlayerMat2, 0);
                }
            }
        }
        else if (!FindTheClosestBall.WinnerDeclared)
        {
            if (renderer != null)
            {
                renderer.SetMaterial(Mat3, 0);
            }
            TurnCountBanner.text = "";
        }
    }
}
