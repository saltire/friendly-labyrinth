using UnityEngine;
using System.Collections;

public class InversionPickup : MonoBehaviour {

	
	private GameObject player1;
	private GameObject player2;

	private float inversionTime = 10f;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag("PlayerOne");
		player2 = GameObject.FindGameObjectWithTag("PlayerTwo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "PlayerOne")
		{
			player2.GetComponent<_Player>().setPlayerTwoInversion(inversionTime);
		}
		else if(coll.gameObject.tag == "PlayerTwo")
		{
			player1.GetComponent<_Player>().setPlayerOneInversion(inversionTime);
		}
		Destroy(gameObject);
	}
}
