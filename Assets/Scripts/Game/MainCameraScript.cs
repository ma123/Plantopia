using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {
	public int offset = 1;
	public int borderX = 7;
	public int borderY = 6;
	public int borderZ = 0;
	private Vector3 pos;

	public void Start() {
		pos = transform.position;
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
		pos.z += offset;
		
		transform.position = Vector3.Lerp(transform.position, pos, 1f);
	}

	public void SizeMinus() {
		print ("sizeMinus");
		pos.z -= offset;
		
		transform.position = Vector3.Lerp(transform.position, pos, 1f);
	}
}
