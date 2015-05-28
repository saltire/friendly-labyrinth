using UnityEngine;
using System.Collections;

public class debug_names : MonoBehaviour {

	public GameObject text_object;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string player1 = text_object.GetComponent<textInput> ().Character1_name;
		string player1_bestfriend = text_object.GetComponent<textInput> ().Character1_bestfiend;
		string player2 = text_object.GetComponent<textInput> ().Character2_name;
		string player2_bestfriend = text_object.GetComponent<textInput> ().Character2_bestfiend;

		GetComponent<TextMesh> ().text = player1 + " " + player1_bestfriend + " " + player2 + " " + player2_bestfriend;
	}
}
