using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackData {

	//Data Class to store parameters
	public String myCSVData;


	//Constructors
	public TrackData (string mCSVData){
		myCSVData = mCSVData;

	}

	public string GetDataForObj(){

		return myCSVData;
	}
		

	 
}
