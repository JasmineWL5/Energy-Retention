using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public float levelStartDelay = 2f;

	private Text levelText;

	private GameObject levelImage;

	void InitGame (){
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		//levelText.text = "Day " + level;
		levelImage.SetActive(true);

	
	}
	private void HideLevelImage(){
		levelImage.SetActive (false);
		//doingSetup = false;
	}
	void Start () {
		
	}
	
	// Updat	e is called once per frame
	void Update () {
		
	}
}
