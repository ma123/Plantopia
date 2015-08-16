using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Transform pointFirst;
	private Transform pointSecond;
	//public Rigidbody2D rigidBody;
	//Rigidbody2D bulletInstance = null;
	public GameObject gameObject;


	// Use this for initialization
	void Start () {
		pointFirst = GetComponent<Transform> ();
		pointSecond = GetComponent<Transform> ();
		pointFirst = pointSecond = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			print ("Stlacil som down");
		
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			try {
				pointFirst = hit.collider.gameObject.transform;
			    print ("1:  " + pointFirst);
			} catch {
				Debug.Log("hit collider game object == null");
			}
		}

		if(Input.GetMouseButtonUp(0)) {
			print ("Stlacil som up");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			try {
				pointSecond = hit.collider.gameObject.transform;
				print ("2:  " + pointSecond);
			} catch {
				Debug.Log("hit collider game object == null");
			}
		}
		// todo DOROBIT DETEKCIU VOJAKOV TAKTO MOZE BZT VOJAK POTENCIONALNE BUDOVA

		if (pointFirst == pointSecond) {
			pointFirst = pointSecond = null;
			return;
		} else {
			if((pointFirst != null) && (pointSecond != null)) {
				BulletMove ();
				print ("vytvoril som objekt");

			}
		}
	}

	private void BulletMove() {
		print (pointFirst + " " + pointSecond);
		  Instantiate(gameObject);

		  pointFirst = pointSecond = null;
			//bulletInstance = Instantiate (rigidBody, pointFirst.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;

			//bulletInstance.velocity = new Vector2 (2f, 0);
	}

	public Transform GetPointFirst() {
		print (pointFirst);
		return pointFirst;
	}
	
	public Transform GetPointSecond() {
		return pointSecond;
	}
}
