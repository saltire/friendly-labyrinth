using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

public class _Player : MonoBehaviour {

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
	public int player;
	public Vector3 Velocity;
	float speed = 50;
	public GameObject[] mazes;
	public GameObject crusherL;
	public GameObject crusherR;
	private float playerOneInversion = 0;
	private float playerTwoInversion = 0;
	private float inversionTime = 10f;
	int currentMazeIndex;
	GameObject currentMaze;
	float wait_timer = 0.75f;
	float crusher_push_back_amount = 0.5f;
	
	public GameObject ChooseMaze () {
		int nextMaze = -1;
		do {
			nextMaze = Random.Range(0, mazes.Length - 1);
		} while (nextMaze == currentMazeIndex);
		currentMazeIndex = nextMaze;
		return mazes[currentMazeIndex];
	}

	void respawnPlayer()
	{
		foreach (Transform t in currentMaze.transform)
		{
			if(t.name == "Spawn")
			{
				Vector3 newpos = t.transform.position;
				transform.position = new Vector3(newpos.x, newpos.y, -1f);
			}
		}
		wait_timer = 0.75f;
	}
	// Use this for initialization
	void Start () {
		if (player == 1) {
			currentMaze = Instantiate(ChooseMaze(), new Vector3(-8.1f, 10.85f, 1.8f), Quaternion.Euler(90, 180, 0)) as GameObject;
			gameObject.GetComponent<Animator>().SetBool("Girl", PlayerPrefs.GetString("Character1") == "girl");
		}
		else if (player == 2) {
			currentMaze = Instantiate(ChooseMaze(), new Vector3(8.1f, 10.85f, 1.8f), Quaternion.Euler(90, 180, 0)) as GameObject;
			gameObject.GetComponent<Animator>().SetBool("Girl", PlayerPrefs.GetString("Character2") == "girl");
		}

		respawnPlayer ();

	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Finish") {
			//delete level
			GameObject tmp = currentMaze;
			Destroy(tmp);

			//spawn new level
			if(player == 1) {
				currentMaze = Instantiate(ChooseMaze(), new Vector3(-8, 10.85f, 1.8f), Quaternion.Euler(90, 180, 0)) as GameObject;
				playerOneInversion = 0;
				GameObject otherPlayer = GameObject.FindGameObjectWithTag("PlayerTwo");
				otherPlayer.GetComponent<_Player>().pushForwardCrusher();
			}
			else if(player == 2) {
				currentMaze = Instantiate(ChooseMaze(), new Vector3(8, 10.85f, 1.8f), Quaternion.Euler(90, 180, 0)) as GameObject;
				playerTwoInversion = 0;
				GameObject otherPlayer = GameObject.FindGameObjectWithTag("PlayerOne");
				otherPlayer.GetComponent<_Player>().pushForwardCrusher();
			}

			speed = 50;

			respawnPlayer();

			this.pushBackCrusher();
		}
	}

	public void pushBackCrusher() {
		crusherL.GetComponent<_crusher>().Distance -= crusher_push_back_amount;
		if(crusherL.GetComponent<_crusher>().Distance < 0)
			crusherL.GetComponent<_crusher>().Distance = 0;
		crusherR.GetComponent<_crusher>().Distance -= crusher_push_back_amount;
		if(crusherR.GetComponent<_crusher>().Distance < 0)
			crusherR.GetComponent<_crusher>().Distance = 0;
	}

	public void pushForwardCrusher() {
		crusherL.GetComponent<_crusher>().Distance += crusher_push_back_amount;
		if(crusherL.GetComponent<_crusher>().Distance < 0)
			crusherL.GetComponent<_crusher>().Distance = 0;
		crusherR.GetComponent<_crusher>().Distance += crusher_push_back_amount;
		if(crusherR.GetComponent<_crusher>().Distance < 0)
			crusherR.GetComponent<_crusher>().Distance = 0;
	}

	public void setPlayerOneInversion(float timeLimit) {
		playerOneInversion = timeLimit;
	}

	public void setPlayerTwoInversion(float timeLimit) {
		playerTwoInversion = timeLimit;
	}

	public void slowDown () {
		speed = 20;
	}

	// Update is called once per frame
	void Update () {
		if (!playerIndexSet || !prevState.IsConnected) {
			for (int i = 0; i < 4; ++i) {
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				try {
					GamePadState testState = GamePad.GetState(testPlayerIndex);
					if (testState.IsConnected) {
						Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
						playerIndex = testPlayerIndex;
						playerIndexSet = true;
					}
				}
				catch(System.DllNotFoundException e) {

				}
			}
		}
		
		prevState = state;
		try {
			state = GamePad.GetState(playerIndex);
		}
		catch(System.DllNotFoundException e) {
		}
		
		//if (wait_timer <= 0) 
		{
			if (player == 1)  {
				if(playerOneInversion > 0) {
					playerOneInversion -= Time.deltaTime;

					if (playerIndexSet) {
						Velocity.x = -state.ThumbSticks.Left.X * speed;
						Velocity.y = -state.ThumbSticks.Left.Y * speed;
					}
					if (Input.GetKey (KeyCode.W)) {
						Velocity.y -= Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.S)) {
						Velocity.y += Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.A)) {
						Velocity.x += Time.deltaTime * speed;	
					}
					if (Input.GetKey (KeyCode.D)) {
						Velocity.x -= Time.deltaTime * speed;
					}
				}
				else {
					if (playerIndexSet) {
						Velocity.x = state.ThumbSticks.Left.X * speed;
						Velocity.y = state.ThumbSticks.Left.Y * speed;
					}
					if (Input.GetKey (KeyCode.W)) {
						Velocity.y += Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.S)) {
						Velocity.y -= Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.A)) {
						Velocity.x -= Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.D)) {
						Velocity.x += Time.deltaTime * speed;
					}
				}

				if(Velocity.y > 0.09f && Mathf.Abs(Velocity.y) > Mathf.Abs(Velocity.x)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 0);
				}
				else if(Velocity.y < -0.09f && Mathf.Abs(Velocity.y) > Mathf.Abs(Velocity.x)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
				}
				else if(Velocity.x > 0.09f && Mathf.Abs(Velocity.x) > Mathf.Abs(Velocity.y)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
				}
				else if(Velocity.x < -0.09f && Mathf.Abs(Velocity.x) > Mathf.Abs(Velocity.y)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 2);
				}
				Velocity *= 0.9f;
			}
			else if (player == 2)  {	
				if(playerTwoInversion > 0) {
					playerTwoInversion -= Time.deltaTime;

					if (playerIndexSet) {
						Velocity.x = -state.ThumbSticks.Right.X * speed;
						Velocity.y = -state.ThumbSticks.Right.Y * speed;
					}
					if (Input.GetKey (KeyCode.UpArrow)) {
						Velocity.y -= Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.DownArrow)) {
						Velocity.y += Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.LeftArrow)) {
						Velocity.x += Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.RightArrow)) {
						Velocity.x -= Time.deltaTime * speed;
					}
				}
				else {
					if (playerIndexSet) {
						Velocity.x = state.ThumbSticks.Right.X * speed;
						Velocity.y = state.ThumbSticks.Right.Y * speed;
					}
					if (Input.GetKey (KeyCode.UpArrow)) {
						Velocity.y += Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.DownArrow)) {
						Velocity.y -= Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.LeftArrow)) {
						Velocity.x -= Time.deltaTime * speed;
					}
					if (Input.GetKey (KeyCode.RightArrow)) {
						Velocity.x += Time.deltaTime * speed;
					}
				}

				if(Velocity.y > 0.09f && Mathf.Abs(Velocity.y) > Mathf.Abs(Velocity.x)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 0);
				}
				else if(Velocity.y < -0.09f && Mathf.Abs(Velocity.y) > Mathf.Abs(Velocity.x)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 1);
				}
				else if(Velocity.x > 0.09f && Mathf.Abs(Velocity.x) > Mathf.Abs(Velocity.y)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 3);
				}
				else if(Velocity.x < -0.09f && Mathf.Abs(Velocity.x) > Mathf.Abs(Velocity.y)) {
					gameObject.GetComponent<Animator>().SetInteger("Direction", 2);
				}
				Velocity *= 0.9f;
			}
			gameObject.GetComponent<Rigidbody2D> ().velocity = Velocity;
		}
		//else {
		//	wait_timer -= Time.deltaTime;
		//}
	}
}
