using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateMap : MonoBehaviour
{

	private TilesData dataFromTilesData;
	public GameObject map;
	private GameObject container;
	private RectTransform mapRectTransform;
	private RectTransform grassRectTransform;
	private bool isOpen;
	private GameObject grass;
	private int currentNoOfHouses;

	public Canvas canvas;
	public DeleteConstructionSites deleteConstruction;
	public GameObject grasss;
	public GameObject trees1;
	public GameObject trees2;
	public GameObject barracks;
	public GameObject storage;
	public GameObject sand;
	public GameObject water;
	public Text numberOfHousesText;
	public Text numberOfHouses;
	public LoadJSON loadedJson;
	public Canvas ContainerForMessage;


	void Start ()
	{
		ContainerForMessage.gameObject.SetActive (false);
		StartCoroutine (LoadNumberOfHouses ());
		StartCoroutine (GetNumberOfHouses ());
		StartCoroutine (CreateMapPrefab4 ());
	}

	void Update ()
	{
		StartCoroutine (GetNumberOfUpdatedHouses ());
	}

	public IEnumerator LoadNumberOfHouses ()
	{
		yield return new WaitForSeconds (1);
		currentNoOfHouses = int.Parse (loadedJson.numberOfHouses);
	}

	public IEnumerator CreateMapPrefab4 ()
	{
		yield return new WaitForSeconds (1);
		map = Instantiate<GameObject> (Resources.Load<GameObject> ("Map"));
		map.transform.SetParent (transform, false);
		mapRectTransform = map.GetComponent<RectTransform> ();

		//MapData mapData = new MapData ();

		Quaternion spawnRotation = Quaternion.identity;
		grass = Instantiate<GameObject> (Resources.Load<GameObject> ("Grass"));
		grassRectTransform = grass.GetComponent<RectTransform> ();
		grass.gameObject.SetActive (false);

		// ------------ grassRectTransform.rect.width = 57f ----------------
		// ------------ mapRectTransform.rect.width = 512f ----------------
		Vector3[] spawnPositionGrass = 
			new[] {
// row 1			
				//1
				//	new Vector3(-227.5f, 227.5f, 0f), 
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),			
				//2
				//	new Vector3(-170.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f), 
				//3
				//new Vector3(-113.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),
				//4
//			new Vector3(-56.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),
				//5
//			new Vector3(0.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),
				//6
//			new Vector3(57.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),
				//7
//			new Vector3(114.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f), 
				//8
//			new Vector3(171.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),
				//9
//			new Vector3 (228.5f, 227.5f, 0f),
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - grassRectTransform.rect.height / 2), 0f),
// row 2
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),		
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f), 
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height)), 0f),
// row 3
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),	
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),		
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f), 
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),
// row 4
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
// row 5
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
// row 6
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
// row 7
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),	
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),

			};

		Vector3[] spawnPositionTrees1 = 
			new[] {
// row 3 
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),
// row 4
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),

// row 6
//			//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f), 

			};

		Vector3[] spawnPositionTrees2 = 
			new[] {
// row 4				
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
// row5
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
			};

		Vector3[] spawnPositionBarrack = 
			new[] {
// row 3				
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 2)), 0f),
// row 4
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 3)), 0f),
			};

		Vector3[] spawnPositionStorage = 
			new[] {
// row 6				
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
// row 6
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),

			};

		Vector3[] spawnPositionSand = 
			new[] {
// row 5
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 4)), 0f),
// row 6			
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 5)), 0f),
// row 7			
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),	
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),	
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),	
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),	
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 6)), 0f),	
// row 8			
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),
				//6
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),
// row 9		
				//1
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),
				//2
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),
				//3
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 2), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),
				//4
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 3), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),
				//5
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 4), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),
				//6

				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 5), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),
			};

		Vector3[] spawnPositionWater = 
			new[] {
// row 8
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),	
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),	
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 7)), 0f),	
// row 9			
				//7
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 6), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),	
				//8
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 7), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),	
				//9
				new Vector3 ((-mapRectTransform.rect.width / 2) + (grassRectTransform.rect.width / 2 + grassRectTransform.rect.width * 8), (mapRectTransform.rect.height / 2 - (grassRectTransform.rect.height / 2 + grassRectTransform.rect.height * 8)), 0f),	
			};

		float mapWidthFloat = float.Parse (loadedJson.mapWidth);
		float mapHightFloat = float.Parse (loadedJson.mapHight);
		mapRectTransform.sizeDelta = new Vector2 (mapWidthFloat, mapHightFloat);

		for (int j = 0; j < spawnPositionGrass.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "grass") {
					GameObject instGrass = Instantiate (grasss, spawnPositionGrass [j], spawnRotation);
					
					string typeOfTile = loadedJson.tilesType [i].ToString ();
					grasss.GetComponent<GrassTile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					grasss.GetComponent<GrassTile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					grasss.GetComponent<GrassTile> ().levelOfTile = levelOfTile;


					instGrass.transform.SetParent (map.transform, false);
					instGrass.transform.localPosition = spawnPositionGrass [j];
				}
			}
		}
