using UnityEngine;
using System.Collections;

public class Menu_manager : MonoBehaviour {

	// Use this for initialization
	public int pageIndex = 0;
	public string state = "character1 select";
	public GameObject textInput_go;
	public GameObject enter_your_name_subtext;
	public GameObject choose_your_character_subtext;
	public GameObject title_go;
	public GameObject logo_go;
	public GameObject particle_go;
	public GameObject start_go;
	public GameObject background_go;
	public GameObject girl_go;
	public GameObject boy_go;

	public Sprite girl_sprite;
	public Sprite boy_sprite;
	public Sprite girl_glow_sprite;
	public Sprite boy_glow_sprite;
	
	public Sprite bff_girl_sprite;
	public Sprite bff_boy_sprite;
	public Sprite bff_girl_glow_sprite;
	public Sprite bff_boy_glow_sprite;
	
	public Sprite enter_your_name_sprite;
	public Sprite enter_bestfriends_name_sprite;
	public Sprite choose_your_character_sprite;
	public Sprite choose_bestfriend_character_sprite;
	float title_fade = 1;
	void Start () {
	
	}

	public void ResetCharacterSelection()
	{
		girl_go.GetComponent<SpriteRenderer>().sprite = girl_sprite;
		boy_go.GetComponent<SpriteRenderer>().sprite = boy_sprite;
	}
	// Update is called once per frame
	void Update () 
	{
		if (pageIndex == 0) {
			if (Input.anyKeyDown) {
				pageIndex = 1;
				logo_go.SetActive(false);
				particle_go.SetActive(false);
				start_go.SetActive(false);
			}
		}
		else if (pageIndex == 1) {
			title_fade -= Time.deltaTime * 2;
			background_go.GetComponent<SpriteRenderer>().color = new Color(1,1,1,title_fade);
			if (Input.GetMouseButton (0)) {
				int mask = 1 << 8;
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if(hit != null && hit.collider != null) {
					if(state == "character1 select") {
						if (hit.collider.gameObject.tag == "girl"){
							PlayerPrefs.SetString("Character1", "girl"); 
							state = "character1 name";
							girl_go.GetComponent<SpriteRenderer>().sprite = girl_glow_sprite;
						}
						if (hit.collider.gameObject.tag == "boy"){
							PlayerPrefs.SetString("Character1", "boy"); 
							state = "character1 name";
							boy_go.GetComponent<SpriteRenderer>().sprite = boy_glow_sprite;
						}
					}
					else if(state == "character1friend select") {
						if (hit.collider.gameObject.tag == "girl"){
							PlayerPrefs.SetString("Character1friend", "girl"); 
							state = "characterfriend1 name";
							girl_go.GetComponent<SpriteRenderer>().sprite = bff_girl_glow_sprite;
						}
						if (hit.collider.gameObject.tag == "boy"){
							PlayerPrefs.SetString("Character1friend", "boy"); 
							state = "characterfriend1 name";
							boy_go.GetComponent<SpriteRenderer>().sprite = bff_boy_glow_sprite;
						}
					}
					if(state == "character2 select") {
						if (hit.collider.gameObject.tag == "girl"){
							PlayerPrefs.SetString("Character2", "girl"); 
							state = "character2 name";
							girl_go.GetComponent<SpriteRenderer>().sprite = girl_glow_sprite;
						}
						if (hit.collider.gameObject.tag == "boy"){
							PlayerPrefs.SetString("Character2", "boy"); 
							state = "character2 name";
							boy_go.GetComponent<SpriteRenderer>().sprite = boy_glow_sprite;
						}
					}
					else if(state == "character2friend select") {
						if (hit.collider.gameObject.tag == "girl"){
							PlayerPrefs.SetString("Character2friend", "girl"); 
							state = "characterfriend2 name";
							girl_go.GetComponent<SpriteRenderer>().sprite = bff_girl_glow_sprite;
						}
						if (hit.collider.gameObject.tag == "boy"){
							PlayerPrefs.SetString("Character2friend", "boy"); 
							state = "characterfriend2 name";
							boy_go.GetComponent<SpriteRenderer>().sprite = bff_boy_glow_sprite;
						}
					}
				}
			}

			if(state == "character1 select") {
				textInput_go.SetActive(false);
				enter_your_name_subtext.SetActive(false);
				girl_go.GetComponent<SpriteRenderer>().sprite = girl_sprite;
				boy_go.GetComponent<SpriteRenderer>().sprite = boy_sprite;
				choose_your_character_subtext.GetComponent<SpriteRenderer>().sprite = choose_your_character_sprite;
			}
			else if(state == "character1 name") {
				choose_your_character_subtext.SetActive(false);
				textInput_go.SetActive(true);
				enter_your_name_subtext.SetActive(true);
				enter_your_name_subtext.GetComponent<SpriteRenderer>().sprite = enter_your_name_sprite;
			}
			else if(state == "character1friend select") {
				choose_your_character_subtext.SetActive(true);
				textInput_go.SetActive(false);
				enter_your_name_subtext.SetActive(false);
				girl_go.GetComponent<SpriteRenderer>().sprite = bff_girl_sprite;
				boy_go.GetComponent<SpriteRenderer>().sprite = bff_boy_sprite;
				choose_your_character_subtext.GetComponent<SpriteRenderer>().sprite = choose_bestfriend_character_sprite;
			}
			else if(state == "characterfriend1 name") {
				choose_your_character_subtext.SetActive(false);
				textInput_go.SetActive(true);
				enter_your_name_subtext.SetActive(true);
				enter_your_name_subtext.GetComponent<SpriteRenderer>().sprite = enter_bestfriends_name_sprite;
			}
			else if(state == "character2 select") {
				choose_your_character_subtext.SetActive(true);
				textInput_go.SetActive(false);
				enter_your_name_subtext.SetActive(false);
				girl_go.GetComponent<SpriteRenderer>().sprite = girl_sprite;
				boy_go.GetComponent<SpriteRenderer>().sprite = boy_sprite;
				choose_your_character_subtext.GetComponent<SpriteRenderer>().sprite = choose_your_character_sprite;
			}
			else if(state == "character2 name") {
				choose_your_character_subtext.SetActive(false);
				textInput_go.SetActive(true);
				enter_your_name_subtext.SetActive(true);
				enter_your_name_subtext.GetComponent<SpriteRenderer>().sprite = enter_your_name_sprite;
			}
			else if(state == "character2friend select") {
				choose_your_character_subtext.SetActive(true);
				textInput_go.SetActive(false);
				enter_your_name_subtext.SetActive(false);
				girl_go.GetComponent<SpriteRenderer>().sprite = bff_girl_sprite;
				boy_go.GetComponent<SpriteRenderer>().sprite = bff_boy_sprite;
				choose_your_character_subtext.GetComponent<SpriteRenderer>().sprite = choose_bestfriend_character_sprite;
			}
			else if(state == "characterfriend2 name") {
				choose_your_character_subtext.SetActive(false);
				textInput_go.SetActive(true);
				enter_your_name_subtext.SetActive(true);
				enter_your_name_subtext.GetComponent<SpriteRenderer>().sprite = enter_bestfriends_name_sprite;
			}
		}
	}
}
