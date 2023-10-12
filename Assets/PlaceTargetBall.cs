using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTargetBall : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        FindTheClosestBall.ThrowObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
