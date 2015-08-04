using UnityEngine;
using System.Collections;

public class ShopScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShopStart ()
	{
		// 받은 게임 아이디 번호를 이용하여, 해당 게임 데이터를 가져와 게임화면으로 전환한다.
		Debug.Log("Go to GameShop");
		Application.LoadLevel("3 - ShopScene");
		
	}
}

