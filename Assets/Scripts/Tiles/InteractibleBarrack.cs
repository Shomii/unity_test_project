using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractibleBarrack : MonoBehaviour, IPointerDownHandler
{

	private Image tileInfoImage;
	private Image closeImage;
	private TileInfo tileInfo;
	private string type;
	private BarrackTile barrackTile;
	private Text closeText;
	private Image deleteImage;
	private Text deleteText;
	private Image selection;
	public static Vector3 positionOfTileBarrack;
	private float time;
	private int tap;
	private RectTransform rectTransform;

	void Start ()
	{
		barrackTile = GetComponent<BarrackTile> ();
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

			Ray rayBarrack = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hitBarrack; 

			if (Physics.Raycast (rayBarrack, out hitBarrack)) {

				if (hitBarrack.transform.GetComponent<BarrackTile> ().typeOfTile == "house1") {

					Vector3 positionOfTile = hitBarrack.collider.transform.position;
					positionOfTileBarrack = positionOfTile;
					float postionY = rectTransform.rect.height * 2.5f;
					Vector3	adjustedPositionOfTile = Camera.main.WorldToScreenPoint (positionOfTile);
					tileInfoImage.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y + postionY, 0f);
					selection.transform.position = new Vector3 (adjustedPositionOfTile.x, adjustedPositionOfTile.y, 0f);

					tileInfoImage.enabled = true;
					closeImage.enabled = true;

					tileInfo.levelOfTile.enabled = true;
					tileInfo.nameOfTile.enabled = true;
					closeText.enabled = true;
					deleteImage.enabled = true;
					selection.enabled = true;
					deleteText.enabled = true;
					tileInfo.nameOfTile.text = barrackTile.nameOfTile;
					tileInfo.levelOfTile.text = "Level " + (GetComponent<BarrackTile> ().levelOfTile).ToString ();

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
