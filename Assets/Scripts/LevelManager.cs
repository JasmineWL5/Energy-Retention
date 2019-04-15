using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public string RestartLevelName;
	public string LevelDownName;

	public void ContinueLevel(){
		Application.LoadLevel (RestartLevelName);
	}

	public void LevelDown(){
		Application.LoadLevel (LevelDownName);
	}
}
