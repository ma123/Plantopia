using UnityEngine;
using System.Collections;

public class BuildingsScript : MonoBehaviour {
	public int buildingId = 0;
	public int numberofSoldier = 5; 
	public int typeOfPlayer = 0; // 1 player , 2 neutral, 3 enemy, 4 enemy2 ...
	public int typeOfBuildings = 1; // zatial nepozite bud pevnost alebo farma
	private float waitPlayerTime = 5f;
	private float waitEnemyTime = 6f;
	private float lastTime = 0f;
	public Sprite[] spritePlayers;

	private TextMesh textMesh;

	void Start() {
		try {
			textMesh = GetComponentInChildren<TextMesh>();
			textMesh.text = numberofSoldier.ToString();
		} catch {
			Debug.Log("text == null");
		}
	}

	void Update() {
		if (typeOfPlayer == 1) { 
			if (Time.time > lastTime + waitPlayerTime) {
				numberofSoldier++;
				textMesh.text = numberofSoldier.ToString ();
				lastTime = Time.time;
			}
		} else {
			if(typeOfPlayer == 3) { 
				if(Time.time > lastTime + waitEnemyTime) {
					numberofSoldier++;
					textMesh.text = numberofSoldier.ToString();
					lastTime = Time.time;
				}
			}
		}
	}

	public void AddSoldier() {
		numberofSoldier++;
		textMesh.text = numberofSoldier.ToString();
	}
	
	public void RemoveSoldier() {
			numberofSoldier--;
			textMesh.text = numberofSoldier.ToString();
	}

	public int GetNumberOfSoldier() {
		return numberofSoldier;
	}

	public int GetBuildingsId() {
		return buildingId;
	}

	public int GetTypeOfPlayer() {
		return typeOfPlayer;
	}

	public void SetTypeOfPlayer(int typeOfPlayer) {
		this.typeOfPlayer = typeOfPlayer;

		switch(this.typeOfPlayer) {
		case 1: //player
			SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
			foreach(SpriteRenderer child in allChildren) {
				if(child.name == "buildingspicture") {
					child.sprite = spritePlayers[0];
				}
			}
			numberofSoldier = -1;
			textMesh.text = numberofSoldier.ToString();
			break;
		case 3: // enemy 1
			SpriteRenderer[] allChildrenEnemy = GetComponentsInChildren<SpriteRenderer>();
			foreach(SpriteRenderer child in allChildrenEnemy) {
				if(child.name == "buildingspicture") {
					child.sprite = spritePlayers[1];
				}
			}
			numberofSoldier = -1;
			textMesh.text = numberofSoldier.ToString();
			break;
        // podla poctu nepriatelov
		}
	}
}
