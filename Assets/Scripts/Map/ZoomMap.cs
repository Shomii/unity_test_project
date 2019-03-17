using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomMap : MonoBehaviour
{

	public CreateMap mapObject;
	public Text ZoomInText;
	public Text ZoomOutText;
	public Image ZoomInButton;
	public Image ZoomOutButton;
	public Text zoomText;
	public Image selection;
	public Image containerForMessage;

	void Start ()
	{
		zoomText.enabled = false;
	}

	public void ZoomIn ()
	{
		StartCoroutine (ZoomInCoroutine ());
	}

	public void ZoomOut ()
	{
		StartCoroutine (ZoomOutCoroutine ());
	}

	public IEnumerator ZoomInCoroutine ()
	{

		if (mapObject.map.gameObject.transform.localScale.x == 3f) {
			//	Debug.Log ("No more zoom in ...");

			zoomText.enabled = true;
			zoomText.text = "Max Zoom in";
			yield return new WaitForSeconds (1);
			zoomText.enabled = false;
	
		} else {

			mapObject.map.gameObject.transform.localScale += new Vector3 (1, 1, 0);
			selection.transform.localScale += new Vector3 (1, 1, 0);

			StartCoroutine (DisplayZoom ());
		}
	}

	public IEnumerator ZoomOutCoroutine ()
	{

		if (mapObject.map.gameObject.transform.localScale.x == 1f) {
			//	Debug.Log ("No more zoom out ...");

			zoomText.enabled = true;
			zoomText.text = "Max Zoom out";
			yield return new WaitForSeconds (1);
			zoomText.enabled = false;
	
		} else {

			mapObject.map.gameObject.transform.localScale -= new Vector3 (1, 1, 0);
			selection.transform.localScale -= new Vector3 (1, 1, 0);
	
			StartCoroutine (DisplayZoom ());	
		}

	}

	public IEnumerator DisplayZoom ()
	{
		if (mapObject.map.gameObject.transform.localScale.x == 2f) {

			zoomText.enabled = true;
			zoomText.text = "Zoom 2x";
			yield return new WaitForSeconds (1);
			zoomText.enabled = false;
		}

		if (mapObject.map.gameObject.transform.localScale.x == 3f) {

			zoomText.enabled = true;
			zoomText.text = "Zoom 3x";
			yield return new WaitForSeconds (1);
			zoomText.enabled = false;

		}
	}
}
