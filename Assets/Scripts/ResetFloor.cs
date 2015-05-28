using UnityEngine;
using System.Collections;

public class ResetFloor : MonoBehaviour {

	public bool frozen = false;
	private float nextUm;
	public float interval = 1;
	public float startTime = 5;
	private float currentTime;
	private bool started = false;
	public PhysicMaterial normalMaterial;
	public bool wallsDeadly = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(frozen)
		{
			if(!started)
			{
				nextUm = Time.time + interval;
				currentTime = startTime;
				started = true;
			}
			else
			{
				if(nextUm <= Time.time)
				{
					currentTime--;
					nextUm = Time.time + interval;
				}
				if(currentTime == 0)
				{
					GetComponent<Collider>().material = normalMaterial;
					frozen = false;
					started = false;
				}
			}
		}
	}
}
