using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
	protected Inventory playerInventory;

	// Use this for initialization
	void Start () {
		playerInventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<Inventory> ();
	}


	// Update is called once per frame
	public virtual void DoInteraction () {
		
	}
}
