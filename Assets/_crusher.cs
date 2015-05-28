using UnityEngine;
using System.Collections;

public class _crusher : MonoBehaviour {
	public int Direction = 1;
	public float Distance = 0;
	float crush_speed = 0.1f;
	public bool crushed = false;
	Vector3 initialPos;
	Vector3 initialOuterPos;
	public int playerIndex = 1;

	//float bobble_timer = 0;
	
	float crushDistance = 3.9f;
	float stopDistance = 4.4f;


	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		initialOuterPos = transform.Find("crusher-outer").position;
	}
	
	// Update is called once per frame
	void Update () {
		//bobble_timer += Time.deltaTime * 250;
		if (Distance >= 0 && Distance < stopDistance) {
			Distance += Time.deltaTime * crush_speed;
			//transform.position = initialPos + new Vector3 (Distance * Direction, Mathf.Sin(bobble_timer) * 0.1f, 0);
			transform.position = initialPos + new Vector3 (Distance * Direction, 0, 0);
			transform.Find("crusher-outer").position = initialOuterPos + new Vector3 (Distance * Direction * 0.5f, 0, 0);
		}
		
		if (Distance > crushDistance) {
			crushed = true;
		}
	}
}
