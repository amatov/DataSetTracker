using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MaterialUI;

public class UXPlayFab : MonoBehaviour {

	[SerializeField]
	private GameObject WelcomePopup;

	[SerializeField]
	private GameObject LoginPopup;


	[SerializeField]
	private GameObject CreateAccount;


	[SerializeField]
	private GameObject LoggedIn;

	[SerializeField]
	private GameObject ErrorPopup;

	[SerializeField]
	private GameObject HomePopup;

	[SerializeField]
	private Text ErrorTextPopup;


	[SerializeField]
	private Text sDisplayTitle_Product01;


	[SerializeField]
	private Text sDisplayDescription_Product01;


	[SerializeField]
	private Text sItemID_Product01;


	[SerializeField]
	private Text sPrice_Product01;


	[SerializeField]
	private Text sDisplayTitle_Product02;


	[SerializeField]
	private Text sDisplayDescription_Product02;


	[SerializeField]
	private Text sItemID_Product02;


	[SerializeField]
	private Text sPrice_Product02;


	[SerializeField]
	private MaterialButton bTryButton01;

	[SerializeField]
	private MaterialButton bTryButton02;

	[SerializeField]
	private MaterialButton bBuyButton01;

	[SerializeField]
	private MaterialButton bBuyButton02;

	[SerializeField]
	private MaterialButton bGoButton01;

	[SerializeField]
	private MaterialButton bGoButton02;


	[SerializeField]
	private MaterialButton bThanksButton;


	[SerializeField]
	private Text TextTerms01;

	[SerializeField]
	private Text TextTerms02;

	[SerializeField]
	private GameObject paymentThinking;

	[SerializeField]
	private GameObject homeGUI;



	[SerializeField]
	private GameObject particleMain;

	[SerializeField]
	private Text paymentThinkingText;

	[SerializeField]
	private MaterialButton buttonTryAgain;

	[SerializeField]
	private MaterialButton buttonCancel;

	private playFabLogin _PlayFabLogin;


	void Awake(){

		ErrorPopup.SetActive (false);
		LoggedIn.SetActive (false);
		CreateAccount.SetActive (false);
		WelcomePopup.SetActive (false);
		HomePopup.SetActive (false);
		LoginPopup.SetActive (false);

		///Init ();
	}


	public void HideAllPopups(){
		
		LoggedIn.SetActive (false);
		CreateAccount.SetActive (false);
		LoginPopup.SetActive (false);
		HomePopup.SetActive (false);
		WelcomePopup.SetActive (false);
		particleMain.SetActive (true);
		particleMain.SetActive (true);


	}

	public void ShowWelcome(){
		HideAllPopups ();
		WelcomePopup.SetActive (true);
	}


