using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		if(gameObject.GetComponentInParent<ResetFloor>().wallsDeadly == true)
		{
			if(collision.gameObject.tag == "PlayerOne" || collision.gameObject.tag == "PlayerTwo")
			{
				collision.gameObject.GetComponent<PlayerMovement>().ResetPlayer();
			}
		}
	}
}
