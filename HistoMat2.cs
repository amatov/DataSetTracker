using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using UnityEngine.UI;

public class HistoMat2 : MonoBehaviour {

	[SerializeField]
	private OpenCVUpdateLoop openCVUpdateLoop2;

	[SerializeField]
	private RawImage rawHistoImage2;

	[SerializeField]
	private float xHisto2 = 50.0f;

	[SerializeField]
	private float yHisto2 = 1000.0f;

	[SerializeField]
	private float spacing2 = 15.0f;

	[SerializeField]
	private float heightScaling2 = -10.0f;

	[SerializeField]
	private int lineThickness2 = 8;


	private Mat mat_histo_02;
	private Color32[] colors;
	private Texture2D inputTexture2D;
	private Texture2D outputTexture2D;

	// Use this for initialization
	void Start () {
		mat_histo_02 = new Mat (rawHistoImage2.texture.height, rawHistoImage2.texture.width, CvType.CV_8UC3);
		colors = new Color32[(rawHistoImage2.texture.width) * (rawHistoImage2.texture.width)];	
		inputTexture2D = new Texture2D (rawHistoImage2.texture.width, rawHistoImage2.texture.height, TextureFormat.RGBA32, false);
		outputTexture2D = new Texture2D (rawHistoImage2.texture.width, rawHistoImage2.texture.height, TextureFormat.RGBA32, false);

	}


	// Update is called once per frame
	void Update () {

		if (openCVUpdateLoop2.Hue0 == null) {
			return;
		}

		//Add Video Texture to rgbaMat
		Utils.texture2DToMat (inputTexture2D, mat_histo_02);


		Point Point1Fill  = new Point(100f, 0f);
		Point Point2Fill  = new Point(100f, 800f);
		Imgproc.line (mat_histo_02, Point1Fill,Point2Fill,new Scalar (0, 0, 0), 1000);


		Point Point1  = new Point((double)xHisto2 + spacing2, (double)yHisto2);
		Point Point2  = new Point((double)xHisto2 + spacing2, (double)(yHisto2 + (openCVUpdateLoop2.Spe0 * heightScaling2)));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor1, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe1 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor2, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe2 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor3, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe3 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor4, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe4 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor5, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe5 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor6, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe6 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor7, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe7 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor8, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe8 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor9, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe9 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor10, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe10 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor11, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe11 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor12, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe12 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor13, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe13 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor14, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe14 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor15, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe15 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor16, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe16 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor17, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe17 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor18, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe18 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor19, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe19 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor20, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe20 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor21, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe21 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor22, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe22 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor23, lineThickness2);

		Point1.x = Point1.x + spacing2;
		Point2.x = Point1.x;
		Point2.y = (double)(yHisto2 + (openCVUpdateLoop2.Spe23 * heightScaling2));
		Imgproc.line (mat_histo_02, Point1,Point2, openCVUpdateLoop2.NewColor24, lineThickness2);

		Utils.matToTexture2D (mat_histo_02, outputTexture2D);//rgbaMat
		rawHistoImage2.texture = outputTexture2D;
	}
}
