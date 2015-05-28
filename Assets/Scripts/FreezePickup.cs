using UnityEngine;
using System.Collections;

public class FreezePickup : MonoBehaviour 
{
	public GameObject floor;
	public PhysicMaterial frozenMaterial;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		floor.transform.GetComponent<Collider>().material = frozenMaterial;
		floor.GetComponent<ResetFloor>().frozen = true;
		Destroy(gameObject);
	}
}
