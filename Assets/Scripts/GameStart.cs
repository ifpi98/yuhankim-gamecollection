using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	private float flickeringtime;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		flickeringtime = flickeringtime + Time.deltaTime;

		if (Input.anyKeyDown)
		{
			Application.LoadLevel("1 - LibraryScene");
		}
	}

	void OnGUI()
	{
		if (flickeringtime < 1)
		{
			GUI.Label(new Rect(200, 200, 250, 250), "화면을 터치하세요!");
		}
		if (flickeringtime > 2)
		{
			flickeringtime = 0;
		}
	}

}
