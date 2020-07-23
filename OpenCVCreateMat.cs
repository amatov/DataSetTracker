// Alexandre Matov & James Cumberbatch, 2017﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;

public class OpenCVCreateMat : MonoBehaviour {

	public Mat rgbaMat;
	public Mat rgbMat;
	public Mat fgmaskMat;
	//public Mat fgmaskMat;
	public Color32[] colors;
	public Texture2D outputTexture2D;
	public Texture2D inputTexture2D;

	public void CreateMats(Texture texture){

		Debug.Log ("Creating Mats");

		rgbaMat = new Mat (texture.height, texture.width, CvType.CV_8UC4);
		rgbMat = new Mat (texture.height, texture.width, CvType.CV_8UC3);
		fgmaskMat = new Mat (texture.height, texture.width,  CvType.CV_8UC1);	

		colors = new Color32[(texture.width) * (texture.height)];

		outputTexture2D = new Texture2D (texture.width * 4,texture.height * 4, TextureFormat.RGBA32, false);
		inputTexture2D = new Texture2D (texture.width,texture.height, TextureFormat.ARGB32, false);

	}



}
