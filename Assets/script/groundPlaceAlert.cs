using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPlaceAlert : MonoBehaviour
{
    private GameObject Canvas;

    public floorPlacementController ground;
    // Start is called before the first frame update
    void Start()
    {   
        Canvas = GameObject.Find("PlaceGroundJa");
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.isAlreadyPlaced) {
            Canvas.SetActive(false);
        }
    }
}
