using UnityEngine;
using System.Collections;

public class Library : MonoBehaviour {

	int gameID;
	int gameHP;


	// Use this for initialization
	void Start () {
	
		if (gameObject.GetComponent<GameManager>() != null) 
		{
			gameID = gameObject.GetComponent<GameManager> ().seletedGameID;
			gameHP = gameObject.GetComponent<GameManager> ().seletedGameHP;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LibraryJustGo()
	{
		Application.LoadLevel("1 - LibraryScene");
	}

	public void LibraryGo(int gameID, int gameHP)
	{
		PlayerPrefs.SetInt ("playedGameId", gameID);
		PlayerPrefs.SetInt ("playedGameHP", gameHP);
		Application.LoadLevel("1 - LibraryScene");
	}
}
