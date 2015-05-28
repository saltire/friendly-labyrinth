using UnityEngine;
using System.Collections;

public class Game_over_winner_name : MonoBehaviour {
	float timer = 3;
	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = PlayerPrefs.GetString ("Winner");
		Debug.Log (PlayerPrefs.GetString ("Winner"));
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
						if (Input.anyKey)
								Application.LoadLevel (Application.loadedLevel);
				}
	}
}
