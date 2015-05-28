using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

public class PlayerMovement : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	private bool playerControl = true;
	private float playerOneSpeed;
	private float playerTwoSpeed;
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
	public GameObject player2;
	public bool playerOneInverted = false;
	public bool playerTwoInverted = false;
	private float nextUm;
	public float interval = 1;
	public float startTime = 5;
	private float playerOneCurrentTime;
	private float playerTwoCurrentTime;
	private bool playerOneStarted = false;
	private bool playerTwoStarted = false;
	public bool playerOneSlowed = false;
	public bool playerTwoSlowed = false;
	public float speed = 1000.0f;
	public float slowDownSpeed = 800.0f;
	public float startingX;
	public float startingZ;
	
    void FixedUpdate ()
    {
		if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                   // Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);
		float moveHorizontal = 0;
		float moveVertical = 0;
		
		if(playerOneSlowed)
		{
			playerOneSpeed = slowDownSpeed;
			
			if(!playerOneStarted)
			{
				nextUm = Time.time + interval;
				playerOneCurrentTime = startTime;
				playerOneStarted = true;
			}
			else
			{
				if(nextUm <= Time.time)
				{
					playerOneCurrentTime--;
					nextUm = Time.time + interval;
				}
				if(playerOneCurrentTime == 0)
				{
					playerOneSlowed = false;
					playerOneStarted = false;
				}
			}
		}
		else
		{
			playerOneSpeed = speed;
		}
		if(playerOneInverted)
		{
			moveHorizontal = -state.ThumbSticks.Left.X * playerOneSpeed;
			moveVertical = -state.ThumbSticks.Left.Y * playerOneSpeed;

			if(Input.GetKeyDown(KeyCode.W))
				moveVertical -= playerOneSpeed;
			if(Input.GetKeyDown(KeyCode.S))
				moveVertical += playerOneSpeed;
			if(Input.GetKeyDown(KeyCode.A))
				moveHorizontal += playerOneSpeed;
			if(Input.GetKeyDown(KeyCode.D))
				moveHorizontal -= playerOneSpeed;

			if(!playerOneStarted)
			{
				nextUm = Time.time + interval;
				playerOneCurrentTime = startTime;
				playerOneStarted = true;
			}
			else
			{
				if(nextUm <= Time.time)
				{
					playerOneCurrentTime--;
					nextUm = Time.time + interval;
				}
				if(playerOneCurrentTime == 0)
				{
					playerOneInverted = false;
					playerOneStarted = false;
				}
			}
		}
		else
		{
			moveHorizontal = state.ThumbSticks.Left.X * playerOneSpeed;
			moveVertical = state.ThumbSticks.Left.Y * playerOneSpeed;

			if(Input.GetKeyDown(KeyCode.W))
				moveVertical += playerOneSpeed;
			if(Input.GetKeyDown(KeyCode.S))
				moveVertical -= playerOneSpeed;
			if(Input.GetKeyDown(KeyCode.A))
				moveHorizontal -= playerOneSpeed;
			if(Input.GetKeyDown(KeyCode.D))
				moveHorizontal += playerOneSpeed;
		}
        //float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
        //float moveVertical = Input.GetAxis ("Vertical") * speed;
		
		moveHorizontal *= Time.deltaTime;
		moveVertical *= Time.deltaTime;
		
		gameObject.GetComponent<Rigidbody>().AddForce(moveHorizontal, moveVertical, 0);
		if(playerTwoSlowed)
		{
			playerTwoSpeed = slowDownSpeed;
			if(!playerTwoStarted)
			{
				nextUm = Time.time + interval;
				playerTwoCurrentTime = startTime;
				playerTwoStarted = true;
			}
			else
			{
				if(nextUm <= Time.time)
				{
					playerTwoCurrentTime--;
					nextUm = Time.time + interval;
				}
				if(playerTwoCurrentTime == 0)
				{
					playerTwoSlowed = false;
					playerTwoStarted = false;
				}
			}
		}
		else
		{
			playerTwoSpeed = speed;
		}

		if(playerTwoInverted)
		{
			moveHorizontal = -state.ThumbSticks.Right.X * playerTwoSpeed;
			moveVertical = -state.ThumbSticks.Right.Y * playerTwoSpeed;

			if(Input.GetKeyDown(KeyCode.W))
				moveVertical -= playerTwoSpeed;
			if(Input.GetKeyDown(KeyCode.S))
				moveVertical += playerTwoSpeed;
			if(Input.GetKeyDown(KeyCode.A))
				moveHorizontal += playerTwoSpeed;
			if(Input.GetKeyDown(KeyCode.D))
				moveHorizontal -= playerTwoSpeed;

			if(!playerTwoStarted)
			{
				nextUm = Time.time + interval;
				playerTwoCurrentTime = startTime;
				playerTwoStarted = true;
			}
			else
			{
				if(nextUm <= Time.time)
				{
					playerTwoCurrentTime--;
					nextUm = Time.time + interval;
				}
				if(playerTwoCurrentTime == 0)
				{
					playerTwoInverted = false;
					playerTwoStarted = false;
				}
			}
		}
		else
		{
			moveHorizontal = state.ThumbSticks.Right.X * playerTwoSpeed;
			moveVertical = state.ThumbSticks.Right.Y * playerTwoSpeed;

			if(Input.GetKeyDown(KeyCode.W))
				moveVertical += playerTwoSpeed;
			if(Input.GetKeyDown(KeyCode.S))
				moveVertical -= playerTwoSpeed;
			if(Input.GetKeyDown(KeyCode.A))
				moveHorizontal -= playerTwoSpeed;
			if(Input.GetKeyDown(KeyCode.D))
				moveHorizontal += playerTwoSpeed;
		}
		
		moveHorizontal *= Time.deltaTime;
		moveVertical *= Time.deltaTime;

		//Debug.Log (moveHorizontal);

		player2.GetComponent<Rigidbody>().AddForce(moveHorizontal, moveVertical, 0);
    }
	public void ResetPlayer()
	{
		transform.position = new Vector3(startingX, 2.0F, startingZ);
	}
}
