using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {
	void Start() {
		Time.timeScale = 1; // pauznutie hry
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
