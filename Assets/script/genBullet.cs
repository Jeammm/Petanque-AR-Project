using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectThrower : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] float throwForce = 5f;
    private ARRaycastManager arRaycastManager;
    private Camera arCamera;
    private bool canThrow = true;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0 && canThrow)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(ThrowObject());
            }
        }
    }

    IEnumerator ThrowObject()
    {
        canThrow = false;

        // Create a new object instance at the camera's position
        GameObject newObject = Instantiate(objectPrefab, new Vector3(arCamera.transform.position.x, arCamera.transform.position.y - 1, arCamera.transform.position.z), Quaternion.identity);

        // Get the forward direction of the camera
        Vector3 throwDirection = arCamera.transform.forward;

        // Apply force to the object in the direction of the camera
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Wait for a moment before allowing another throw
        yield return new WaitForSeconds(1.0f);
        canThrow = true;
    }
}
