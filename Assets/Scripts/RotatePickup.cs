using UnityEngine;
using System.Collections;

public class RotatePickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject player = null;
		if (collision.gameObject.tag == "PlayerOne") {
			player = GameObject.FindGameObjectWithTag("PlayerTwo");
		}
		else if (collision.gameObject.tag == "PlayerTwo") {
			player = GameObject.FindGameObjectWithTag("PlayerOne");
		}

		if (player != null) {
			Transform maze = player.transform.parent.transform;
			
			if(maze.eulerAngles.z == 0)
			{
				maze.eulerAngles = new Vector3(0, 0, 180);
			}
			else
			{
				maze.eulerAngles = new Vector3(0, 0, 0);
			}
			Destroy(gameObject);
		}
		else {
			Debug.Log ("Player was null. gameobject tag: " + collision.gameObject.tag);
		}
	}
}
