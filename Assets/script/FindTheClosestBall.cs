using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheClosestBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] thrownObjects;

    public void ThrowObject(GameObject objectToThrow) {
        for (int i = 0; i < thrownObjects.Length; i++)
        {
            if (thrownObjects[i] == null)
            {
                thrownObjects[i] = objectToThrow;
                break;
            }
        }
    }

    public GameObject FindClosestObjectToFirstBall()
    {
        if (thrownObjects.Count < 2)
        {
            // If there's only one or zero objects, there's nothing to compare.
            return null;
        }

        GameObject firstBall = thrownObjects[0];
        float closestDistance = Vector3.Distance(firstBall.transform.position, thrownObjects[1].transform.position);
        GameObject closestObject = thrownObjects[1];

        for (int i = 2; i < thrownObjects.Count; i++)
        {
            float distance = Vector3.Distance(firstBall.transform.position, thrownObjects[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = thrownObjects[i];
            }
        }

        return closestObject;
    }
}
