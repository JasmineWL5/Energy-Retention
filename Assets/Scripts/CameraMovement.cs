using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
		//public GameObject player;       //Public variable to store a reference to the player game object
	public Transform target;
	public float smoothTime = 0F;
	public float posY;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private Vector3 velocity = Vector3.zero;

	void Update (){
		Vector3 targetPosition = target.TransformPoint (new Vector3 (0, posY, -50));
		Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		transform.position = new Vector3 (Mathf.Clamp (desiredPosition.x,minX,maxX), Mathf.Clamp (desiredPosition.y,minY,maxY), desiredPosition.z);
	}
}
		//private Vector3 offset;

			//Private variable to store the offset distance between the player and camera
			//void Start () 
		//{
			//Calculate and store the offset value by getting the distance between the player's position and camera's position.
			//offset = transform.position - player.transform.position;
		//}

		// LateUpdate is called after Update each frame
		//void LateUpdate () 
		//{
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		//	transform.position = player.transform.position + offset;
		//}
	//}
