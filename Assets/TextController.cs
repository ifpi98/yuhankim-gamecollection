using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

	public GUIText playingGameHP;
	public GUIText playingGameTitle;
	int currentHP;
	string currentTitle;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
	
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		currentTitle = gameManager.seletedGameTitle;
		playingGameTitle.text = "Title : " + currentTitle;
	}
	
	// Update is called once per frame
	void Update () {
	
		currentHP = gameManager.seletedGameHP;
		playingGameHP.text = "HP : " + currentHP;
	}
}
