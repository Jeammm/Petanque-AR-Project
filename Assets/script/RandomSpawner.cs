using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject cubePrefeb;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 currectPosition = gameObject.transform.position;
        for (int i = 0; i < 5; i++)
        {
            int ranX = Random.Range(1, 4);
            int ranZ = Random.Range(1, 4);

            Vector3 randomSpawnPosition = new Vector3(currectPosition.x + ranX, currectPosition.y + 2.5f, currectPosition.z + ranZ);
            GameObject newCube = Instantiate(cubePrefeb, randomSpawnPosition, Quaternion.identity);
            newCube.name = i.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
