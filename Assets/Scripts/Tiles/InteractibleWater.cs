using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractibleWater : MonoBehaviour, IPointerDownHandler
{

	private Image tileInfoImage;
	private TileInfo tileInfo;
	private string type;
	private WaterTile waterTile;
	private Image closeImage;
	private Text closeText;
	private Image deleteImage;
	private Text deleteText;
	private Image selection;
	private RectTransform rectTransform;

	void Start ()
	{
		waterTile = GetComponent<WaterTile> ();
		rectTransform = GetComponent<RectTransform> ();
		tileInfoImage = GameObject.FindGameObjectWithTag ("Message").GetComponent<Image> ();
		selection = GameObject.FindGameObjectWithTag ("Selection").GetComponent<Image> ();
		closeImage = GameObject.FindGameObjectWithTag ("Close").GetComponent<Image> ();
		closeText = GameObject.FindGameObjectWithTag ("CloseText").GetComponent<Text> ();
		deleteImage = GameObject.FindGameObjectWithTag ("Delete").GetComponent<Image> ();
		deleteText = GameObject.FindGameObjectWithTag ("DeleteText").GetComponent<Text> ();
		tileInfo = FindObjectOfType<TileInfo> ();

		// Disabling message window until OnPointerDown and RayCast enable it to show information

		tileInfoImage.enabled = false;
		closeImage.enabled = false;
		closeText.enabled = false;
		deleteImage.enabled = false;
		deleteText.enabled = false;
		selection.enabled = false;
		tileInfo.levelOfTile.enabled = false;
		tileInfo.nameOfTile.enabled = false;

	}
	// Using RayCast to detect what tile type was selected
	// and then diplay message above that position

	public void OnPointerDown (PointerEventData pointerEventData)
	{

		try {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hit; 

			if (Physics.Raycast (ray, out hit)) {

				if (hit.transform.GetComponent<WaterTile> ().typeOfTile == "water") {
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
					selection.enabled = true;
					closeImage.enabled = true;
					tileInfo.nameOfTile.enabled = true;
					closeText.enabled = true;
					tileInfo.nameOfTile.text = waterTile.nameOfTile;
					tileInfo.levelOfTile.text = "Level " + (GetComponent<WaterTile> ().levelOfTile).ToString ();

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
