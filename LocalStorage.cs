using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStorage : MonoBehaviour {

	// Class to store player prefs on device


	// set prefs
	public void SetPrefLoggedInCustomID() {
		PlayerPrefs.SetInt("LoggedInCustomID", 1);
	}


	public void SetPrefLoggedInCustomIDandEmail() {
		PlayerPrefs.SetInt("LoggedInCustomID", 2);
	}


	 public int GetPrefLoggedIn() {

		//get player prefs from device
		int iLoggedinPref;

		iLoggedinPref = PlayerPrefs.GetInt("LoggedInCustomID");

		if (iLoggedinPref == null) {
			return 0;
		}

		// see what data is stored
		switch (iLoggedinPref)
		{

		case 1:
				Debug.Log ("LocalStorage: Custom ID stored on device.");
				return 1;
				break;
			case 2:
				Debug.Log ("LocalStorage: Custom ID stored on device. User has created account.");
				return 2;
				break;
			default:
				Debug.Log ("LocalStorage: Return 0");
				return 0;
				break;

		}


	}
}
