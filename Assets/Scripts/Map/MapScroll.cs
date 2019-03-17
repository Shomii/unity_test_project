using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapScroll : MonoBehaviour, IDragHandler
{

	private bool isDragging;
	private Image tileInfoImage;
	private TileInfo tileInfo;
	private string type;
	private Image closeImage;
	private Text closeText;
	private Image deleteImage;
	private Image selection;
	private Text deleteText;
	private Vector3 draggingOffset;
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private float mapWidthFloat;
	private float mapHightFloat;

	void Start ()
	{
		tileInfoImage = GameObject.FindGameObjectWithTag ("Message").GetComponent<Image> ();
		selection = GameObject.FindGameObjectWithTag ("Selection").GetComponent<Image> ();
		closeImage = GameObject.FindGameObjectWithTag ("Close").GetComponent<Image> ();
		closeText = GameObject.FindGameObjectWithTag ("CloseText").GetComponent<Text> ();
		deleteImage = GameObject.FindGameObjectWithTag ("Delete").GetComponent<Image> ();
		deleteText = GameObject.FindGameObjectWithTag ("DeleteText").GetComponent<Text> ();
		tileInfo = FindObjectOfType<TileInfo> ();

	}

	void Update ()
	{
		if (isDragging) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition) + draggingOffset;
			if (transform.localScale.x == 1f) {
	
				minX = -3.3f;
				maxX = 3.3f;
				minY = -1.4f;
				maxY = 1.4f;

				transform.position = new Vector3 (Mathf.Clamp (pos.x, minX, maxX), Mathf.Clamp (pos.y, minY, maxY), 0f);
	
			} else if (transform.localScale.x == 2f) {
				minX = -9.5f;
				maxX = 9.5f;
				minY = -7.6f;
				maxY = 7.6f;
				transform.position = new Vector3 (Mathf.Clamp (pos.x, minX, maxX), Mathf.Clamp (pos.y, minY, maxY), 0f);
			} else if (transform.localScale.x == 3f) {
				minX = -15.9f;
				maxX = 15.9f;
				minY = -14.1f;
				maxY = 14.1f;
				transform.position = new Vector3 (Mathf.Clamp (pos.x, minX, maxX), Mathf.Clamp (pos.y, minY, maxY), 0f);	
			}
		}
	}

	public void OnMouseDown ()
	{

		draggingOffset = transform.position - Camera.main.ScreenToWorldPoint (Input.mousePosition);
		isDragging = true;
	}

	public void OnMouseUp ()
	{
		isDragging = false;
	}

	public void OnDrag (PointerEventData data)
	{
		if (isDragging) {

			tileInfoImage.enabled = false;
			selection.enabled = false;
			closeImage.enabled = false;
			closeText.enabled = false;
			deleteImage.enabled = false;
			deleteText.enabled = false;
			tileInfo.levelOfTile.enabled = false;
			tileInfo.nameOfTile.enabled = false;

		}

	}


}
