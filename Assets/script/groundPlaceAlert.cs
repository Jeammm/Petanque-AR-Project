using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPlaceAlert : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject UI;

    // public floorPlacementController ground;
    // Start is called before the first frame update
    void Start()
    {   
        Canvas = GameObject.Find("PlaceGroundJa");
        UI = GameObject.Find("playerUI");
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (floorPlacementController.isAlreadyPlaced) {
            Canvas.SetActive(false);
            UI.SetActive(true);
        }
    }
}
