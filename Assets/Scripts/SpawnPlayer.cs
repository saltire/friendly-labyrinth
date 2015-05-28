using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour 
{
	public GameObject playerOne;
	public GameObject playerTwo;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void SpawnPlayerOne(GameObject maze)
	{
		GameObject player = Instantiate(playerOne) as GameObject;
		player.transform.parent = maze.transform;
		player.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 1f,this.transform.localPosition.z);
	}
	public void SpawnPlayerTwo(GameObject maze)
	{
		GameObject player = Instantiate(playerTwo) as GameObject;
		player.transform.parent = maze.transform;
		player.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 1f,this.transform.localPosition.z);
	}
}
