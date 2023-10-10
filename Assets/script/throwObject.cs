using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float throwForce = 5.0f;

    private bool isThrown = false;
    private Vector3 initialPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check if the object is not thrown and the screen is touched.
        if (!isThrown && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Throw();
        }
    }

    void Throw()
    {
        // Detach the object from its parent (if any).
        transform.parent = null;

        // Calculate the throw direction based on the touch position.
        Vector3 throwDirection = Camera.main.transform.forward;

        // Apply force to the rigidbody to throw the object.
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Mark the object as thrown.
        isThrown = true;
    }

    // Reset the object to its initial position when needed.
    public void ResetObject()
    {
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isThrown = false;
    }
}
