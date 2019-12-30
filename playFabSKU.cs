using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class playFabSKU : MonoBehaviour {

	public string sPlayFabCataloguieVersionNumber;

	public List<sku> catalogueSkus;

	//###########################################################################################################
	// Get Catalogiue from Playfab
	//###########################################################################################################
	// get a list of all skus available to user
	public void playFabGetCatalogue(){
		onGetCatalogue ();
	}


	public void onGetCatalogue()
	{
		GetCatalogItemsRequest catalogueRequest = new GetCatalogItemsRequest();
		catalogueRequest.CatalogVersion = sPlayFabCataloguieVersionNumber;
		PlayFabClientAPI.GetCatalogItems(catalogueRequest, onCatalogueResult, onCatalogueError);
	}


	private void onCatalogueResult(GetCatalogItemsResult result)
	{

		Debug.Log ("Got items from Catalogue. No of items returned is:" + result.Catalog.Count);

		int iCount = result.Catalog.Count;

		catalogueSkus = new List<sku>();

		//now add to sku list

		//NOTE: only supports dollars

		uint Cash;

		for (int i = 0; i < iCount; i++){
			result.Catalog [i].VirtualCurrencyPrices.TryGetValue ("RM", out Cash);
			catalogueSkus.Add(new sku(false,result.Catalog[i].ItemId, result.Catalog[i].DisplayName, result.Catalog[i].Description, Cash));
		}


		//Check rights
		GetInventory ();



			
	}


	//###########################################################################################################
	// Get User Inventory from Playfab
	//###########################################################################################################
	// get a list of all skus available to user that they own

	public void GetInventory()
	{
		GetUserInventoryRequest getUserInventoryRequest = new GetUserInventoryRequest();

		PlayFabClientAPI.GetUserInventory(getUserInventoryRequest, onGetUserInventoryResult, onCatalogueError);
	}



	private void onGetUserInventoryResult(GetUserInventoryResult result)
	{

		int iCount = catalogueSkus.Count;
		int iCountResult = result.Inventory.Count;


		//loop through each item in catalogue and see if we own it
		for (int i = 0; i < iCount; i++){


			//loop through api result for inventory ownership details
			for (int iAPI = 0; iAPI < iCountResult; iAPI++){
			
				if (catalogueSkus [i].sItemID == result.Inventory [iAPI].ItemId) {
						//we won it!
					catalogueSkus[i].sPurchased = true;
					catalogueSkus [i].sAmount = 0;
					catalogueSkus [i].sDescription = "";

				}
			}
		}
	
		GetComponent<UXPlayFab> ().ShowHome ();

	}





	private void onCatalogueError(PlayFabError error)
	{
		Debug.LogWarning("Something went wrong with your purchase call.  :(");
		Debug.LogError("Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
	}



	void AddSkU(){
	
		
		
	
	}


	//

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
