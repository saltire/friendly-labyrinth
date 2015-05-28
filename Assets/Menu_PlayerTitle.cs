using UnityEngine;
using System.Collections;

public class Menu_PlayerTitle : MonoBehaviour {

	public GameObject text_object;
	public Sprite player1_sprite;
	public Sprite player2_sprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (text_object.GetComponent<textInput> ().Menu_Page_Character1)
			gameObject.GetComponent<SpriteRenderer>().sprite = player1_sprite;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = player2_sprite;
	}
}
