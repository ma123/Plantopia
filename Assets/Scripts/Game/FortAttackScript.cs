using UnityEngine;
using System.Collections;

public class FortAttackScript : MonoBehaviour {
	public Rigidbody2D bulletRigidBody;
	private float fireRate = 0.5f;
	private float lastShoot = 0f;

	// Update is called once per frame
	void Update () {
		if (Time.time > fireRate + lastShoot) {	
			for(int i = 0; i < 5; i++) {
				BulletMove ();
			}
			lastShoot = Time.time;
		}
	}

	private void BulletMove() {
			float randomX = Random.Range (-2f, 2f);
			float randomY = Random.Range (-2f, 2f);
			Vector2 randomDir = new Vector2 (randomX, randomY);

			Rigidbody2D bulletInstance = Instantiate(bulletRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			int typeOfPlayer = this.GetComponent<BuildingsScript> ().GetTypeOfPlayer();
			bulletInstance.GetComponent<FortBulletScript> ().SetTypeOfPlayer (typeOfPlayer);
			bulletInstance.velocity = randomDir;
	}
}
