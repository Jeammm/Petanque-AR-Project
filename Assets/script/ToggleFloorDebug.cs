using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFloorDebug : MonoBehaviour
{
    public bool IsFloorPlaceToggleDebug;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsFloorPlaceToggleDebug)
        {
            floorPlacementController.isAlreadyPlaced = true;

        }
    }
}
