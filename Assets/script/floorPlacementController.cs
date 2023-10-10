using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class floorPlacementController : MonoBehaviour
{
    private GameObject spawnNew;

    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;

    public bool isAlreadyPlaced;

    [SerializeField]
    public GameObject objectToSpawn;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        isAlreadyPlaced = false;
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;

        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (!isAlreadyPlaced && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // Corrected variable name
        {
            if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                var hitPose = hits[0].pose;

                foreach (var plane in arPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                arPlaneManager.enabled = false;

                spawnNew = Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);

                isAlreadyPlaced = true;
            }
        }
    }
}
