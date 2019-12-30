using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using UnityEngine.UI;

public class HistoMat : MonoBehaviour {

	[SerializeField]
	private OpenCVUpdateLoop openCVUpdateLoop;

	[SerializeField]
	private RawImage rawHistoImage;

	[SerializeField]
	private float xHisto1 = 50.0f;

	[SerializeField]
	private float yHisto1 = 300.0f;

	[SerializeField]
	private float spacing = 15.0f;

	[SerializeField]
	private float heightScaling = -10.0f;

	[SerializeField]
	private int lineThickness = 8;


	private Mat mat_histo_01;
	private Color32[] colors;
	private Texture2D inputTexture2D;
	private Texture2D outputTexture2D;

	// Use this for initialization
	void Start () {
		mat_histo_01 = new Mat (rawHistoImage.texture.height, rawHistoImage.texture.width, CvType.CV_8UC3);
		colors = new Color32[(rawHistoImage.texture.width) * (rawHistoImage.texture.width)];	
		inputTexture2D = new Texture2D (rawHistoImage.texture.width, rawHistoImage.texture.height, TextureFormat.RGBA32, false);
		outputTexture2D = new Texture2D (rawHistoImage.texture.width, rawHistoImage.texture.height, TextureFormat.RGBA32, false);

	}


	// Update is called once per frame
	void Update () {



		if (openCVUpdateLoop.Hue0 == null) {
			return;
		}



		//Add Video Texture to rgbaMat
		Utils.texture2DToMat (inputTexture2D, mat_histo_01);



		Point Point1Fill  = new Point(100f, 0f);
		Point Point2Fill  = new Point(100f, 800f);
		Imgproc.line (mat_histo_01, Point1Fill,Point2Fill,new Scalar (0, 0, 0), 1000);

	


		Point Point1  = new Point((double)xHisto1 + spacing, (double)yHisto1);
		Point Point2  = new Point((double)xHisto1 + spacing, (double)(yHisto1 + (openCVUpdateLoop.Hue0 * heightScaling)));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor1, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue1 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor2, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue2 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor3, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue3 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor4, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue4 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor5, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue5 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor6, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue6 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor7, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue7 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor8, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue8 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor9, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue9 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor10, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue10 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor11, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue11 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor12, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue12 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor13, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue13 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor14, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue14 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor15, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue15 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor16, lineThickness);
	
		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue16 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor17, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue17 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor18, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue18 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor19, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue19 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor20, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue20 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor21, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue21 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor22, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue22 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor23, lineThickness);

		Point1.x = Point1.x + spacing;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto1 + (openCVUpdateLoop.Hue23 * heightScaling));
		Imgproc.line (mat_histo_01, Point1,Point2, openCVUpdateLoop.HueColor24, lineThickness);

		Utils.matToTexture2D (mat_histo_01, outputTexture2D);//rgbaMat
		rawHistoImage.texture = outputTexture2D;
	}
}
