using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UXTracking : MonoBehaviour {

	[SerializeField]
	private GameObject menu;

	[SerializeField]
	private GameObject dialognostics;

	[SerializeField]
	private GameObject seekBar;

	private bool toggle = false;


	public void HideShowMenu(){
		
		menu.SetActive(toggle);
		dialognostics.SetActive(toggle);
		seekBar.SetActive(toggle);
		toggle = !toggle;

	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
