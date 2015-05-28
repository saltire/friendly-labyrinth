using UnityEngine;
using System.Collections;

public class SlowDownPickup : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "PlayerOne")
		{
			GameObject player = GameObject.FindGameObjectWithTag("PlayerTwo");
			player.GetComponent<_Player>().slowDown();
		}
		if(collision.gameObject.tag == "PlayerTwo")
		{
			GameObject player = GameObject.FindGameObjectWithTag("PlayerOne");
			player.GetComponent<_Player>().slowDown();
		}
		Destroy(gameObject);
	}
}
