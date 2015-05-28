using UnityEngine;
using System.Collections;

public class Start_button : MonoBehaviour {
	float start_timer;
	float sine_timer;
	// Use this for initialization
	void Start () {
		start_timer = 0;
		sine_timer = -3.14f;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
	}
	
	// Update is called once per frame
	void Update () {
		start_timer += Time.deltaTime;
		if (start_timer > 1) {
			sine_timer += Time.deltaTime * 2.5f;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,(Mathf.Cos(sine_timer) / 2) + 0.5f);
			//Debug.Log(Mathf.Sin(sine_timer));
		}

	}
}
