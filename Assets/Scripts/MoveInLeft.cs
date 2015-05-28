using UnityEngine;
using System.Collections;

public class MoveInLeft : MonoBehaviour {
	private float startTime;
	private float journeyLength;
	public GameObject target;
	private float speed;
	private Vector3 startPos;
	private float originalDistance;
	private float currentSeconds;
	private bool moving = true;
	private bool spedUp = false;
	private int timesSpedUp = 0;
	public float lengthOfSpeepUp = 5;
	private float startOfSpeedUp;
	

	private const float MAX_SECONDS = 60;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "NPCToDie") {
			print ("dead");
			moving = false;
		}
	}

	void ResetStartPos (float seconds) {
		startPos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		journeyLength = Vector3.Distance(this.transform.localPosition , target.transform.localPosition);
		speed = Mathf.Abs(this.transform.localPosition.x - target.transform.localPosition.x) / seconds;
		startTime = Time.time;
	}

	// Use this for initialization
	void Start () {
		originalDistance = this.transform.localPosition.x - target.transform.localPosition.x;
		ResetStartPos(MAX_SECONDS);
		currentSeconds = MAX_SECONDS;
	}

	void SetPositionFromSeconds (float seconds) {
		Vector3 pos = this.transform.localPosition;
		currentSeconds = seconds;
		if (seconds > MAX_SECONDS) {
			seconds = MAX_SECONDS;
		}
		this.transform.localPosition  = new Vector3(originalDistance * (seconds / MAX_SECONDS), pos.y, pos.z);
		ResetStartPos(seconds);
	}

	// Update is called once per frame
	void Update () {
		if (moving) {
			float distanceCovered = (Time.time - startTime) * speed;
			currentSeconds -= Time.deltaTime;
			float fracJourney = distanceCovered / journeyLength;
			this.transform.localPosition  = Vector3.Lerp(startPos, target.transform.localPosition, fracJourney);
			
			if(spedUp)
			{
				if(timesSpedUp > 0)
				{
					Debug.Log(Time.deltaTime - startOfSpeedUp);
					if(Time.deltaTime - startOfSpeedUp < lengthOfSpeepUp)
					{
						timesSpedUp--;
					}
				}
				else
				{
					spedUp = false;
				}
			}
			
			// debug function to test add seconds
			if (Input.GetKeyUp(KeyCode.Return)) {
				SetPositionFromSeconds(currentSeconds - 10);
			}
		}
	}
	public void SubtractTime(float seconds)
	{
		currentSeconds -= seconds;
		SetPositionFromSeconds(currentSeconds);
	}
	public void SpeedUp(float value = 0.1f)
	{
		speed += value;
		startOfSpeedUp = Time.deltaTime;
	}
}
