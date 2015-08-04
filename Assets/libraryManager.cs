using UnityEngine;
using System.Collections;

public class libraryManager : MonoBehaviour {

	int nowLastCount;
	int[] gameHP;
	Data adata; 
	//GameData gamelist = GameObject.t
	//FileManager gameData = gameObject.GetComponent<FileManager>;
	//Data gameData = gameObject.GetComponent<Data>;


		// Use this for initialization
	void Start () {
	
	//	DontDestroyOnLoad(this);
		adata = GameObject.Find("DataManager").GetComponent<FileManager>().ListData;
		nowLastCount = 20;
		gameHP = new int[nowLastCount];

			//gameHP[i] = adata.GameList[i].HP;				

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
