using UnityEngine;
using System.Collections;

public class BFF_Name : MonoBehaviour {

	public int friend = 1;
	// Use this for initialization
	void Start () {
		if(friend == 1)
			GetComponent<TextMesh> ().text = PlayerPrefs.GetString ("Character1friend_name");
		else 
			GetComponent<TextMesh> ().text = PlayerPrefs.GetString ("Character2friend_name");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
