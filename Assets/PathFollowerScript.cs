using UnityEngine;
using System.Collections;

public class PathFollowerScript : MonoBehaviour {
	public Transform[] path;
	public float speed = 3.0f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;

	void Start() {
	  
	}

	void Update() {
		float dist = Vector2.Distance (path [currentPoint].position, transform.position);

		transform.position = Vector2.MoveTowards(transform.position, path [currentPoint].position, Time.deltaTime* speed) ;

		if(dist <= reachDist) {
			currentPoint++;
		}

		if(currentPoint >= path.Length) {
			currentPoint = 0;
		}
	}
}
