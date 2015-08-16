using UnityEngine;
using System.Collections;

public class SoldierScript : MonoBehaviour {
	private GameObject playerController;

	private Transform[] path;
	private float speed = 3.0f;
	private float reachDist = 1.0f;
	private int currentPoint = 0;

	void Start () {
		playerController = GameObject.Find ("PlayerController");
		try {
			path[0] = playerController.GetComponent<PlayerController> ().GetPointFirst();
			//path[1] = playerController.GetComponent<PlayerController> ().GetPointSecond();
			print (path[0]);//+ " " + path[1].position);
		} catch {
			Debug.Log("path == null");
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 0);


		//Destroy (gameObject, 2);
		//print (transform.position);
	}

	void Update() {

		//print (playerController +" " + path[0]+" " + path[1]);
		/*float dist = Vector2.Distance (path [currentPoint].position, transform.position);
		
		transform.position = Vector2.MoveTowards(transform.position, path [currentPoint].position, Time.deltaTime* speed) ;
		
		if(dist <= reachDist) {
			currentPoint++;
		}
		
		if(currentPoint >= path.Length) {
			currentPoint = 0;
		}*/
	}
}
