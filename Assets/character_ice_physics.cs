using UnityEngine;
using System.Collections;

public class character_ice_physics : MonoBehaviour {

	Vector2 velocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float speed = 10.0f;
		if (Input.GetKey (KeyCode.W)) {
			velocity.y += speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			velocity.y -= speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			velocity.x += speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			velocity.x -= speed * Time.deltaTime;
		}
		gameObject.GetComponent<Rigidbody2D> ().velocity = (velocity);
		velocity *= 0.95f;
	}
}
