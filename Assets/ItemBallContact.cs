using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBallContact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Player Ball" tag
        if (collision.gameObject.CompareTag("Player Ball"))
        {
            // Destroy the current game object
            Destroy(gameObject);
        }
    }
}
