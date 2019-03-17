using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractibleGrass : MonoBehaviour, IPointerDownHandler
{

	private Image tileInfoImage;
	private TileInfo tileInfo;
	private string type;
	private Image closeImage;
	private GrassTile grassTile;
	private Text closeText;
	private RectTransform rectTransform;
	private Image deleteImage;
	private Image selection;
	private Text deleteText;

	private float time;

	void Start ()
	{
		

		rectTransform = GetComponent<RectTransform> ();
		tileInfoImage = GameObject.FindGameObjectWithTag ("Message").GetComponent<Image> ();
		selection = GameObject.FindGameObjectWithTag ("Selection").GetComponent<Image> ();
		closeImage = GameObject.FindGameObjectWithTag ("Close").GetComponent<Image> ();
		closeText = GameObject.FindGameObjectWithTag ("CloseText").GetComponent<Text> ();
		deleteImage = GameObject.FindGameObjectWithTag ("Delete").GetComponent<Image> ();
		deleteText = GameObject.FindGameObjectWithTag ("DeleteText").GetComponent<Text> ();
		tileInfo = FindObjectOfType<TileInfo> ();

		tileInfoImage.enabled = false;
		selection.enabled = false;
		closeImage.enabled = false;
		closeText.enabled = false;
		deleteImage.enabled = false;
		deleteText.enabled = false;
		tileInfo.levelOfTile.enabled = false;
		tileInfo.nameOfTile.enabled = false;
	}

	public void OnPointerDown (PointerEventData pointerEventData)
	{
		try {
			Ray rayGrass = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hitGrass; 

			if (Physics.Raycast (rayGrass, out hitGrass)) {
				if (hitGrass.transform.GetComponent<GrassTile> ().typeOfTile == "grass") {

					tileInfoImage.enabled = false;
					closeImage.enabled = false;
					closeText.enabled = false;
					deleteImage.enabled = false;
					deleteText.enabled = false;
					selection.enabled = false;
					tileInfo.levelOfTile.enabled = false;	
					tileInfo.nameOfTile.enabled = false;

					Vector3 positionOfTile = hitGrass.collider.transform.position;

					Vector3	adjustedPositionOfTile = Camera.main.WorldToScreenPoint (positionOfTile);
					float postionY = rectTransform.rect.height * 2.5f;

					tileInfoImage.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y + postionY, 0f);
					selection.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y, 0f);

					selection.enabled = true;	
					tileInfoImage.enabled = true;
					closeImage.enabled = true;
					tileInfo.nameOfTile.enabled = true;
					closeText.enabled = true;
					tileInfo.nameOfTile.text = GetComponent<GrassTile> ().nameOfTile;
					tileInfo.levelOfTile.text = "Level " + (GetComponent<GrassTile> ().levelOfTile).ToString ();
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
