using UnityEngine;
using System.Collections;

public class BuildingsScript : MonoBehaviour {
	public int buildingId = 0;
	public int numberofSoldier = 5; 
	public int typeOfPlayer = 0; // 1 player , 2 neutral, 3 enemy, 4 enemy2 ...
	public bool isFarmOrFort = true;
	private float waitPlayerTime = 3f;
	private float waitEnemyRedTime = 4.3f;
	private float waitEnemyVioletTime = 4.1f;
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
		if(isFarmOrFort) {
			switch(typeOfPlayer) {
			case 1:
				if (Time.time > lastTime + waitPlayerTime) {
					AddSoldier();
					lastTime = Time.time;
				}
				break;
			case 3:
				if(Time.time > lastTime + waitEnemyRedTime) {
					AddSoldier();
					lastTime = Time.time;
				}
				break;
			case 4:
				if(Time.time > lastTime + waitEnemyVioletTime) {
					AddSoldier();
					lastTime = Time.time;
				}
				break;
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
		SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
		switch(this.typeOfPlayer) {
			case 1: //player
				foreach(SpriteRenderer child in allChildren) {
					if(child.name == "buildingspicture") {
						child.sprite = spritePlayers[0];
					}
				}
			break;
			case 3: // enemy red
				foreach(SpriteRenderer child in allChildren) {
					if(child.name == "buildingspicture") {
						child.sprite = spritePlayers[1];
					}
				}
			break;
			case 4: // enemy violet
				foreach(SpriteRenderer child in allChildren) {
					if(child.name == "buildingspicture") {
						child.sprite = spritePlayers[2];
					}
				}
			break;
		}
		numberofSoldier = 0;
		textMesh.text = numberofSoldier.ToString();	
	}
}
