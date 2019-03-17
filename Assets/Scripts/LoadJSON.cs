using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

//using UnityEditor;
//using LitJson;

public class LoadJSON : MonoBehaviour
{

	public string mapWidth;
	public string mapHight;
	public string numberOfHouses;
	public ArrayList nameTiles;
	public ArrayList tilesType;
	public ArrayList levelOfHouses;
	public ArrayList loadedJSONTiles;
	public TilesData[] readyTiles = new TilesData[7];

	private MapData mapData = new MapData ();
	private string filename = "Json-data.json";
	private string path;
	private string url = "https://gist.githubusercontent.com/anonymous/63de7fecde7289804f95619c9d20c7ad/raw/a6e24694cfbfef42fbb018283b5e570173a2e816/map.json";
	private WWW www;
	private string jsonData;

	void Start ()
	{
		path = Application.persistentDataPath + "/" + filename;
		//Debug.Log (path);
		StartCoroutine (GetJSON ());
	}

	IEnumerator GetJSON ()
	{
		WWW www = new WWW (url);
		yield return www;

		if (www.error == null) {
			File.WriteAllText (path, www.text);
			LoadData ();
		} else {
			Debug.Log ("ERROR: " + www.error);
		}        
	}
	// ------------------------------------ using JsonUtility ---------------------

	private void LoadData ()
	{
		jsonData = File.ReadAllText (path);
		//	Debug.Log (jsonData);
		mapData = JsonUtility.FromJson<MapData> (jsonData);
		mapData.levelOfTiles = new ArrayList ();
		mapData.typeOfTiles = new ArrayList ();
		mapData.nameOfTiles = new ArrayList ();
		for (int i = 0; i < mapData.tiles.Length; i++) {

			mapData.levelOfTiles.Add (mapData.tiles [i].level);
			mapData.nameOfTiles.Add (mapData.tiles [i].name);
			mapData.typeOfTiles.Add (mapData.tiles [i].type);

			readyTiles [i] = mapData.tiles [i];

		}

		mapHight = mapData.map_height;
		mapWidth = mapData.map_width;
		numberOfHouses = mapData.number_of_houses;
		tilesType = new ArrayList ();
		nameTiles = new ArrayList ();
		levelOfHouses = new ArrayList ();
		loadedJSONTiles = new ArrayList ();

		for (int i = 0; i < mapData.tiles.Length; i++) {

			tilesType.Add (mapData.typeOfTiles [i]);
			nameTiles.Add (mapData.nameOfTiles [i]);
			levelOfHouses.Add (mapData.levelOfTiles [i]);
			loadedJSONTiles.Add (mapData.tiles [i]);

		}
	}
}
