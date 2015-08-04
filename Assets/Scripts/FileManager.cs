using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System;

public class FileManager : MonoBehaviour 
{
	bool _ShouldSave, _ShouldLoad, _SwitchSave, _SwitchLoad;
	string _FileLocation, _FileName;
	string sFilePath;
	
	private static Hero_Test2 hData = null;
	public static Data listData = null;

	public Data ListData
	{
		get{return listData;}
	}




		
	void Start()
	{

		DontDestroyOnLoad (gameObject);
		//listData = new Data();

		// 사용하는 플랫폼을 체크하여, PC일 때의 폴더의 주소를 등록 
		if (Application.platform == RuntimePlatform.WindowsWebPlayer || 
		    Application.platform == RuntimePlatform.WindowsEditor ||
		    Application.platform == RuntimePlatform.OSXPlayer ||
		    Application.platform == RuntimePlatform.OSXEditor)
		{
			_FileLocation = Application.dataPath;
		}
		// 사용하는 플랫폼을 체크하여, 안드로이드일 때의 폴더의 주소를 등록 
		else if (Application.platform == RuntimePlatform.Android)
		{
			_FileLocation = Application.persistentDataPath;
		}
		
		HeroLoadData ();  	// 히어로 로드 데이터 함수를 호출
		GameListLoad ();

		Debug.Log(ListData.GameList[0].HP);
		Debug.Log(ListData.GameList[0].Title);
		//listData.GameData[0].HP;


	}
	
	void Update()
	{



	
	}
	
	public void HeroLoadData()
	{
		Load<Hero_Test2>(ref hData, "DATA", "Hero1");  // 히어로 데이터를 로드
	}
	public void GameListLoad()
	{
		Load<Data>(ref listData, "DATA", "GameList");  // 히어로 데이터를 로드
	}

	void Load<T> (ref T Data, string folder, string fileName) 	// 파일 로드 구문
	{
		TextAsset tt = Resources.Load(folder+"/"+fileName) as TextAsset;
		StringReader sr = new StringReader(tt.text);
		string _info = sr.ReadToEnd();
		
		if (_info.ToString() != "")
		{
			UTF8Encoding encoding = new UTF8Encoding();
			byte[] byteArray = encoding.GetBytes(_info);
			
			XmlSerializer xs = new XmlSerializer(typeof(T));
			MemoryStream memoryStream = new MemoryStream(byteArray);
			
			Data = (T)xs.Deserialize(memoryStream);
			Debug.Log("SSSS" + Data);

		}	/// 파일 로드 구문
	}
	
}


	public class Hero_Test2
	{
		public Heroinfo[] Hero = new Heroinfo[4];	// XML의 데이터 구조를 가져올 공간을 만듬
		
		public struct Heroinfo // 구조체를 생성
		{
			public int ID;	// XML의 속성들
			public string Name;
			public int Hp;
			public int ATK;
		}
	}
	
	public class Data
	{
	public GameData[] GameList = new GameData[32];	// XML의 데이터 구조를 가져올 공간을 만듬

	public struct GameData // 구조체를 생성
		{
			public int ID;
			public string Title;
			public int Company;
			public int Size;
			public int Rank;
			public float Price;
			public int Language;
			public int HP;
			public int Proper_PC_Grade;
			public int Region;
			public int MetacriticPoint;
			public int PridePoint;
		}
	}



