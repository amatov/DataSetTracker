using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Histogram : MonoBehaviour {


	//This is a static array. The number in the array needs to be set at build time. 
	public LineRenderer[] HistoBars;

	[SerializeField]
	private OpenCVUpdateLoop openCVloop;

	//etc

	// Use this for initialization
	void Start () {

		//set the top point of the line
		HistoBars[0].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[1].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[2].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[3].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[4].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[5].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[6].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[7].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[8].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[9].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[10].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[11].SetPosition(1, new Vector3(0, 0, 0));		 
		HistoBars[12].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[13].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[14].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[15].SetPosition(1, new Vector3(0, 0, 0));		 
		HistoBars[16].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[17].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[18].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[19].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[20].SetPosition(1, new Vector3(0, 0, 0));
 		HistoBars[21].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[22].SetPosition(1, new Vector3(0, 0, 0));
		HistoBars[23].SetPosition(1, new Vector3(0, 0, 0));
  
	}
	
	// Update is called once per frame
	void Update () {
		HistoBars[0].SetPosition(1, new Vector3(0, openCVloop.Hue0, 0));
		HistoBars[1].SetPosition(1, new Vector3(0, openCVloop.Hue1, 0));
		HistoBars[2].SetPosition(1, new Vector3(0, openCVloop.Hue2, 0));
		HistoBars[3].SetPosition(1, new Vector3(0, openCVloop.Hue3, 0));
		HistoBars[4].SetPosition(1, new Vector3(0, openCVloop.Hue4, 0));
		HistoBars[5].SetPosition(1, new Vector3(0, openCVloop.Hue5, 0));		 
		HistoBars[6].SetPosition(1, new Vector3(0, openCVloop.Hue6, 0));
		HistoBars[7].SetPosition(1, new Vector3(0, openCVloop.Hue7, 0));
		HistoBars[8].SetPosition(1, new Vector3(0, openCVloop.Hue8, 0));
		HistoBars[9].SetPosition(1, new Vector3(0, openCVloop.Hue9, 0));
		HistoBars[10].SetPosition(1, new Vector3(0, openCVloop.Hue10, 0));		 
		HistoBars[11].SetPosition(1, new Vector3(0, openCVloop.Hue11, 0));
		HistoBars[12].SetPosition(1, new Vector3(0, openCVloop.Hue12, 0));
		HistoBars[13].SetPosition(1, new Vector3(0, openCVloop.Hue13, 0));
		HistoBars[14].SetPosition(1, new Vector3(0, openCVloop.Hue14, 0));
		HistoBars[15].SetPosition(1, new Vector3(0, openCVloop.Hue15, 0));
		HistoBars[16].SetPosition(1, new Vector3(0, openCVloop.Hue16, 0));
		HistoBars[17].SetPosition(1, new Vector3(0, openCVloop.Hue17, 0));
		HistoBars[18].SetPosition(1, new Vector3(0, openCVloop.Hue18, 0));
		HistoBars[19].SetPosition(1, new Vector3(0, openCVloop.Hue19, 0));
		HistoBars[20].SetPosition(1, new Vector3(0, openCVloop.Hue20, 0));
		HistoBars[21].SetPosition(1, new Vector3(0, openCVloop.Hue21, 0));
 		HistoBars[22].SetPosition(1, new Vector3(0, openCVloop.Hue22, 0));
		HistoBars[23].SetPosition(1, new Vector3(0, openCVloop.Hue23, 0));
  	}
}
