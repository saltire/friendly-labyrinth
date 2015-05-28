using UnityEngine;
using System.Collections;

public class DeadlyWallPickup : MonoBehaviour {

	public GameObject floor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		floor.GetComponent<ResetFloor>().wallsDeadly = true;
		Destroy(gameObject);
	}
}
