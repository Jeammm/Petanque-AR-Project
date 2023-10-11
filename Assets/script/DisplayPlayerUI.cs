using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public floorPlacementController ground;
    private GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.Find("playerUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.isAlreadyPlaced) {
            Canvas.SetActive(true);
        }
    }
}
