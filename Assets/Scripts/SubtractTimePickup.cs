using UnityEngine;
using System.Collections;

public class SubtractTimePickup : MonoBehaviour 
{
	public float amount;
	public GameObject crusher;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		crusher.transform.Find("rightvice").GetComponent<MoveInLeft>().SubtractTime(amount);
		crusher.transform.Find("leftvice").GetComponent<MoveInLeft>().SubtractTime(amount);
		Destroy(gameObject);
	}
}
