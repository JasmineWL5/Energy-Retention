using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
	bool inContact = false;
	bool startedAsTrigger;
	Collider2D collider;
	Rigidbody2D playerRigidbody;
	PlayerController playerController;
	Collider2D playerCollider;

	Ladder otherLadder;
	Collider2D otherLadderCollider;

	void Start() {
		collider = GetComponent<Collider2D> ();
		startedAsTrigger = collider.isTrigger;

		var playerGameobject = GameObject.FindGameObjectWithTag ("Player");
		playerRigidbody = playerGameobject.GetComponent<Rigidbody2D> ();
		playerController = playerGameobject.GetComponent<PlayerController> ();
		playerCollider = playerGameobject.GetComponent<Collider2D> ();

		var ladderGameObjects = GameObject.FindGameObjectsWithTag ("Ladder");
		foreach (var ladderGameObject in ladderGameObjects) {
			if (ladderGameObject != gameObject) {
				otherLadder = ladderGameObject.GetComponent<Ladder> ();
				otherLadderCollider = ladderGameObject.GetComponent<Collider2D> ();
				break;
			}
		}

	}

	void Update () {
		if (inContact && Input.GetAxis ("Interact") > 0) {
			Debug.Log ("Going down");

			collider.isTrigger = true;
			otherLadderCollider.isTrigger = true;

			playerRigidbody.velocity = Vector2.zero;
			playerRigidbody.gravityScale = 0;
			playerController.IsClimbingLadder = true;
		}
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("We are entering trigger", this);
		inContact = true;
	}

	void OnTriggerExit2D (Collider2D other) {
		Debug.Log ("We are leaving trigger", this);
		inContact = false;
	
		if (!playerCollider.IsTouching (otherLadderCollider)) {
			playerRigidbody.gravityScale = 1;
			playerController.IsClimbingLadder = false;

			collider.isTrigger = startedAsTrigger;
			otherLadderCollider.isTrigger = otherLadder.startedAsTrigger;
		}

	}

	void OnCollisionEnter2D (Collision2D other) {
		Debug.Log ("We are in contact", this);
		inContact = true;
	}

	void OnCollisionExit2D (Collision2D other) {
		Debug.Log ("We are leaving contact", this);
		inContact = false;
	}
}
