using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using UnityEngine.UI;

public class playFabLogin : MonoBehaviour
{

	private playFabSKU _playFabSku;
	public Text sAccountEmail;
	public Text sAccountPassword;

	public Text sLoginEmail;
	public Text sLoginPassword;

	public Text sTitleNews;


	public string sCustomID;



	public string sTitleID;
	public bool bDeveloperMode = false;
	public bool bDeveloperModeKillPrefs = false;

	public string sDevelopRandomKey;

	private UXPlayFab uxPlayFab;

	[SerializeField]
	private LocalStorage localStorage;


	//Playfab code
	// https://api.playfab.com/docs/general-getting-started


	void Start(){

		_playFabSku = GetComponent<playFabSKU> ();
		uxPlayFab = GetComponent<UXPlayFab> ();


		if (bDeveloperMode == true) {

			uxPlayFab.ShowErrorPopup ("Developer Mode is on");
			//return;
		}



		if (bDeveloperModeKillPrefs == true) {
		
			PlayerPrefs.DeleteAll ();

		}

		CheckUser ();
	}

	void CheckUser(){

		//check if user is logged in with custom ID (1) and if account is setup (2)
		if (localStorage.GetPrefLoggedIn ()== 1) {
			Debug.Log ("1    Player Pref located");
			FirstTimeUser ();
		}

		if (localStorage.GetPrefLoggedIn()== 2) {
			Debug.Log ("2    Player Pref located with account");


			FirstTimeUser ();
			//If user is offline Check here!
			//CheckRights ();


		}

		if (localStorage.GetPrefLoggedIn()== 0) {
			Debug.Log ("0     Player Pref empty");
			FirstTimeUser ();
		}

	}


	void FirstTimeUser(){


		PlayFabSettings.TitleId = sTitleID; // Please change this value to your own titleId from PlayFab Game Manager

		if (bDeveloperMode) {
			//developer mode
			sCustomID = sDevelopRandomKey;
		
		} else {

			// live mode
			sCustomID = SystemInfo.deviceUniqueIdentifier;
		
		}

		onStartAppCheckUser ();

	}
		
	//###########################################################################################################
	//Check if users CustomID exists for first Time user
	//###########################################################################################################
	public void onStartAppCheckUser()
	{
		//NEED TO CHECK IF WE ARE CONNECTED FIRST

		var request = new LoginWithCustomIDRequest { CustomId = sCustomID, CreateAccount = false};

		PlayFabClientAPI.LoginWithCustomID(request, OnFirstTimeUserCustomIDCreated, OnFirstTimeUserError);

		uxPlayFab.HideAllPopups ();
	}


	private void OnFirstTimeUserCustomIDCreated(LoginResult result)
	{
	
		//localStorage.SetPrefLoggedInCustomID ();
		// User Custom ID is known check if they have email created

		onCheckUserDetails(result.PlayFabId);
	
	}

	private void OnFirstTimeUserError(PlayFabError error)
	{

		if (PlayFabErrorCode.AccountNotFound == error.Error) {
			Debug.LogWarning("OnFirstTimeUserError: Can find account for this device. Show login/create account");
			uxPlayFab.ShowWelcome ();

		} else {
			Debug.LogWarning("Something went wrong with your first API call.  :(");
			Debug.LogError("Here's some debug information:");
			Debug.LogError(error.GenerateErrorReport());
		}

	}

	//###########################################################################################################
	//Check if user email password are stored
	//###########################################################################################################
	public void onCheckUserDetails(string sPlayFabID)
	{
		//NEED TO CHECK IF WE ARE CONNECTED FIRST

		var request = new GetAccountInfoRequest { PlayFabId = sPlayFabID};

		PlayFabClientAPI.GetAccountInfo(request, OnUserDetailsResult, OnUserDetailsResultError);

		uxPlayFab.HideAllPopups ();
	}

	private void OnUserDetailsResult(GetAccountInfoResult result)
	{

		// User Custom ID is known check if they have email created
		if (result.AccountInfo.PrivateInfo.Email == null) {
			//user needs to add email

			Debug.Log ("User needs to create more account information");
			uxPlayFab.ShowCreateAccount ();

		} else {
		
			// good to go!
			Debug.Log ("User:" + result.AccountInfo.Username);
			localStorage.SetPrefLoggedInCustomIDandEmail();
			CheckRights ();
		
		}

	}
		
	private void OnUserDetailsResultError(PlayFabError error)
	{
		Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
		uxPlayFab.ShowErrorPopup ("There was an error requesting your details from the server" + "\n\n" + error.ErrorMessage);
	}


