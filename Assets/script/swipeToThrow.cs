using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SwipeScript : MonoBehaviour
{
	private ARRaycastManager arRaycastManager;
	private Camera arCamera;
	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForce = 5000f; // to control throw force in X and Y directions

	[SerializeField] GameObject objectToThrow;
	// public floorPlacementController ground;

	void Start()
	{
		arRaycastManager = FindObjectOfType<ARRaycastManager>();
		arCamera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{

		if (!floorPlacementController.isAlreadyPlaced || FindTheClosestBall.GameEnded)
		{
			return;
		}
		// if you touch the screen
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{

			// getting touch position and marking time when you touch the screen
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;
		}

		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{

			// marking time when you release it
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			endPos = Input.GetTouch(0).position;

			// calculating swipe direction in 2D space
			direction = endPos - startPos;
			float len = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

			if (timeInterval < 0.1 || len < 200)
			{
				return;
			}
			if (FindTheClosestBall.ThrownThisTurn)
			{
				return;
			}

			if (!HasBallLeft())
			{
				return;
			}

			GameObject newObject = Instantiate(objectToThrow, arCamera.transform.position, Quaternion.identity);
			newObject.name = "player_" + FindTheClosestBall.playerNumber;
			Rigidbody rb = newObject.GetComponent<Rigidbody>();

			// Calculate the tilt angle based on the left or right swipe
			float tiltAngleX = 0.0f;

			if (direction.x != 0)
			{
				tiltAngleX = 0.5f * (Mathf.Sign(direction.x) * Mathf.Atan(Mathf.Abs(direction.x) / direction.y)) * 180 / (Mathf.PI);
			}
			// tiltAngleY = direction.y * 15.0f;

			// Create a rotation quaternion to tilt the vector
			Quaternion tiltRotation = Quaternion.Euler(-45, tiltAngleX, 0);

			// Calculate the throwDirection and apply the tilt
			Vector3 throwDirection = arCamera.transform.forward;
			Vector3 tiltedDirection = tiltRotation * throwDirection;

			// Add force to the ball's rigidbody based on the tilted direction and swipe time
			if (rb)
			{
				rb.isKinematic = false;
				rb.AddForce(tiltedDirection * throwForce * (len / timeInterval));
			}

			// Destroy ball in 4 seconds
			// Destroy (gameObject, 3f);

		}

	}

	bool HasBallLeft()
	{
		if (FindTheClosestBall.playerNumber == 1)
		{
			if (PlayerInventory.Player1_BallLeft == 0)
			{
				return false;
			}
			PlayerInventory.Player1_BallLeft--;
		}
		else
		{
			if (PlayerInventory.Player2_BallLeft == 0)
			{
				return false;
			}
			PlayerInventory.Player2_BallLeft--;
		}
		return true;
	}
}
