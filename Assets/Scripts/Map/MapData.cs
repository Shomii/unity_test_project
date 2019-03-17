using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MapData
{

	public string map_width;
	public string map_height;
	public string number_of_houses;
	public TilesData[] tiles;

	public ArrayList nameOfTiles;
	public ArrayList typeOfTiles;
	public ArrayList levelOfTiles;

}

[Serializable]
public class TilesData
{

	public string type;
	public string name;
	public int level;
}
