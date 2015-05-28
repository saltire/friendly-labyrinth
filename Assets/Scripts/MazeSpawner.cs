using UnityEngine;
using System.Collections;

public class MazeSpawner : MonoBehaviour {

	public GameObject[] mazes;
	int currentMaze;

	public GameObject ChooseMaze () {
		/* int nextMaze = -1;
		do {
			nextMaze = Random.Range(0, mazes.Length - 1);
		} while (nextMaze == currentMaze);
		currentMaze = nextMaze;
		return mazes[currentMaze]; */
		currentMaze = 0;
		return mazes[0];
	}

	// Use this for initialization
	void Start () {
		GameObject maze = Instantiate(ChooseMaze(), transform.position, Quaternion.Euler(90, 180, 0)) as GameObject;
		//Debug.Log("test");
		/*if(name == "MazeSpawner1")
		{
			maze.transform.Find("PlayerStart").GetComponent<SpawnPlayer>().SpawnPlayerOne(maze);
		}
		if(name == "MazeSpawner2")
		{
			maze.transform.Find("PlayerStart").GetComponent<SpawnPlayer>().SpawnPlayerTwo(maze);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