////----------------------------------Trees1-----------------------------------------------------------------------------------
		for (int j = 0; j < spawnPositionTrees1.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "trees1") {

					GameObject instTrees1 = Instantiate (trees1, spawnPositionTrees1 [j], spawnRotation);
					
					string typeOfTile = loadedJson.tilesType [i].ToString ();
					trees1.GetComponent<Trees1Tile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					trees1.GetComponent<Trees1Tile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					trees1.GetComponent<Trees1Tile> ().levelOfTile = levelOfTile;

					instTrees1.transform.SetParent (map.transform, false);
					instTrees1.transform.localPosition = spawnPositionTrees1 [j];
				}
			}
		}
		// -------------------------------Trees2----------------------------------------------------------
		for (int j = 0; j < spawnPositionTrees2.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "trees2") {
	
					GameObject instTrees2 = Instantiate (trees2, spawnPositionTrees2 [j], spawnRotation);

					string typeOfTile = loadedJson.tilesType [i].ToString ();
					trees2.GetComponent<Trees2Tile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					trees2.GetComponent<Trees2Tile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					trees2.GetComponent<Trees2Tile> ().levelOfTile = levelOfTile;

					instTrees2.transform.SetParent (map.transform, false);
					instTrees2.transform.localPosition = spawnPositionTrees2 [j];
				}
			}
		}
		// ------------------------------------------------------------------------------------------

		// -------------------------------Barrack----------------------------------------------------------
		for (int j = 0; j < spawnPositionBarrack.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "house1") {

					GameObject instBarrack = Instantiate (barracks, spawnPositionBarrack [j], spawnRotation);

					string typeOfTile = loadedJson.tilesType [i].ToString ();
					barracks.GetComponent<BarrackTile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					barracks.GetComponent<BarrackTile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					barracks.GetComponent<BarrackTile> ().levelOfTile = levelOfTile;

					instBarrack.transform.SetParent (map.transform, false);
					instBarrack.transform.localPosition = spawnPositionBarrack [j];
				}
			}
		}

		// ------------------------------------------------------------------------------------------

		// -------------------------------Storage----------------------------------------------------------
		for (int j = 0; j < spawnPositionStorage.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "house2") {

					GameObject instStorage = Instantiate (storage, spawnPositionStorage [j], spawnRotation);

					string typeOfTile = loadedJson.tilesType [i].ToString ();
					storage.GetComponent<StorageTile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					storage.GetComponent<StorageTile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					storage.GetComponent<StorageTile> ().levelOfTile = levelOfTile;

					instStorage.transform.SetParent (map.transform, false);
					instStorage.transform.localPosition = spawnPositionStorage [j];
				}
			}
		}

		// ------------------------------------------------------------------------------------------

		// -------------------------------Sand----------------------------------------------------------
		for (int j = 0; j < spawnPositionSand.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "sand") {
	
					GameObject instSand = Instantiate (/*mapData.tiles[i]*/sand, spawnPositionSand [j], spawnRotation);

					string typeOfTile = loadedJson.tilesType [i].ToString ();
					sand.GetComponent<SandTile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					sand.GetComponent<SandTile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					sand.GetComponent<SandTile> ().levelOfTile = levelOfTile;

					instSand.transform.SetParent (map.transform, false);
					instSand.transform.localPosition = spawnPositionSand [j];
				}
			}
		}

		// ------------------------------------------------------------------------------------------

		// -------------------------------Water----------------------------------------------------------
		for (int j = 0; j < spawnPositionWater.Length; j++) {
			for (int i = 0; i < loadedJson.tilesType.Count; i++) {
				if (loadedJson.tilesType [i].ToString () == "water") {

					GameObject instWater = Instantiate (water, spawnPositionWater [j], spawnRotation);

					string typeOfTile = loadedJson.tilesType [i].ToString ();
					water.GetComponent<WaterTile> ().typeOfTile = typeOfTile;
					string nameOfTile = loadedJson.nameTiles [i].ToString ();
					water.GetComponent<WaterTile> ().nameOfTile = nameOfTile;
					int levelOfTile = int.Parse (loadedJson.levelOfHouses [i].ToString ());
					water.GetComponent<WaterTile> ().levelOfTile = levelOfTile;

					instWater.transform.SetParent (map.transform, false);
					instWater.transform.localPosition = spawnPositionWater [j];
				}
			}
		}

		// ------------------------------------------------------------------------------------------

	}

	public IEnumerator GetNumberOfHouses ()
	{
		
		yield return new WaitForSeconds (1);
		ContainerForMessage.gameObject.SetActive (true);
		numberOfHousesText.text = "Number of houses: ";
		string numberHouses = loadedJson.numberOfHouses;
		numberOfHouses.text = numberHouses;
	}

	public IEnumerator GetNumberOfUpdatedHouses ()
	{
		yield return new WaitForSeconds (1);
		ContainerForMessage.gameObject.SetActive (true);
		numberOfHousesText.text = "Number of houses: ";
		if (deleteConstruction.isDeleted) {

			currentNoOfHouses -= 1;
			deleteConstruction.isDeleted = false;
			string numberHouses = currentNoOfHouses.ToString ();
			numberOfHouses.text = numberHouses;
		}

	}

}
