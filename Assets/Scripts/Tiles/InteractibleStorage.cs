using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractibleStorage : MonoBehaviour, IPointerDownHandler
{

	private Image tileInfoImage;
	private TileInfo tileInfo;
	private string type;
	private StorageTile storageTile;
	private Image closeImage;
	private Text closeText;
	private Image deleteImage;
	private Text deleteText;
	private Image selection;
	private RectTransform rectTransform;

	public static Vector3 positionOfTileStorage;

	void Start ()
	{
		storageTile = GetComponent<StorageTile> ();
		rectTransform = GetComponent<RectTransform> ();
		tileInfoImage = GameObject.FindGameObjectWithTag ("Message").GetComponent<Image> ();
		selection = GameObject.FindGameObjectWithTag ("Selection").GetComponent<Image> ();
		closeImage = GameObject.FindGameObjectWithTag ("Close").GetComponent<Image> ();
		closeText = GameObject.FindGameObjectWithTag ("CloseText").GetComponent<Text> ();
		deleteImage = GameObject.FindGameObjectWithTag ("Delete").GetComponent<Image> ();
		deleteText = GameObject.FindGameObjectWithTag ("DeleteText").GetComponent<Text> ();
		tileInfo = FindObjectOfType<TileInfo> ();

		tileInfoImage.enabled = false;
		closeImage.enabled = false;
		closeText.enabled = false;
		deleteImage.enabled = false;
		deleteText.enabled = false;
		selection.enabled = false;
		tileInfo.levelOfTile.enabled = false;
		tileInfo.nameOfTile.enabled = false;
	}

	public void OnPointerDown (PointerEventData pointerEventData)
	{
		try {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hit; 

			if (Physics.Raycast (ray, out hit)) {
	
				if (hit.transform.GetComponent<StorageTile> ().typeOfTile == "house2") {

					Vector3 positionOfTile = hit.collider.transform.position;
					positionOfTileStorage = positionOfTile;
					Vector3	adjustedPositionOfTile = Camera.main.WorldToScreenPoint (positionOfTile);
					float postionY = rectTransform.rect.height * 2.5f;
					tileInfoImage.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y + postionY, 0f);
					selection.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y, 0f);	
					tileInfoImage.enabled = true;
					closeImage.enabled = true;
					tileInfo.levelOfTile.enabled = true;
					tileInfo.nameOfTile.enabled = true;
					selection.enabled = true;
					closeText.enabled = true;
					deleteImage.enabled = true;
					deleteText.enabled = true;
					tileInfo.nameOfTile.text = storageTile.nameOfTile;
					tileInfo.levelOfTile.text = "Level " + (GetComponent<StorageTile> ().levelOfTile).ToString ();

				} else {
					Debug.Log ("Geting type of tile went wrong..."); 
				}
			} else {
				Debug.Log ("Raycast went wrong..."); 

			}
		} catch (System.Exception e) {
			Debug.Log (e.ToString ());

		}
	}
}

