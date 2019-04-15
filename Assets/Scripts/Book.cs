using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : InteractableObject {


	// Update is called once per frame
	public override void DoInteraction () {
		//Picked up and put into inventory
		//Check to see if this object is to be stored in inventory
		playerInventory.AddItem (gameObject);

		gameObject.SetActive (false);
		Debug.Log ("Book added", this);
	}
}
