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

	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if(zeroLock) {
			zeroLock = false;
			try {
				int numberInBuilding = (pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier() / 2);
				StartCoroutine(WaitTime(numberInBuilding));
			} catch {
				Debug.Log("null exception startcoroutine bullet");
			}
		}

		if(zeroLock) {
			pointFirst = pointSecond = null;
			zeroLock = false;
		}
	}

	public IEnumerator WaitTime(int numberInBuilding) {
		if (soldierNumber < numberInBuilding) {
			BulletMove ();
			soldierNumber++;
			yield return new WaitForSeconds (0.35f);
		} else {
			soldierNumber = 0;
		}
		zeroLock = true;
	}

	private void BulletMove() {
		try {
			if(pointFirst.GetComponent<BuildingsScript>().GetNumberOfSoldier() > 0) {
				bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.GetComponent<PlayerSoldierScript> ().SetSecondPoint (pointSecond);
				bulletInstance.GetComponent<PlayerSoldierScript> ().SetSecondId (secondId);
				pointFirst.GetComponent<BuildingsScript>().RemoveSoldier();
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
