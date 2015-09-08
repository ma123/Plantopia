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
	private float waitTime = -0.35f;
	private bool stopLock = true;
	public AudioClip sendArmyClip;

	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
	}

	void Update () {
		if(zeroLock) {
			zeroLock = false;
			stopLock = false;

			try {
				int numberInBuilding = (pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier() / 2);
				if(numberInBuilding > 0) {
					AudioSource.PlayClipAtPoint(sendArmyClip, transform.position); // prehranie send zvuku
				}
				while(soldierNumber < numberInBuilding) {
					BulletMove();
					soldierNumber++;
					pointFirst.GetComponent<BuildingsScript>().RemoveSoldier();
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
			bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			bulletInstance.GetComponent<PlayerSoldierScript> ().SetFirstPoint (pointFirst);
			bulletInstance.GetComponent<PlayerSoldierScript> ().SetSecondPoint (pointSecond);
			bulletInstance.GetComponent<PlayerSoldierScript> ().SetSecondId (secondId);
			bulletInstance.GetComponent<PlayerSoldierScript> ().SetWaitTime (waitTime+=0.35f);
		} catch {
			Debug.Log("exception soldier from prefab");
		}
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
