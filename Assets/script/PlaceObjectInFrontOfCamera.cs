using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceObjectInFrontOfCamera : MonoBehaviour
{
    public ARCameraManager arCameraManager;
    public GameObject objectToPlace;

    // public floorPlacementController ground;

    bool spawned = false;

    public float distanceFromCamera = 1.0f;

    void Update()
    {
        if (floorPlacementController.isAlreadyPlaced && !spawned)
        {
            if (arCameraManager != null)
            {
                if (arCameraManager.TryGetIntrinsics(out var cameraParams))
                {
                    if (Camera.main != null)
                    {
                        Vector3 cameraPosition = Camera.main.transform.position;
                        Vector3 cameraForward = Camera.main.transform.forward;

                        // Adjust the position of the object in front of the camera.
                        objectToPlace.transform.position = cameraPosition + cameraForward * distanceFromCamera;
                    }
                }
            }
            spawned = true;

        }
    }
}
