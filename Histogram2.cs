using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Histogram2 : MonoBehaviour {


	//This is a static array. The number in the array needs to be set at build time. 
	public LineRenderer[] HistoBars2;

	[SerializeField]
	private OpenCVUpdateLoop openCVloop;

	//etc

	// Use this for initialization
	void Start () {

		//set the top point of the line
		HistoBars2[0].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[1].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[2].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[3].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[4].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[5].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[6].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[7].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[8].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[9].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[10].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[11].SetPosition(1, new Vector3(0, 0, 0));		 
		HistoBars2[12].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[13].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[14].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[15].SetPosition(1, new Vector3(0, 0, 0));		 
		HistoBars2[16].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[17].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[18].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[19].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[20].SetPosition(1, new Vector3(0, 0, 0));
 		HistoBars2[21].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[22].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars2[23].SetPosition(1, new Vector3(0, 0, 0));
  
	}
	
	// Update is called once per frame
	void Update () {
		HistoBars2[0].SetPosition(1, new Vector3(0, openCVloop.Spe0, 0));
		HistoBars2[1].SetPosition(1, new Vector3(0, openCVloop.Spe1, 0));
		HistoBars2[2].SetPosition(1, new Vector3(0, openCVloop.Spe2, 0));
		HistoBars2[3].SetPosition(1, new Vector3(0, openCVloop.Spe3, 0));
		HistoBars2[4].SetPosition(1, new Vector3(0, openCVloop.Spe4, 0));
		HistoBars2[5].SetPosition(1, new Vector3(0, openCVloop.Spe5, 0));		 
		HistoBars2[6].SetPosition(1, new Vector3(0, openCVloop.Spe6, 0));
		HistoBars2[7].SetPosition(1, new Vector3(0, openCVloop.Spe7, 0));
		HistoBars2[8].SetPosition(1, new Vector3(0, openCVloop.Spe8, 0));
		HistoBars2[9].SetPosition(1, new Vector3(0, openCVloop.Spe9, 0));
		HistoBars2[10].SetPosition(1, new Vector3(0, openCVloop.Spe10, 0));		 
		HistoBars2[11].SetPosition(1, new Vector3(0, openCVloop.Spe11, 0));
		HistoBars2[12].SetPosition(1, new Vector3(0, openCVloop.Spe12, 0));
		HistoBars2[13].SetPosition(1, new Vector3(0, openCVloop.Spe13, 0));
		HistoBars2[14].SetPosition(1, new Vector3(0, openCVloop.Spe14, 0));
		HistoBars2[15].SetPosition(1, new Vector3(0, openCVloop.Spe15, 0));
		HistoBars2[16].SetPosition(1, new Vector3(0, openCVloop.Spe16, 0));
		HistoBars2[17].SetPosition(1, new Vector3(0, openCVloop.Spe17, 0));
		HistoBars2[18].SetPosition(1, new Vector3(0, openCVloop.Spe18, 0));
		HistoBars2[19].SetPosition(1, new Vector3(0, openCVloop.Spe19, 0));
		HistoBars2[20].SetPosition(1, new Vector3(0, openCVloop.Spe20, 0));
		HistoBars2[21].SetPosition(1, new Vector3(0, openCVloop.Spe21, 0));
 		HistoBars2[22].SetPosition(1, new Vector3(0, openCVloop.Spe22, 0));
		HistoBars2[23].SetPosition(1, new Vector3(0, openCVloop.Spe23, 0));
  	}
}
