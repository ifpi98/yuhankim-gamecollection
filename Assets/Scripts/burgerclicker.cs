using UnityEngine;
using System.Collections;

public class burgerclicker : MonoBehaviour {

	public GUISkin blocky;
	int score;
	int multiplier;
	public Texture burger;
	public Texture shop;
	public Texture upgrade1;
	public Texture musictex;
	public Texture golibrary;
	public int immigs;
	public int teen;
	public int indiv;
	public int ceo;
	public AudioClip clicksound;
	public AudioClip shopsound;
	public AudioClip closesound;
	public AudioClip musicsound;
	bool isshop;
	bool music;


	void Awake(){

		Screen.SetResolution (1280, 720, false);


		//PlayerPrefs.SetInt ("multi", 1);
		isshop = false;
		music = true;
	}

	void Update () {

		if(Input.GetKeyDown (KeyCode.R)){
			PlayerPrefs.DeleteAll();
		}

		if(Input.GetKeyDown (KeyCode.F1)){
			PlayerPrefs.SetInt ("score", score + 1000);
		}

		score = PlayerPrefs.GetInt ("score");
		multiplier = PlayerPrefs.GetInt ("multi");
		immigs = PlayerPrefs.GetInt ("immigrants");
		teen = PlayerPrefs.GetInt ("teens");
		indiv = PlayerPrefs.GetInt ("indiv");
		ceo = PlayerPrefs.GetInt ("ceo");
	}

	void OnGUI() {

		GUI.skin = blocky;

		GUI.Box (new Rect (10, 10, 220, 50), "Money: " + score);
		GUI.Box (new Rect (225, 10, 215, 50),"Mxplier: +" + multiplier);

		if (GUI.Button (new Rect (Screen.width / 2 + 195, 10, 50, 50), shop)) {
			isshop = true;
			GetComponent<AudioSource>().PlayOneShot (closesound);
		}
		if (GUI.Button (new Rect (Screen.width / 2 + 195, 70, 50, 50), musictex)) {


			if(music == false){
				GetComponent<AudioSource>().PlayOneShot (musicsound);
				music = true;
				Debug.Log(music);

			}
			if(music == true){
				music = false;
				GetComponent<AudioSource>().Stop ();
				Debug.Log(music);
			}

		}
		if (GUI.Button (new Rect (Screen.width / 2 + 195, 130, 50, 50), golibrary)) {
			GetComponent<AudioSource>().PlayOneShot (closesound);
			Application.LoadLevel("1 - LibraryScene");
		}



		if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2, 300, 300), burger)) {
			PlayerPrefs.SetInt ("score", score + 1 +multiplier);
			GetComponent<AudioSource>().PlayOneShot (clicksound);
		}

		if (isshop) {

			GUI.Box (new Rect (10, Screen.height-300, 220, 50), "Money: " + score);
			GUI.Box (new Rect (225, Screen.height-300, 215, 50),"Mxplier: +" + multiplier);
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Shop");
			GUI.Label (new Rect(10,30, 400, 30), "Money: $" + score + " MxPlier: " + multiplier);
			if (GUI.Button (new Rect (10, 60, 300, 100), "Illegal Immigrant [-100] " + "[" + immigs + "]") && score >= 100) {
				PlayerPrefs.SetInt ("multi", multiplier + 1);
				PlayerPrefs.SetInt ("score", score -100);
				PlayerPrefs.SetInt ("immigrants", immigs + 1);
				//Debug.Log ("bought immigrant" + immigs);
				GetComponent<AudioSource>().PlayOneShot (shopsound);
			}
			if (GUI.Button (new Rect (10, 170, 300, 100), "Angsty Teenager [-300] " + "[" + teen + "]") && score >= 300) {
				PlayerPrefs.SetInt ("multi", multiplier + 5);
				PlayerPrefs.SetInt ("score", score -300);
				PlayerPrefs.SetInt ("teens", teen + 1);
				GetComponent<AudioSource>().PlayOneShot (shopsound);

			}
			if (GUI.Button (new Rect (10, 280, 400, 100), "Well Rounded Individual [-1,000] " + "[" + indiv + "]") && score >= 1000) {
				PlayerPrefs.SetInt ("multi", multiplier + 20);
				PlayerPrefs.SetInt ("score", score -1000);
				PlayerPrefs.SetInt ("indiv", indiv + 1);
				GetComponent<AudioSource>().PlayOneShot (shopsound);
				
			}
			if (GUI.Button (new Rect (10, 390, 400, 100), "Former CEO [-10,000] " + "[" + ceo + "]") && score >= 10000) {
				PlayerPrefs.SetInt ("multi", multiplier + 100);
				PlayerPrefs.SetInt ("score", score -10000);
				PlayerPrefs.SetInt ("ceo", ceo + 1);
				GetComponent<AudioSource>().PlayOneShot (shopsound);
				
			}
			if (GUI.Button (new Rect (10, 710, 100, 30), "Close")) {
				isshop = false;
				GetComponent<AudioSource>().PlayOneShot (closesound);
			}
		}
	}



	}







