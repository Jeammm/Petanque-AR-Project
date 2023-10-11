using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addToBallArray : MonoBehaviour
{
    public Material Mat1;
    public Material Mat2;

    // Start is called before the first frame update
    public void Start()
    {
        FindTheClosestBall.ThrowObject(gameObject);

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            if (FindTheClosestBall.playerNumber == 1)
            {
                renderer.material = Mat1;
            }
            else
            {
                renderer.material = Mat2;
            }
        }
        else
        {
            Debug.LogError("This GameObject does not have a Renderer component or playerMaterials is not set.");
        }
    }
}