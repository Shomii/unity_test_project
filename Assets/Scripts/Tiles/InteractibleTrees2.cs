using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractibleTrees2 : MonoBehaviour, IPointerDownHandler
{

	private Image tileInfoImage;
	private TileInfo tileInfo;
	private string type;
	private Trees2Tile trees2Tile;
	private Image closeImage;
	private Text closeText;
	private Image deleteImage;
	private Text deleteText;
	private Image selection;
	private RectTransform rectTransform;

	void Start ()
	{
		trees2Tile = GetComponent<Trees2Tile> ();
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
		
				if (hit.transform.GetComponent<Trees2Tile> ().typeOfTile == "trees2") {
					tileInfoImage.enabled = false;
					closeImage.enabled = false;
					closeText.enabled = false;
					deleteImage.enabled = false;
					deleteText.enabled = false;
					tileInfo.levelOfTile.enabled = false;
					tileInfo.nameOfTile.enabled = false;
					Vector3 positionOfTile = hit.collider.transform.position;
					float postionY = rectTransform.rect.height * 2.5f;
					Vector3	adjustedPositionOfTile = Camera.main.WorldToScreenPoint (positionOfTile);
					tileInfoImage.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y + postionY, 0f);
					selection.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y, 0f);
					tileInfoImage.enabled = true;
					closeImage.enabled = true;
					selection.enabled = true;
					tileInfo.nameOfTile.enabled = true;
					closeText.enabled = true;
					tileInfo.nameOfTile.text = trees2Tile.nameOfTile;
					tileInfo.levelOfTile.text = "Level " + (GetComponent<Trees2Tile> ().levelOfTile).ToString ();

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
