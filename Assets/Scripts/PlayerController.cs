using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidbody;
	public Animator animator;
	public Inventory inventory;

	public GameObject currentInterObj = null;
	public InteractableObject currentInterObjScript = null;

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	float lastFrameJumpAxis = 0;
	float jumpPower = 800;

	bool grounded = false;
	public bool IsClimbingLadder = false;
	private SpriteRenderer spriteRenderer;

	bool facingRight = true;

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		var moveSpeed = Input.GetAxis ("Horizontal");
		var isGrounded = rigidbody.velocity.y == 0;
		var isJumping = Input.GetAxis ("Jump") > 0 && lastFrameJumpAxis <= 0;
		var isClimbing = Input.GetAxis ("Vertical") != 0;
		lastFrameJumpAxis = Input.GetAxis ("Jump");

		//Run
		rigidbody.AddForce (Vector2.right * moveSpeed * 20);
		//Setting the speed animation, so it will toggle PlayerRun
		animator.SetFloat ("Speed", Mathf.Abs(moveSpeed));

		//Grounded & Jumping
		if (isGrounded && isJumping) {
			rigidbody.AddForce (Vector2.up * jumpPower);
			animator.SetBool ("IsJumping", true);
		}

		if (isGrounded && !isJumping) {
			animator.SetBool ("IsJumping", false);
		}

		//Climbing 
		if (IsClimbingLadder) {
			var direction = Input.GetAxis ("Vertical");
			rigidbody.AddForce (Vector2.up * direction * 20);
			//if (isClimbing) {
				animator.SetBool ("IsClimbing", true);
		}
	
		if (!IsClimbingLadder) {
			animator.SetBool ("IsClimbing", false);
		}

		//Checking the interactable Object
		if (Input.GetAxis ("Interact") > 0 && currentInterObj) {
			Debug.Log ("Interacting with " + currentInterObj.name, currentInterObj);

			//Do something with the object
			currentInterObj.SendMessage("DoInteraction");
		}

		if (Input.GetAxis ("Horizontal") > 0 && !facingRight) {
			Flip ();
		} else if (Input.GetAxis ("Horizontal") < 0 && facingRight) {
			Flip ();
		}
	}

	//Picking up the book objects tagged with "PickUp"
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("InterObj")) {
			Debug.Log ("We are entering this book", this);
			currentInterObj = other.gameObject;
			currentInterObjScript = currentInterObj.GetComponent <InteractableObject> ();
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("InterObj")){
			Debug.Log ("We are leaving this book", this);
			if (other.gameObject == currentInterObj) {
				currentInterObj = null;
			};
		}
	}

	void Flip() {
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}