	//###########################################################################################################
	//Create Account with Custom ID
	//###########################################################################################################
	public void CreateCustomID()
	{
		
		var request = new LoginWithCustomIDRequest { CustomId = sCustomID, CreateAccount = true};

		PlayFabClientAPI.LoginWithCustomID(request, CreatedCustomID, CreatCustomIDError);

		uxPlayFab.HideAllPopups ();
	}


	private void CreatedCustomID(LoginResult result)
	{

		//localStorage.SetPrefLoggedInCustomID ();
		// User Custom ID is known check if they have email created
		Debug.Log("CreatedCustomID");
		localStorage.SetPrefLoggedInCustomID();
		uxPlayFab.ShowCreateAccount ();

	}

	private void CreatCustomIDError(PlayFabError error)
	{

		Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
		uxPlayFab.ShowErrorPopup ("There was an creating an account." + "\n\n" + error.ErrorMessage);


	}


	//###########################################################################################################
	//Updated CustomID Account with username and password
	//###########################################################################################################

	public void UpdateCustomIDwithUsernamePassword()
	{

		String sUserName = GetUniqueID ();

		var request = new AddUsernamePasswordRequest {Username = sUserName,  Email = sAccountEmail.text.Trim(), Password = sAccountPassword.text.Trim()};
		PlayFabClientAPI.AddUsernamePassword(request, CreatedEmail, CreatedAccountError);

	}


	private void CreatedEmail(AddUsernamePasswordResult result)
	{

		//localStorage.SetPrefLoggedInCustomID ();
		// User Custom ID is known check if they have email created
		localStorage.SetPrefLoggedInCustomIDandEmail();
		uxPlayFab.HideAllPopups ();

		// good to go!
		CheckRights ();
	}

	private void CreatedAccountError(PlayFabError error)
	{

		Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
		uxPlayFab.ShowErrorPopup ("There was an error creating an account." + "\n\n" + error.ErrorMessage);


	}

	//###########################################################################################################
	//Login with username and password
	//###########################################################################################################

	public void LoginWithUsername()
	{
		var request = new LoginWithEmailAddressRequest {Email = sLoginEmail.text.Trim(), Password = sLoginPassword.text.Trim()};

		PlayFabClientAPI.LoginWithEmailAddress(request, LoginOK, LoginError);
	}


	private void LoginOK(LoginResult result)
	{

		//localStorage.SetPrefLoggedInCustomID ();
		// User Custom ID is known check if they have email created
		localStorage.SetPrefLoggedInCustomIDandEmail();
		uxPlayFab.HideAllPopups ();

		// good to go!
		CheckRights ();
	}

	private void LoginError(PlayFabError error)
	{

		Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
		uxPlayFab.ShowErrorPopup ("There was an error logging into your account." + "\n\n" + error.ErrorMessage);

	}


	//###########################################################################################################
	// Check account rights
	//###########################################################################################################
	void CheckRights(){

		uxPlayFab.HideAllPopups ();

		GetTitleNews ();
		_playFabSku.playFabGetCatalogue ();



		Debug.Log("Account is.... Good to Go!!! Loading catalogue");


		//uxPlayFab.ShowHome ();
	}



	//###########################################################################################################
	// Get Title News
	//###########################################################################################################
	void GetTitleNews(){

		var request = new GetTitleNewsRequest {Count=5};
		PlayFabClientAPI.GetTitleNews(request, TitleNewsResult, TitleNewsError);

	}


	private void TitleNewsResult(GetTitleNewsResult result)
	{
		//Show title news


		sTitleNews.text = result.News [0].Title + "\n\n" + result.News [0].Body  + "\n\n" + result.News [0].Timestamp;


	}

	private void TitleNewsError(PlayFabError error)
	{
		Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
		//uxPlayFab.ShowErrorPopup ("There was an error creating an account." + "\n\n" + error.ErrorMessage);
		sTitleNews.text = "There was an error getting the latest news."; 
	}




	//Generate Developer Unioque Key
	public static string GetUniqueID(){
		string key = "ID";

		var random = new System.Random();                     
		DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;

		string uniqueID = ""                            //Language
			+String.Format("{0:X}", Convert.ToInt32(timestamp))                //Time
			+String.Format("{0:X}", Convert.ToInt32(Time.time*1000000));        //Time in game

		Debug.Log("Generated Unique ID: "+uniqueID);
			
		return uniqueID;
	}



	//Get Title Data

//	public void ClientGetTitleData()
//	{
//		var getRequest = new ClientModels.GetTitleDataRequest();
//		PlayFabClientAPI.GetTitleData(getRequest, (result) => {
//			Debug.Log("Got the following titleData:");
//			foreach (var entry in result.Data)
//			{
//				Debug.Log(entry.Key + ": " + entry.Value);
//			}
//		},
//			(error) => {
//				Debug.Log("Got error getting titleData:");
//				Debug.Log(error.ErrorMessage);
//			});
//	}
}
