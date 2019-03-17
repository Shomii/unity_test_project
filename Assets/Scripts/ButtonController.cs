using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonController : MonoBehaviour
{

	public Image message;
	public Image close;
	public Image delete;
	public Text levelOfTile;
	public Image selection;
	public Text nameOfTile;
	public Text closeText;
	public Text deleteText;
	public DeleteConstructionSites deleteConstruction;

	private GameObject grass;
	private GameObject objectForDelete;


	public void CloseMessage ()
	{
	
		message.enabled = false;
		close.enabled = false;
		delete.enabled = false;
		deleteText.enabled = false;
		selection.enabled = false;
		levelOfTile.enabled = false;
		nameOfTile.enabled = false;
		closeText.enabled = false;
	}

	public void DeleteTile ()
	{
		deleteConstruction.DeleteConstruction ();
	}

}
