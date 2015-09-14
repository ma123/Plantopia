using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {
	public int offset = 1;
	public int borderX = 7;
	public int borderY = 6;
	public int borderZ = 0;
	public int cameraSizeMax = 7;
	public int cameraSizeMin = 3;
	public int actualCameraSize = 5;
	private Vector3 pos;

	public void Start() {
		pos = transform.position;
		Camera.main.orthographicSize = actualCameraSize; // aktualna velkost kamery na zaciatku
	}

	public void MoveRight() {
		print ("moveRight");
		if(pos.x < borderX) {
			pos.x += offset;
			transform.position = Vector3.Lerp(transform.position, pos, 1f);
		}
	}

	public void MoveLeft() {
		print ("moveLeft");
		if (pos.x > -borderX) {
			pos.x -= offset;
			transform.position = Vector3.Lerp (transform.position, pos, 1f);
		}
	}

	public void MoveUp() {
		print ("moveUp");
		if (pos.y < borderY) {
			pos.y += offset;
			transform.position = Vector3.Lerp (transform.position, pos, 1f);
		}
	}

	public void MoveDown() {
		print ("moveDown");
		if (pos.y > -borderY) {
			pos.y -= offset;
			transform.position = Vector3.Lerp (transform.position, pos, 1f);
		}
	}

	public void SizePlus() {
		print ("sizePlus");
		if(actualCameraSize > cameraSizeMin) {
			actualCameraSize -= offset;
			Camera.main.orthographicSize = actualCameraSize;
		}
	}

	public void SizeMinus() {
		print ("sizeMinus");
		if(actualCameraSize < cameraSizeMax) {
			actualCameraSize += offset;
			Camera.main.orthographicSize = actualCameraSize;
		}
	}
}
