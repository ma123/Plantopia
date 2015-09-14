using UnityEngine;
using System.Collections;

public class EnemySoldierSenderScript : MonoBehaviour {
	public Rigidbody2D rigidBody;
	private Rigidbody2D bulletInstance = null;
	public float waitEnemyTime = 1.5f;
	private float lastTime = 0f;
	private bool zeroLock = false;
	private Transform pointFirst;
	private Transform pointSecond;
	private int secondId;
	private bool stopLock = true;
	public int enemyType = 0; // 3cerveny 4 fialovy

	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (zeroLock) {
			if (Time.time > waitEnemyTime + lastTime) {
				if(pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier() > 1) {
					BulletMove();
					pointFirst.GetComponent<BuildingsScript>().RemoveSoldier();
				}

				lastTime = Time.time;
			}
		}
	}

	private void BulletMove() {
		try{
			switch(enemyType) {
			case 3:
				bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.GetComponent<EnemySoldierRedScript> ().SetSecondPoint (pointSecond);
				bulletInstance.GetComponent<EnemySoldierRedScript> ().SetSecondId (secondId);
				break;
			case 4:
				bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.GetComponent<EnemySoldierVioletScript> ().SetSecondPoint (pointSecond);
				bulletInstance.GetComponent<EnemySoldierVioletScript> ().SetSecondId (secondId);
				break;
			}		
		} catch{
			Debug.Log("bullet not shoot");
		};
	}

	public void SetZeroLock(bool zeroLock) {
		this.zeroLock = zeroLock;
	}
	
	public void SetFirstPoint(Transform firstPoint) {
		this.pointFirst = firstPoint;
	}
	
	public void SetSecondPoint(Transform secondPoint) {
		this.pointSecond = secondPoint;
	}
	
	public void SetSecondId(int secondId) {
		this.secondId = secondId;
	}
	
	public bool GetStopLock() {
		return stopLock;
	}
}
