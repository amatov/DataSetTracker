using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour {

	public bool MenuIsVisible = true;


	public void ToggleMenu(){


		if (MenuIsVisible) {

			//hide menu
			gameObject.transform.position = new Vector3(gameObject.transform.position.x - 380, gameObject.transform.position.y, gameObject.transform.position.z);

		} else {

			//show menu
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + 380, gameObject.transform.position.y, gameObject.transform.position.z);


		}



		MenuIsVisible = !MenuIsVisible;




	}



}
