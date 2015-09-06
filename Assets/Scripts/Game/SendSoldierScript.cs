using UnityEngine;
using System.Collections;

public class SendSoldierScript: MonoBehaviour {
	public Rigidbody2D rigidBody;
	Rigidbody2D bulletInstance = null;
	private int soldierNumber = 0;
	private bool zeroLock = false;
	private Transform pointFirst;
	private Transform pointSecond;
	private int secondId;
	private bool stopLock = true;
	private float waitTime = 0f;

	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
	}

	void Update () {
		if(zeroLock) {
			stopLock = false;
			zeroLock = false;

			try {
				int numberInBuilding = (pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier() / 2);
				while(soldierNumber < numberInBuilding) {
					BulletMove();
					soldierNumber++;
				}
				
				soldierNumber = 0;
				zeroLock = true;
			} catch {
				Debug.Log("null exception send army");
			}
		}

		if(zeroLock) {
			pointFirst = pointSecond = null;
			zeroLock = false;
			stopLock = true;
			waitTime = 0f;
		}
	}

	private void BulletMove() {
		try {
			if(0 < pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier()) {
				bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.GetComponent<PlayerSoldierScript> ().SetFirstPoint (pointFirst);
				bulletInstance.GetComponent<PlayerSoldierScript> ().SetSecondPoint (pointSecond);
				bulletInstance.GetComponent<PlayerSoldierScript> ().SetSecondId (secondId);
				bulletInstance.GetComponent<PlayerSoldierScript> ().SetWaitTime (waitTime+=0.35f);
			} else {
				return;
			}
		} catch {
			Debug.Log("exception soldier from prefab");
		}
	}

	public void SetZeroLock(bool zeroLock) {
		this.zeroLock = zeroLock;
	}

	public bool GetStopLock() {
		return stopLock;
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
}
