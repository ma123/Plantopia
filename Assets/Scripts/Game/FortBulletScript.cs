using UnityEngine;
using System.Collections;

public class FortBulletScript : MonoBehaviour {
	private int typeOfPlayer;

	void Start () {
		Destroy(gameObject, 0.7f); // znicenie naboja po 2 sekundach ak nenajde ciel
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		switch(typeOfPlayer) {
		case 1: 
			if(col.tag == "EnemySoldierViolet") {
				KillObject(col);
			}
			
			if(col.tag == "EnemySoldierRed") {
				KillObject(col);
			}
			break;
		case 2: 
			if(col.tag == "EnemySoldierViolet") {
				KillObject(col);
			}
			
			if(col.tag == "EnemySoldierRed") {
				KillObject(col);
			}

			if(col.tag == "PlayerSoldier") {
				KillObject(col);
			}
			break;
		case 3: 
			if(col.tag == "EnemySoldierViolet") {
				KillObject(col);
			}
			
			if(col.tag == "PlayerSoldier") {
				KillObject(col);
			}
			break;
		case 4: 
			if(col.tag == "EnemySoldierRed") {
				KillObject(col);
			}
			
			if(col.tag == "PlayerSoldier") {
				KillObject(col);
			}
			break;
		}
	}

	public void SetTypeOfPlayer(int typeOfPlayer) {
		this.typeOfPlayer = typeOfPlayer;
	}

	private void KillObject(Collider2D col) {
		Destroy (gameObject);
		Destroy (col.gameObject);
	}
}
