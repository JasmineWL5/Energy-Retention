using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObjects : InteractableObject {
	public bool locked;
	public int RequiredItems = 3;
	public GameObject DoorUIUnlocked;
	public GameObject DoorUILocked;

	public override void DoInteraction () {
		if (playerInventory.count >= RequiredItems) {
			DoorUIUnlocked.SetActive (true); 


			Debug.Log ("Door can be unlocked");
		} else {
			DoorUILocked.SetActive (true);
			Debug.Log ("Door is locked.");
			StartCoroutine (hideGameObject (DoorUILocked));
		}
	}

	IEnumerator hideGameObject (GameObject Obj) {
		yield return new WaitForSeconds (5);
		Obj.SetActive (false);
	}
}
