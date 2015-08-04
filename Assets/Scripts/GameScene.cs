using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

	int seletedGameID;

	// Use this for initialization
	void Start () {
	
		seletedGameID = Random.Range (0, 21);
		Debug.Log ("Seleted Game ID is " + seletedGameID);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStart ()
	{
		// 받은 게임 아이디 번호를 이용하여, 해당 게임 데이터를 가져와 게임화면으로 전환한다.
		PlayerPrefs.SetInt ("seletedGameID", seletedGameID);
		Debug.Log (seletedGameID);
		Application.LoadLevel("2 - GameScene");

	}
}
