using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCVForUnity;

public class Select_ROI : MonoBehaviour {

	public float rectSize  ;
	[SerializeField]
	private Slider Slider04;
	private Point removePoint;

	// Use this for initialization
	void Start () {
		Slider04changed ();
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown("space"))
		Debug.Log("rectSize = " + rectSize);

	}
	public void Slider04changed(){
		rectSize = Slider04.value;
	}

	public Point returnPoint (){
		return removePoint;
	}
	public float returnRectSize (){
		return rectSize;
	}
}

