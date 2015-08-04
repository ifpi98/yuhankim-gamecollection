using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	Data adata; 
	Library library;
	public int seletedGameID;
	public int seletedGameHP;
	public string seletedGameTitle;
	public float gameDeltaTime;

	// Use this for initialization
	void Start () {
	
		seletedGameID = PlayerPrefs.GetInt ("seletedGameID");
		Debug.Log (seletedGameID);
		adata = GameObject.Find ("DataManager").GetComponent<FileManager> ().ListData;
		library = gameObject.GetComponent<Library> ();
		seletedGameHP = adata.GameList [seletedGameID].HP;
		seletedGameTitle = adata.GameList [seletedGameID].Title;
		gameDeltaTime = 0;

	}
	
	// Update is called once per frame
	void Update () {

		gameDeltaTime = gameDeltaTime + Time.deltaTime;
	
		if (gameDeltaTime > 0.5) 
		{
			seletedGameHP = seletedGameHP - 10;
			gameDeltaTime = 0;
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			seletedGameHP = seletedGameHP - 100;
		}

		if (seletedGameHP <= 0) 
		{
			library.LibraryGo(seletedGameID,seletedGameHP);
		}

	}
}
