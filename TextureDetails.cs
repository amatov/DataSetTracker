using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDetails : MonoBehaviour {

	public int vHeight;
	public int vWidth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		vHeight = GetComponent<Renderer> ().material.mainTexture.height;
		vWidth = GetComponent<Renderer> ().material.mainTexture.width;
	}
}
