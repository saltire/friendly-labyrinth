using UnityEngine;
using System.Collections;

public class textInput : MonoBehaviour {

	public float letterPause = 0.2f;
	string player_name, player_bestfriend_name;
	float delete_character_delay = 0.2f;
	float delete_character_timer = 0.0f;

	float underscore_character_delay = 0.3f;
	float underscore_character_timer = 0.0f;
	bool underscore = true;
	public int CharacterNameIndex = 0;

	public string Character1_name, Character1_bestfiend;
	public string Character2_name, Character2_bestfiend;

	public GameObject Menu_subtext1;
	public GameObject Menu_subtext2;

	public GameObject MenuManager;

	public bool Menu_Page_Character1 = true;
	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = "";
		player_name = "";
		player_bestfriend_name = "";
	}

	void TypeString(ref string message)
	{
		if (Input.anyKey && !Input.GetKey(KeyCode.Backspace) && !Input.GetKey(KeyCode.Return)) {
			message += Input.inputString;
		}
		if (Input.GetKey (KeyCode.Backspace) && message.Length > 0) {
			
			if(delete_character_timer == 0)
			{
				message = message.Remove (message.Length - 1);
			}
			delete_character_timer += Time.deltaTime;
			if(delete_character_timer >= delete_character_delay)
				delete_character_timer = 0;
		} 
		else {
			delete_character_timer = 0;
		}
	}
	void Update()
	{
		underscore_character_timer += Time.deltaTime;
		if (underscore_character_timer > underscore_character_delay) {
			underscore_character_timer = 0;
			underscore = !underscore;
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Menu_Page_Character1) {
				if (CharacterNameIndex == 0 && player_name.Length > 0) {
					Character1_name = player_name;
					PlayerPrefs.SetString("Character1_name", Character1_name); 
					CharacterNameIndex = 1;
					MenuManager.GetComponent<Menu_manager>().state = "character1friend select";
					MenuManager.GetComponent<Menu_manager>().ResetCharacterSelection();
				} 
				else if (CharacterNameIndex == 1 && player_bestfriend_name.Length > 0) {
					Character1_bestfiend = player_bestfriend_name;
					PlayerPrefs.SetString("Character1friend_name", Character1_bestfiend); 
					CharacterNameIndex = 0;
					player_name = "";
					player_bestfriend_name = "";
					Menu_Page_Character1 = false;
					CharacterNameIndex = 0;
					MenuManager.GetComponent<Menu_manager>().state = "character2 select";
					MenuManager.GetComponent<Menu_manager>().ResetCharacterSelection();
				}
			} 
			else {
				if (CharacterNameIndex == 0 && player_name.Length > 0) {
					Character2_name = player_name;
					PlayerPrefs.SetString("Character2_name", Character2_name); 
					CharacterNameIndex = 1;
					MenuManager.GetComponent<Menu_manager>().state = "character2friend select";
					MenuManager.GetComponent<Menu_manager>().ResetCharacterSelection();
				} 
				else if (CharacterNameIndex == 1 && player_bestfriend_name.Length > 0) {
					Character2_bestfiend = player_bestfriend_name;
					PlayerPrefs.SetString("Character2friend_name", Character2_bestfiend);
					Menu_subtext1.SetActive(false);
					Menu_subtext2.SetActive(false);
					Application.LoadLevel ("Maze"); 

				}
			}
		}

		if (CharacterNameIndex == 0) {
			TypeString (ref player_name);
		}
		else if (CharacterNameIndex == 1) {
			TypeString (ref player_bestfriend_name);
		}
		if (underscore) {
			if(CharacterNameIndex == 0){
				GetComponent<TextMesh> ().text = player_name + "_";
			}
			else {
				GetComponent<TextMesh> ().text = player_bestfriend_name + "_";
			}
		} 
		else {
			if(CharacterNameIndex == 0){
				GetComponent<TextMesh> ().text = player_name;
			}
			else {
				GetComponent<TextMesh> ().text = player_bestfriend_name;
			}
		}
	}
}