	public void ShowHome(){

		float fAmountDollars;
		List<sku> skusPlayFab = GetComponent<playFabSKU> ().catalogueSkus;
		homeGUI.SetActive (true);
		paymentThinkingText.text = "";
		paymentThinking.SetActive (false);
		particleMain.SetActive (true);
		bThanksButton.transform.gameObject.SetActive (false);


		int iCount = skusPlayFab.Count;

		for (int i = 0; i < iCount; i++){

			//Product 01
			if (i == 0) {
			
				sDisplayTitle_Product01.text = skusPlayFab [i].sDisplayName;
				sDisplayDescription_Product01.text   = skusPlayFab [i].sDescription;
				sItemID_Product01.text  = skusPlayFab [i].sItemID;

				fAmountDollars = (float)skusPlayFab [i].sAmount;
				fAmountDollars = fAmountDollars / 100;

				if (fAmountDollars == 0) {
					sPrice_Product01.text = "";
				} else {
					sPrice_Product01.text = fAmountDollars.ToString ("C", System.Globalization.CultureInfo.GetCultureInfo ("en-us"));
				}

				if (skusPlayFab [i].sPurchased == true) {

					TextTerms01.text = "You own this product";
					TextTerms01.alignment = TextAnchor.MiddleCenter;

					bGoButton01.transform.gameObject.SetActive (true);
					bTryButton01.transform.gameObject.SetActive (false);
					bBuyButton01.transform.gameObject.SetActive (false);

				} else {
					TextTerms01.text = "12 month license";
					TextTerms01.alignment = TextAnchor.MiddleLeft;
					bGoButton01.transform.gameObject.SetActive (false);
					bTryButton01.transform.gameObject.SetActive (true);
					bBuyButton01.transform.gameObject.SetActive (true);

				}


			}
			//Product 02
			if (i == 1) {

				sDisplayTitle_Product02.text = skusPlayFab [i].sDisplayName;
				sDisplayDescription_Product02.text   = skusPlayFab [i].sDescription;
				sItemID_Product02.text  = skusPlayFab [i].sItemID;

				fAmountDollars = (float)skusPlayFab [i].sAmount;
				fAmountDollars = fAmountDollars / 100;

				if (fAmountDollars == 0) {
					sPrice_Product02.text = "";
				} else {
					sPrice_Product02.text = fAmountDollars.ToString ("C", System.Globalization.CultureInfo.GetCultureInfo ("en-us"));
				}

				if (skusPlayFab [i].sPurchased == true) {
					TextTerms02.text = "You own this product";
					TextTerms02.alignment = TextAnchor.MiddleCenter;
					bGoButton02.transform.gameObject.SetActive (true);
					bTryButton02.transform.gameObject.SetActive (false);
					bBuyButton02.transform.gameObject.SetActive (false);

				} else {
					TextTerms02.text = "12 month license";
					TextTerms02.alignment = TextAnchor.MiddleLeft;
					bGoButton02.transform.gameObject.SetActive (false);
					bTryButton02.transform.gameObject.SetActive (true);
					bBuyButton02.transform.gameObject.SetActive (true);

				}

			}

		}
			
		HideAllPopups ();

		buttonTryAgain.transform.gameObject.SetActive (false);
		buttonCancel.transform.gameObject.SetActive (false);
		HomePopup.SetActive (true);
	}


	public void buyProduct01(){

		PlayFabPurchaseScript purchaseScript;

		purchaseScript = GetComponent<PlayFabPurchaseScript> ();

		paymentThinkingText.text = "Redirecting to PayPal";
		paymentThinking.SetActive (true);
		particleMain.SetActive (false);
		homeGUI.SetActive (false);

		purchaseScript.PollServerForConfirmation (sItemID_Product01.text, 1, sDisplayTitle_Product01.text);


	}

	public void buyProduct02(){


		PlayFabPurchaseScript purchaseScript;

		purchaseScript = GetComponent<PlayFabPurchaseScript> ();

		paymentThinkingText.text = "Redirecting to PayPal";

		paymentThinking.SetActive (true);
		particleMain.SetActive (false);
		homeGUI.SetActive (false);

		purchaseScript.PollServerForConfirmation (sItemID_Product02.text, 1, sDisplayTitle_Product02.text);
	
	}


	public void ShowLoginPopup(){
		HideAllPopups ();
		LoginPopup.SetActive (true);
	}

	public void ShowErrorPopup(string ErrorText){
		ErrorPopup.SetActive (true);
		ErrorTextPopup.text = ErrorText;
	}

	public void HideErrorPopup(){
		ErrorPopup.SetActive (false);
	}

	// Use this for initialization
	public void ShowLoggedIn  () {
		HideAllPopups ();
		LoggedIn.SetActive (true);

	}

	public void ShowCreateAccount(){
		HideAllPopups ();
		CreateAccount.SetActive (true);
		//here
	}



	public void ShowEB(){

		SceneManager.LoadScene ("001");

	}


	public void ShowBlots(){

		SceneManager.LoadScene ("002");

	}

	public void ShowCancelButton(){

		buttonCancel.transform.gameObject.SetActive (true);

	}



	public void ShowTryAgainButton(){
	
		buttonTryAgain.transform.gameObject.SetActive (true);
	
	}

	public void HideTryAgainButton(){

		buttonTryAgain.transform.gameObject.SetActive (false);

	}
	public void UpdatePaymentText(string stringPayMentText){

		paymentThinkingText.text = stringPayMentText;

	}

	public void ShowThanksButton(){

		bThanksButton.transform.gameObject.SetActive (true);

	}

	public void RestartApp(){

		SceneManager.LoadScene ("Login");

	}

}
