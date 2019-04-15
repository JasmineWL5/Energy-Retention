using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject[] inventory = new GameObject [50];
	public Text countText;
	public Text winText;

	public int count;



	void Start(){
		count = 0;
		SetCountText ();
	}
	public void AddItem(GameObject item) {
		bool itemAdded = false;
		//Find the first open slot in inv
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == null) {
				inventory [i] = item;
				Debug.Log (item.name + "was added");
				itemAdded = true;
				count = count + 1;
				SetCountText ();

				break;
			}
		}
		//Inventory full
		if (!itemAdded) {
			Debug.Log ("Inventory full - Item not added");
		}
	}
	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
//		if (count >= 10) {
//			winText.text = "Choose one: ";
//		}
	}

}
