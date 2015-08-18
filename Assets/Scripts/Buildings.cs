using UnityEngine;
using System.Collections;

public class Buildings : MonoBehaviour {
	public int buildingId = 0;
	public int numberofSoldier = 5; 
	public int typeOfPlayer = 0; // 1 player , 2 neutral, 3 enemy, 4 enemy2 ...
	public int typeOfBuildings = 1; // zatial nepozite bud pevnost alebo farma
	private float waitTime = 5f;
	private float lastTime = 0f;
	public Sprite[] spritePlayers;

	private TextMesh textMesh;

	void Start() {
		/*Sprite sprite = Resources.Load ("priority_green", typeof(Sprite)) as Sprite; 

		print (sprite);*/

		try {
			textMesh = GetComponentInChildren<TextMesh>();
			textMesh.text = numberofSoldier.ToString();
		} catch {
			Debug.Log("text == null");
		}
	}

	void Update() {
		if(typeOfPlayer != 2) { // neutral buildings
			if(Time.time > lastTime + waitTime) {
				numberofSoldier++;
				textMesh.text = numberofSoldier.ToString();
				lastTime = Time.time;
			}
		}
	}

	/*void OnTriggerEnter2D(Collider2D col) {
		print ("trigger enter");
		if (col.tag == "Soldier") {
			print ("trigger enter destroy");
			Destroy (col.gameObject);
		}
	}*/

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
		case 1:
			print(GameObject.Find("buildingspicture"));
			GameObject.Find("buildingspicture").GetComponent<SpriteRenderer>().sprite = spritePlayers[0];

		    //gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spritePlayers[0];
			break;
		case 2:
			gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spritePlayers[1];
			break;
        // podla poctu nepriatelov
		}
	}
}
