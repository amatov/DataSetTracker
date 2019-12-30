using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabIsLoggedIn : MonoBehaviour {

	[SerializeField]
	private GameObject Login;


	[SerializeField]
	private GameObject CreateAccount;


	[SerializeField]
	private GameObject LoggedIn;


	void Awake(){

		LoggedIn.SetActive (false);
		CreateAccount.SetActive (false);
		Login.SetActive (false);

		///Init ();
	}


	public void HideAllPopups(){
		
		LoggedIn.SetActive (false);
		CreateAccount.SetActive (false);
		Login.SetActive (false);

	}


	// Use this for initialization
	public void ShowLogin  () {

		LoggedIn.SetActive (true);

	}

	public void ShowCreateAccount(){

		LoggedIn.SetActive (false);
		CreateAccount.SetActive (true);
		Login.SetActive (false);

	}

}
