using UnityEngine;
using System.Collections;

public class _gameManager : MonoBehaviour {
	public GameObject player1_bff;
	public GameObject player2_bff;

	public Transform blood_splash;
	public Transform gameover_Popup;
	public GameObject player1_crusher;
	public GameObject player2_crusher;
	public GameObject gameover_splash;
	public AudioClip squish;
	bool splash = false;
	bool byebye = false;
	
	float popupDelay = 1f;
	
	// Use this for initialization
	void Start () {
		player1_bff.GetComponent<Animator>().SetBool("girl", PlayerPrefs.GetString("Character1friend") == "girl");
		player2_bff.GetComponent<Animator>().SetBool("girl", PlayerPrefs.GetString("Character2friend") == "girl");
	}
	
	// Update is called once per frame
	void Update () {
		if (!splash) {
			if (player1_crusher.GetComponentInChildren<_crusher>().crushed) {
				Instantiate(blood_splash, new Vector3(-8.2f, 2.21f, 0.0f), Quaternion.identity);
				AudioSource.PlayClipAtPoint(squish, transform.position);
				PlayerPrefs.SetString("Winner", PlayerPrefs.GetString("Character2_name"));
				splash = true;
			}
			if (player2_crusher.GetComponentInChildren<_crusher>().crushed) {
				Instantiate(blood_splash, new Vector3(8.2f, 2.21f, 0.0f), Quaternion.identity);
				AudioSource.PlayClipAtPoint(squish, transform.position);
				PlayerPrefs.SetString("Winner", PlayerPrefs.GetString("Character1_name"));
				splash = true;
			}
		}
		
		else {
			popupDelay -= Time.deltaTime * 3f;
			
			if (!byebye && popupDelay <= 0) {
				if (player1_crusher.GetComponentInChildren<_crusher>().crushed) {
					Instantiate(gameover_Popup, new Vector3(-8.2f, 2.21f, 0.0f), Quaternion.identity);
					Instantiate(gameover_splash, new Vector3(0.3f, 11.7f, -2f), Quaternion.identity);
					byebye = true;
				}
				if (player2_crusher.GetComponentInChildren<_crusher>().crushed) {
					Instantiate(gameover_Popup, new Vector3(8.2f, 2.21f, 0.0f), Quaternion.identity);
					Instantiate(gameover_splash, new Vector3(0.3f, 11.7f, -2f), Quaternion.identity);
					byebye = true;
				}
			}
		}
	}
}
