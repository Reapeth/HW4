using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public Text restartText;
	public GameObject pathfinder;
	void Start () {
		
	}
	void Update () {
		if (!GameObject.Find("Pathmaker")) {
			restartText.text = "Press [R] to restart";
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("Scene1");
			}
		}
	}
}
