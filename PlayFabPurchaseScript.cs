using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabPurchaseScript : MonoBehaviour {

	[SerializeField]
	private playFabLogin playFabloginScript;


	[SerializeField]
	private UXPlayFab uxPlayFab;

	[SerializeField]
	private Text debugPurchaseText;

	private string OrderID;
	private string ProviderName;
	private string Currency;
	private string ProviderTransactionID;
	private string CatalogueVersion;

	private int iCountRetry = 0;
	private int iMaxCount = 5;

	private int iManualCheckCounter = 0;
	private int iManualMaxCheckCounter = 3;

	//https://api.playfab.com/docs/tutorials/landing-commerce/non-receipt-payment-processing

	void Start(){

		CatalogueVersion =  GetComponent<playFabSKU> ().sPlayFabCataloguieVersionNumber;

	}

	//###########################################################################################################
	// Start Purchase 
	//###########################################################################################################
	public void onStartPurchase(string itemID, uint quantity, string annotation )
	{
		ItemPurchaseRequest itemToPurchase = new ItemPurchaseRequest();
		itemToPurchase.ItemId = itemID;
		itemToPurchase.Quantity = quantity;
		itemToPurchase.Annotation = annotation;

		StartPurchaseRequest startRequest = new StartPurchaseRequest(); 
		startRequest.CatalogVersion = CatalogueVersion;
		startRequest.Items = new List<ItemPurchaseRequest> ();
		startRequest.Items.Add(itemToPurchase);

		Debug.Log ("onStartPurchase");
		PlayFabClientAPI.StartPurchase(startRequest, onStartPurchaseResult, onStartPurchaseError);
	}


	private void onStartPurchaseResult(StartPurchaseResult result)
	{

		OrderID = result.OrderId;
		ProviderName = result.PaymentOptions [0].ProviderName;
		Currency = result.PaymentOptions [0].Currency;

		Debug.Log ("Start Purchase Result");
		onPayForPurchase ();

	}

	private void onStartPurchaseError(PlayFabError error)
	{
		Debug.LogWarning("Something went wrong with your purchase call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
	}

	//###########################################################################################################
	// PayForPurchase Purchase 
	//###########################################################################################################
	public void onPayForPurchase()
	{
		
		PayForPurchaseRequest payRequest = new PayForPurchaseRequest(); 
		payRequest.Currency = Currency;
		payRequest.ProviderName = ProviderName;
		payRequest.OrderId = OrderID;

		Debug.Log ("onPayForPurchase");
		PlayFabClientAPI.PayForPurchase(payRequest, onPurchaseResult, onPurchaseError);
	}


	private void onPurchaseResult(PayForPurchaseResult result)
	{
		debugPurchaseText.text = "onPayForPurchaseResult" + "\n\n" + result.PurchaseConfirmationPageURL;

		Application.OpenURL(result.PurchaseConfirmationPageURL);

	
	}

	private void onPurchaseError(PlayFabError error)
	{
		Debug.LogWarning("Something went wrong with your purchase call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
	}


	//###########################################################################################################
	// Confirm Purchase 
	//###########################################################################################################
	public void onConfirmPurchase()
	{


		ConfirmPurchaseRequest confirmRequest = new ConfirmPurchaseRequest(); 
		confirmRequest.OrderId = OrderID;

		//debugPurchaseText.text = "onPayForPurchase";

		PlayFabClientAPI.ConfirmPurchase(confirmRequest, onConfirmResult, onConfirmError);

		uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal");
	}


	private void onConfirmResult(ConfirmPurchaseResult result)
	{
		debugPurchaseText.text = "onConfirmPurchaseResult" + "\n\n" + result.Items[0].ItemId + " purchased at " + result.Items[0].PurchaseDate + " for " + result.Items[0].UnitPrice;

		uxPlayFab.UpdatePaymentText ("Thanks for your purchase");

		uxPlayFab.ShowThanksButton ();

	
	}

	private void onConfirmError(PlayFabError error)
	{
		//Debug.LogWarning("Something went wrong with your purchase call.  :(");
		Debug.Log("On Confirmation: Here's some debug information:");
		Debug.Log(error.GenerateErrorReport());


		if (iCountRetry <= iMaxCount) {
			StartCoroutine (CheckPurchaseCoroutine (5f));
		} else {

			uxPlayFab.UpdatePaymentText ("When you have finished making payment through PayPal\n\nclick the button below");
			uxPlayFab.ShowTryAgainButton ();
		}

		//error.ErrorMessage;
	}





	//###############################################################################################################
	// Poll Server
	//###############################################################################################################

	public void PollServerForConfirmation(string itemID, uint quantity, string annotation ){

		StartCoroutine(PurchaseCoroutine(itemID, quantity, annotation));

	}

	IEnumerator PurchaseCoroutine (string itemID, uint quantity, string annotation )
	{

		print("Purchasing " + itemID + ", " +  quantity + ", " + annotation);

		yield return new WaitForSeconds(3f);

		onStartPurchase (itemID, quantity, annotation);

		uxPlayFab.UpdatePaymentText ("Please make payment through PayPal as requested");

		yield return new WaitForSeconds(20f);

		onConfirmPurchase ();

	}


	IEnumerator CheckPurchaseCoroutine (float delay)
	{
		iCountRetry = iCountRetry + 1;

		switch (iCountRetry) {

		case 1:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + ".");
			break;
		case 2:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "..");
			break;
		case 3:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "...");
			break;
		case 4:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + ".");
			break;
		case 5:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "..");
			break;
		case 6:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "...");
			break;
		case 7:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + ".");
			break;
		case 8:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "..");
			break;
		case 9:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "...");
			break;
		case 10:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + ".");
			break;
		case 11:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "..");
			break;
		default:
			uxPlayFab.UpdatePaymentText ("Validating purchase from PayPal" + "...");
			break;

		}



		yield return new WaitForSeconds(delay);

		onConfirmPurchase ();

	}

	public void ManuallyCheckPurchase(){
	
		iManualCheckCounter = iManualCheckCounter + 1;

		if (iManualCheckCounter >= iManualMaxCheckCounter) {

			uxPlayFab.UpdatePaymentText ("\n\n\nThere was a problem validating your payment via PayPal.\nYou need to complete your payment through the PayPal browser that was loaded at the start of the payment flow.\nIf you have paid for the purchase successfully and need assistance. Please contatct support@datasetanalysis.com.\n\nWe will aim to respond in 24 hours.");
			//show cancel button
			uxPlayFab.HideTryAgainButton ();
			uxPlayFab.ShowCancelButton();

		} else {

			uxPlayFab.UpdatePaymentText ("Attempting to validate purchase\n\n" + iManualCheckCounter + " of " + iManualMaxCheckCounter + " attempts");
			onConfirmPurchase ();
			uxPlayFab.HideTryAgainButton ();

		}
	
	
	}

}
