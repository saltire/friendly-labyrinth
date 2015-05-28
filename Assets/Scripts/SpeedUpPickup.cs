using UnityEngine;
using System.Collections;

public class SpeedUpPickup : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
		GameObject playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
		if (collision.gameObject.tag == "PlayerOne") {
			playerTwo.GetComponent<_Player>().pushForwardCrusher();
		}
		else if (collision.gameObject.tag == "PlayerTwo") {
			playerOne.GetComponent<_Player>().pushForwardCrusher();
		}
		Destroy(gameObject);
	}
}
