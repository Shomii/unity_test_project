using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeleteConstructionSites : MonoBehaviour
{

	private GameObject[] barrackForDelete;
	private GameObject[] storageForDelete;
	private Vector3 locationBarrack;
	private Vector3 locationStorage;
	private GameObject grass;
	private GameObject instGrass;

	public Image tileInfoImage;
	public Image closeImage;
	public Text levelOfTile;
	public Text nameOfTile;
	public Text closeText;
	public Image deleteImage;
	public Text deleteText;
	public bool isDeleted = false;



	public void DeleteConstruction ()
	{
		locationBarrack = InteractibleBarrack.positionOfTileBarrack;
		locationStorage = InteractibleStorage.positionOfTileStorage;

		barrackForDelete = GameObject.FindGameObjectsWithTag ("Barrack");
		storageForDelete = GameObject.FindGameObjectsWithTag ("Storage");

		if (GameObject.FindGameObjectWithTag ("Barrack")) {

			for (int i = 0; i < barrackForDelete.Length; i++) {

				if (barrackForDelete [i].transform.position == locationBarrack) {

					barrackForDelete [i].transform.position = locationBarrack;

					Destroy (barrackForDelete [i]);
					isDeleted = true;
					grass = Instantiate<GameObject> (Resources.Load<GameObject> ("Grass"));
					instGrass = GameObject.FindGameObjectWithTag ("Map");
					grass.transform.SetParent (instGrass.transform, false);
					grass.transform.position = new Vector3 (locationBarrack.x, locationBarrack.y, 0f);

					tileInfoImage.enabled = false;
					closeImage.enabled = false;
					closeText.enabled = false;
					deleteImage.enabled = false;
					deleteText.enabled = false;
					levelOfTile.enabled = false;
					nameOfTile.enabled = false;
				}
			}
		} 

		if (GameObject.FindGameObjectWithTag ("Storage")) {

			storageForDelete = GameObject.FindGameObjectsWithTag ("Storage");

			for (int i = 0; i < storageForDelete.Length; i++) {

				if (storageForDelete [i].transform.position == locationStorage) {
	
					storageForDelete [i].transform.position = locationStorage;
					Destroy (storageForDelete [i]);
					isDeleted = true;
					grass = Instantiate<GameObject> (Resources.Load<GameObject> ("Grass"));
					instGrass = GameObject.FindGameObjectWithTag ("Map");
					grass.transform.SetParent (instGrass.transform, false);
					grass.transform.position = locationStorage;

					tileInfoImage.enabled = false;
					closeImage.enabled = false;
					closeText.enabled = false;
					deleteImage.enabled = false;
					deleteText.enabled = false;
					levelOfTile.enabled = false;
					nameOfTile.enabled = false;
				}

			}
		}
	}

}
