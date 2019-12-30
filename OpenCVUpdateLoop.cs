using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using UnityEngine.Video;
using UnityEngine.UI;

public class OpenCVUpdateLoop : MonoBehaviour {

	//UI Controls
	[SerializeField]
	private Slider Slider01;
	[SerializeField]
	private Slider Slider02;
	[SerializeField]
	private Slider Slider03;
	[SerializeField]
	private Slider Slider04;
	[SerializeField]
	private InputField Input01;
	[SerializeField]
	private GameObject DisplayCanvas;
	[SerializeField]
	private Text textTrackedPoints;
	[SerializeField]
	private VideoPlayer videoPlayer;
	//UI control vars
	[SerializeField]
	private RawImage outputImage;
	//Panels UI - used so we can dynamically resize things
	[SerializeField]
	RectTransform videoSeekBar; 
	[SerializeField]
	RectTransform controlsPanel; 	
	[SerializeField]
	RectTransform diagnosticsPanel; 

	public bool ToggleMask = false;
	public bool TurnOnSpeedCalculation = false;
	public bool StartTracking = false;
	public bool bSwitchAngleSpeed = false;//false;
	public bool blurImage = false;
	//Scalar colorRed = new Scalar (255, 0, 0, 255);
	private Size kernelSize = new Size (100,100);
	private double sigmaX = 10;
	private double sigmaY = 10;
	private double speedVec = 0;
	private double angleVec = 0;
	private int meanSpeed = 0;
	private int meanAngle = 0;
	//public Vector2 mousePosition;
	//public Point removePoint;
	//public Point removePoint2;
	//private RotatedRect Box;

	//Selected from color wheeel
	//https://s-media-cache-ak0.pinimg.com/564x/a2/24/ee/a224ee1adc79f5ef7f521bc82cac7466.jpg
//	public Scalar HueColor1 = new Scalar(255,0,0); 
//	public Scalar HueColor2 = new Scalar(255,63,0); 
//	public Scalar HueColor3 = new Scalar(255,125,0); 
//	public Scalar HueColor4 = new Scalar(255,188,0); 
//	public Scalar HueColor5 = new Scalar(255,255,0);
//	public Scalar HueColor6 = new Scalar(188,255,0); 
//	public Scalar HueColor7 = new Scalar(125,255,0);
//	public Scalar HueColor8 = new Scalar(63,255,0); 
//	public Scalar HueColor9 = new Scalar(0,255,0);
//	public Scalar HueColor10 = new Scalar(0,255,63); 
//	public Scalar HueColor11 = new Scalar(0,255,125);
//	public Scalar HueColor12 = new Scalar(0,255,183); 
//	public Scalar HueColor13 = new Scalar(0,255,255);
//	public Scalar HueColor14 = new Scalar(0,188,255); 
//	public Scalar HueColor15 = new Scalar(0,125,255);
//	public Scalar HueColor16 = new Scalar(0,63,255); 
//	public Scalar HueColor17 = new Scalar(0,0,255);
//	public Scalar HueColor18 = new Scalar(63,0,255); 
//	public Scalar HueColor19 = new Scalar(125,0,255);
//	public Scalar HueColor20 = new Scalar(188,0,255); 
//	public Scalar HueColor21 = new Scalar(255,0,255);
//	public Scalar HueColor22 = new Scalar(255,0,188); 
//	public Scalar HueColor23 = new Scalar(255,0,125);
//	public Scalar HueColor24 = new Scalar(255,0,63); 

	public Scalar HueColor1 = new Scalar(0,0,0); //green
	public Scalar HueColor2 = new Scalar(0,11,0); 
	public Scalar HueColor3 = new Scalar(0,22,0); 
	public Scalar HueColor4 = new Scalar(0,33,0); 
	public Scalar HueColor5 = new Scalar(0,44,0);
	public Scalar HueColor6 = new Scalar(0,55,0); 
	public Scalar HueColor7 = new Scalar(0,66,0);
	public Scalar HueColor8 = new Scalar(0,77,0); 
	public Scalar HueColor9 = new Scalar(0,88,0);
	public Scalar HueColor10 = new Scalar(0,99,0); 
	public Scalar HueColor11 = new Scalar(0,110,0);
	public Scalar HueColor12 = new Scalar(0,121,0); 
	public Scalar HueColor13 = new Scalar(0,132,0);
	public Scalar HueColor14 = new Scalar(0,143,0); 
	public Scalar HueColor15 = new Scalar(0,154,0);
	public Scalar HueColor16 = new Scalar(0,165,0); 
	public Scalar HueColor17 = new Scalar(0,176,0);
	public Scalar HueColor18 = new Scalar(0,187,0); 
	public Scalar HueColor19 = new Scalar(0,198,0);
	public Scalar HueColor20 = new Scalar(0,209,0); 
	public Scalar HueColor21 = new Scalar(0,220,0);
	public Scalar HueColor22 = new Scalar(0,231,0); 
	public Scalar HueColor23 = new Scalar(0,242,0);
	public Scalar HueColor24 = new Scalar(0,253,0); 

	public Scalar NewColor1 = new Scalar(0,0,0); //red
	public Scalar NewColor2 = new Scalar(11,0,0); 
	public Scalar NewColor3 = new Scalar(22,0,0); 
	public Scalar NewColor4 = new Scalar(33,0,0); 
	public Scalar NewColor5 = new Scalar(44,0,0);
	public Scalar NewColor6 = new Scalar(55,0,0); 
	public Scalar NewColor7 = new Scalar(66,0,0);
	public Scalar NewColor8 = new Scalar(77,0,0); 
	public Scalar NewColor9 = new Scalar(88,0,0);
	public Scalar NewColor10 = new Scalar(99,0,0); 
	public Scalar NewColor11 = new Scalar(110,0,0);
	public Scalar NewColor12 = new Scalar(121,0,0); 
	public Scalar NewColor13 = new Scalar(132,0,0);
	public Scalar NewColor14 = new Scalar(143,0,0); 
	public Scalar NewColor15 = new Scalar(154,0,0);
	public Scalar NewColor16 = new Scalar(165,0,0); 
	public Scalar NewColor17 = new Scalar(176,0,0);
	public Scalar NewColor18 = new Scalar(187,0,0); 
	public Scalar NewColor19 = new Scalar(198,0,0);
	public Scalar NewColor20 = new Scalar(209,0,0); 
	public Scalar NewColor21 = new Scalar(220,0,0);
	public Scalar NewColor22 = new Scalar(231,0,0); 
	public Scalar NewColor23 = new Scalar(242,0,0);
	public Scalar NewColor24 = new Scalar(253,0,0); 

	public float Spe0 = 0.0f;
	public float Spe1 = 0.0f;
	public float Spe2 = 0.0f;
	public float Spe3 = 0.0f;
	public float Spe4 = 0.0f;
	public float Spe5 = 0.0f;
	public float Spe6 = 0.0f;
	public float Spe7 = 0.0f;
	public float Spe8 = 0.0f;
	public float Spe9 = 0.0f;
	public float Spe10 = 0.0f;
	public float Spe11 = 0.0f;
	public float Spe12 = 0.0f;
	public float Spe13 = 0.0f;
	public float Spe14 = 0.0f;
	public float Spe15 = 0.0f;
	public float Spe16 = 0.0f;
	public float Spe17 = 0.0f;
	public float Spe18 = 0.0f;
	public float Spe19 = 0.0f;
	public float Spe20 = 0.0f;
	public float Spe21 = 0.0f;
	public float Spe22 = 0.0f;
	public float Spe23 = 0.0f;
  
	public float Hue0 = 0.0f;
	public float Hue1 = 0.0f;
	public float Hue2 = 0.0f;
	public float Hue3 = 0.0f;
	public float Hue4 = 0.0f;
	public float Hue5 = 0.0f;
	public float Hue6 = 0.0f;
	public float Hue7 = 0.0f;
	public float Hue8 = 0.0f;
	public float Hue9 = 0.0f;
	public float Hue10 = 0.0f;
	public float Hue11 = 0.0f;
	public float Hue12 = 0.0f;
	public float Hue13 = 0.0f;
	public float Hue14 = 0.0f;
	public float Hue15 = 0.0f;
	public float Hue16 = 0.0f;
	public float Hue17 = 0.0f;
	public float Hue18 = 0.0f;
	public float Hue19 = 0.0f;
	public float Hue20 = 0.0f;
	public float Hue21 = 0.0f;
	public float Hue22 = 0.0f;
	public float Hue23 = 0.0f;
  
	int iLineThickness = 3;
	private string TimeD = "";
	public float xDisplayOffset;
	public float yDisplayOffset;
	private bool bDisplayGraphics = false;
	//private bool displayROI = false;

	// store for our Mats
	private OpenCVCreateMat openCVCreateMat;

	//store tracers
	private TracePoints tracerPoints;
	private TracePoints tracerPointsS;

	//OpenCV Vars
	MatOfPoint MOPcorners;
	MatOfPoint2f mMOP2fptsThis;
	MatOfPoint2f mMOP2fptsPrev;
	MatOfPoint2f mMOP2fptsSafe;
	MatOfByte mMOBStatus;
	MatOfFloat mMOFerr;
	Mat matOpFlowThis;
	Mat matOpFlowPrev;
	Mat MatDisplay;

	Mat MatDisplayx2;
	BackgroundSubtractorMOG2 backgroundSubstractorMOG2;

	//parameters
	int iGFFTMax = 40;
	double qLevel = 0.05;
	int minDistCorners = 20;
	private float maxSpeed;//this should be linked to textbox input for scaling factor
	private float fInput01 = 3.0f; 
	private int numBins;


	private string sTrackingLogger;

	// Use this for initialization
	void Start () {
		openCVCreateMat = GetComponent<OpenCVCreateMat> ();
		tracerPoints = GetComponent<TracePoints> ();
		tracerPointsS = GetComponent<TracePoints> ();

	}

	public void ToggleBackground(){

		ToggleMask = !ToggleMask;
	
	}

	public void ResetLoopTracersOnlyOff(){
		tracerPoints.KillDisplayTracers ();
	}

	public void ResetLoop(){
		tracerPoints.CreateStorgaeForTracers ();	
	}

	//called from video player
	public void initOpenCV(Texture2D texture){

		//Input01.text = "50.0";
		//Input01ValueChanged ();

		//maxSpeed = 20.0f;
		numBins = 24;
		Slider01.value = 200;
		slider1updated ();

		Slider02.value = 0.1f;
		slider2updated ();

		Slider03.value = 40;
		slider3updated ();

		Slider04.value = 20.0f;
		slider4updated ();

		backgroundSubstractorMOG2 = Video.createBackgroundSubtractorMOG2 ();
		matOpFlowThis = new Mat ();
		matOpFlowPrev = new Mat ();
		MOPcorners = new MatOfPoint ();
		mMOP2fptsThis = new MatOfPoint2f ();
		mMOP2fptsPrev = new MatOfPoint2f ();
		mMOP2fptsSafe = new MatOfPoint2f ();
		mMOBStatus = new MatOfByte ();
		mMOFerr = new MatOfFloat ();

		//resize video window
		Debug.Log("Screen width=" + Screen.width);
		Debug.Log("Screen height=" + Screen.height);
		Debug.Log("Texture width=" + texture.width);
		//outputImage.GetComponent<RectTransform> ().rect.width = Screen.width;
		//outputImage.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
	
		MatDisplayx2 = new Mat (openCVCreateMat.rgbMat.height() * 4, openCVCreateMat.rgbMat.width() * 4, CvType.CV_8UC4);
		ResizeWindow (texture);
	}

	//Used to resize UI
	private void ResizeWindow(Texture texture){

		float aspectRatio;

		//Calculate aspect ratio so we can scale our video to fit the screen


		//scale video rect transform
		RectTransform rt = outputImage.GetComponent<RectTransform>();


		//see which axis is greater
		if (texture.height >= texture.width) {
			//height greater than width
			aspectRatio = (float)texture.height / (float)texture.width;
			Debug.Log ("aspectRatioH=" + aspectRatio);

			rt.sizeDelta = new Vector2 (Screen.height * aspectRatio, Screen.height);

		} else {
		
			//width bigger than height
			aspectRatio = (float)texture.width / (float)texture.height;
			Debug.Log ("aspectRatioW=" + aspectRatio);

			rt.sizeDelta = new Vector2 (Screen.width, Screen.width / aspectRatio);

		
		}

		//resize video seek bar
		//calculate how much space we have for the seek bar
		float seekBarWidth = Screen.width - (diagnosticsPanel.sizeDelta.x + controlsPanel.sizeDelta.x);

		// we only need to set width as its anchor is bottom left
		videoSeekBar.sizeDelta = (new Vector2(seekBarWidth -35 ,0f));

		//set it to butt up against the left side of the control panel
		videoSeekBar.anchoredPosition = new Vector2 (controlsPanel.sizeDelta.x + 20, 20);

		// use for GPU instancing layers
		xDisplayOffset = texture.width / 2;
		yDisplayOffset = texture.height / 2;
	}

	// RunOpenCV is Called when each new frame is created by the video player "VideoPlayerManager.cs"
	public void  RunOpenCV (Texture2D texture, string Frame) {

		//if (videoPlayer.frame == 0) {
			resetValues ();
		//}

		if (StartTracking == false) {
			return ;
		}

		//Start OpenCV Tracking
		if (ToggleMask == true) {
			MatDisplay = openCVCreateMat.rgbMat;
		} else {
			MatDisplay = openCVCreateMat.rgbaMat;
		}
			

		//Add Video Texture to rgbaMat
		Utils.texture2DToMat (texture, openCVCreateMat.rgbaMat);

		//Background Subtraction
		StartCoroutine(BackgroundSubtraction());

		// Run background subtraction
		StartCoroutine(OpticalFlow());

		//Resize Mat
		Size MatSizex2 = new Size ((double)MatDisplayx2.width (), (double)MatDisplayx2.height ());
		Imgproc.resize (MatDisplay, MatDisplayx2, MatSizex2);

		StartCoroutine (AddTracersToMat (MatDisplayx2));

		//Don store traces Tracer Objects - this should just stop tracers. check it still records correctly. 
		if (bDisplayGraphics) {
			//this clears the tracer store
			ResetLoopTracersOnlyOff ();
		}

 
		//DisplayDebugText ("Video Frame in OpenCV is: " + Frame);

		Utils.matToTexture2D (MatDisplayx2, openCVCreateMat.outputTexture2D);//rgbaMat
		outputImage.texture = openCVCreateMat.outputTexture2D;

		ScreenCapture.CaptureScreenshot (videoPlayer.frame.ToString()+ ".png");

		videoPlayer.Play ();

	}

	//Remove Background
	IEnumerator BackgroundSubtraction(){
		Imgproc.cvtColor (openCVCreateMat.rgbaMat, openCVCreateMat.rgbMat, Imgproc.COLOR_RGBA2RGB);
		backgroundSubstractorMOG2.apply (openCVCreateMat.rgbMat, openCVCreateMat.fgmaskMat);
		Core.bitwise_not (openCVCreateMat.fgmaskMat, openCVCreateMat.fgmaskMat);
		openCVCreateMat.rgbaMat.setTo (new Scalar (0, 0, 0, 0), openCVCreateMat.fgmaskMat);
		if (blurImage == true){
		//Gaussian filter of the MOG2 images
			Imgproc.GaussianBlur(openCVCreateMat.rgbaMat, openCVCreateMat.rgbaMat, kernelSize, sigmaX, sigmaY);//Gauss filter
		}
		yield return null;
	}

	//Optical flow
	IEnumerator OpticalFlow(){

		Scalar tempHue;
		Scalar tempSpeed;

		int iCountTrackedPoints = 0;
		int vecCount = 0;

		if (mMOP2fptsPrev.rows () == 0) {

			// first time through the loop so we need prev and this mats
			Imgproc.cvtColor (openCVCreateMat.rgbaMat, matOpFlowThis, Imgproc.COLOR_RGBA2GRAY);

			// copy that to prev mat
			matOpFlowThis.copyTo (matOpFlowPrev);

			//if (blurImage == true){
			//Gaussian filter of the MOG2 images
			//Imgproc.GaussianBlur(matOpFlowPrev, matOpFlowPrev, kernelSize, sigmaX, sigmaY);//Gauss filter
			//}
			// get prev corners
			Imgproc.goodFeaturesToTrack (matOpFlowPrev, MOPcorners, iGFFTMax, qLevel, minDistCorners);//SLIDER input
			mMOP2fptsPrev.fromArray (MOPcorners.toArray ());

			// get safe copy of this corners
			mMOP2fptsPrev.copyTo (mMOP2fptsSafe);
		} else {
			// we've been through before so
			// this mat is valid. Copy it to prev mat
			matOpFlowThis.copyTo (matOpFlowPrev);

			// get this mat
			Imgproc.cvtColor (openCVCreateMat.rgbaMat, matOpFlowThis, Imgproc.COLOR_RGBA2GRAY);

			//if (blurImage == true){
			//Gaussian filter of the MOG2 images
			//Imgproc.GaussianBlur(matOpFlowThis, matOpFlowThis, kernelSize, sigmaX, sigmaY);//Gauss filter
			//}
			// get the corners for this mat
			Imgproc.goodFeaturesToTrack (matOpFlowThis, MOPcorners, iGFFTMax, qLevel, minDistCorners);// SLIDER input
			mMOP2fptsThis.fromArray (MOPcorners.toArray ());

			// retrieve the corners from the prev mat (saves calculating them again)
			mMOP2fptsSafe.copyTo (mMOP2fptsPrev);

			// and save this corners for next time through
			mMOP2fptsThis.copyTo (mMOP2fptsSafe);
		}

		Video.calcOpticalFlowPyrLK (matOpFlowPrev, matOpFlowThis, mMOP2fptsPrev, mMOP2fptsThis, mMOBStatus, mMOFerr);

		if (mMOBStatus.rows () > 0) {
			List<Point> cornersPrev = mMOP2fptsPrev.toList ();
			List<Point> cornersThis = mMOP2fptsThis.toList ();
			List<byte> byteStatus = mMOBStatus.toList ();

			int x = 0;
			int y = byteStatus.Count - 1;

			double absX;
			double absY; //will use for calculation of polar coordiates

			for (x = 0; x < y; x++) {
				if (byteStatus [x] == 1) {


					Point pt = cornersThis [x];
					Point pt2 = cornersPrev [x];

					//if (pt != pt2) {//I think this IF statement should be removed as pt and pt2 should always be differnt 

						float mySpeed = CalculateSpeedFloat (pt, pt2);
 
						absX = pt.x-pt2.x;
						absY = pt.y-pt2.y;
						float angle = Mathf.Atan2((float)absX,(float)absY)*Mathf.Rad2Deg;
						angle = Mathf.RoundToInt(angle);

						//Get Hue based on Angle
						tempHue = GetHueColor((int)angle);
						tempSpeed = GetSpeedColor ((int)mySpeed);

						//Store so we can add tracers
						if (mySpeed > maxSpeed) { //|| CalculateSpeedFloat (pt, pt2) <= 1
							yield return null;
						} else {
						tracerPoints.AddTracersToStorage (pt, pt2, tempHue, tempSpeed, videoPlayer.frame, angle, mySpeed);
						speedVec = speedVec + mySpeed;
						angleVec = angleVec + angle;
						vecCount++;
							//tracerPoints2.AddTracersToStorage (pt, pt2, tempSpeed, videoPlayer.frame, angle, mySpeed);

						//ADD STORING SPEEDS TO VECTOR
						//CSVDataEmail.AddDataTrack (speed,angle.ToString ());

						}
						iCountTrackedPoints++;
					}
			}
		}

		meanSpeed = (int)(speedVec / vecCount);
		meanAngle = (int)(angleVec / vecCount);
		//sTrackingLogger = "Video frame: " + videoPlayer.frame.ToString() + "    Points: " + iCountTrackedPoints.ToString() + "";
		sTrackingLogger = "Speed: " + meanSpeed.ToString() + " Angle: " + meanAngle.ToString() + "";

		textTrackedPoints.text = sTrackingLogger;
		yield return null;

	}

	public void RenderTracerToScreen(Point tracerPoint1, Point tracerPoint2, Scalar tracerHue, Scalar tracerNew){

		Point ScaledPoint = new Point (tracerPoint1.x * 4, tracerPoint1.y * 4);
		Point ScaledPoint2 = new Point (tracerPoint2.x * 4, tracerPoint2.y * 4);

		if (bSwitchAngleSpeed == true ){
			//show dots
			Imgproc.circle (MatDisplayx2, ScaledPoint, 3,tracerHue, 1); //SHOW EITHER FOR ANGLE OR SPEED

			//show lines
			Imgproc.line (MatDisplayx2, ScaledPoint, ScaledPoint2, tracerHue); //SHOW EITHER FOR ANGLE OR SPEED
		} else {
			Imgproc.circle (MatDisplayx2, ScaledPoint, 3,tracerNew, 1);
			Imgproc.line (MatDisplayx2, ScaledPoint, ScaledPoint2, tracerNew);
		}
 	}

	IEnumerator AddTracersToMat(Mat DisplayMat){
		tracerPoints.AddTracersToMat (DisplayMat, videoPlayer.frame);
		yield return null;
	}

	public void resetValues(){
		Hue0 = 0.0f;
		Hue1 = 0.0f;
		Hue2 = 0.0f;
		Hue3 = 0.0f;
		Hue4 = 0.0f;
		Hue5 = 0.0f;
		Hue6 = 0.0f;
		Hue7 = 0.0f;
		Hue8 = 0.0f;
		Hue9 = 0.0f;
		Hue10 = 0.0f;
		Hue11 = 0.0f;
		Hue12 = 0.0f;
		Hue13 = 0.0f;
		Hue14 = 0.0f;
		Hue15 = 0.0f;
		Hue16 = 0.0f;
		Hue17 = 0.0f;
		Hue18 = 0.0f;
		Hue19 = 0.0f;
		Hue20 = 0.0f;
		Hue21 = 0.0f;
		Hue22 = 0.0f;
		Hue23 = 0.0f;

		Spe0 = 0.0f;
		Spe1 = 0.0f;
		Spe2 = 0.0f;
		Spe3 = 0.0f;
		Spe4 = 0.0f;
		Spe5 = 0.0f;
		Spe6 = 0.0f;
		Spe7 = 0.0f;
		Spe8 = 0.0f;
		Spe9 = 0.0f;
		Spe10 = 0.0f;
		Spe11 = 0.0f;
		Spe12 = 0.0f;
		Spe13 = 0.0f;
		Spe14 = 0.0f;
		Spe15 = 0.0f;
		Spe16 = 0.0f;
		Spe17 = 0.0f;
		Spe18 = 0.0f;
		Spe19 = 0.0f;
		Spe20 = 0.0f;
		Spe21 = 0.0f;
		Spe22 = 0.0f;
		Spe23 = 0.0f;
		 
	}
	private Scalar GetSpeedColor(int fSpeed){
		
		int increment2 = 1;//0.02f for the whole movie 601 frames
		int fSpeedResult = 0;

		fSpeedResult = (int)(fSpeed/(maxSpeed/numBins));
		//Debug.Log ("current int speed " + fSpeedResult);
		//Debug.Log ("current  speed " + fSpeed);

		switch (fSpeedResult) { 
		case 1:
			Spe0 = Spe0 + increment2; //NewColor = Red/Speed
			return NewColor1;
		case 2:
			Spe1 = Spe1 + increment2;
			return NewColor2;
		case 3:
			Spe2 = Spe2 + increment2;
			return NewColor3;
		case 4:
			Spe3 = Spe3 + increment2;
			return NewColor4;
		case 5:
			Spe4 = Spe4 + increment2;
			return NewColor5;
		case 6:
			Spe5 = Spe5 + increment2;
			return NewColor6;
		case 7:
			Spe6 = Spe6 + increment2;
			return NewColor7;
		case 8:
			Spe7 = Spe7 + increment2;
			return NewColor8;
		case 9:
			Spe8 = Spe8 + increment2;
			return NewColor9;
		case 10:
			Spe9 = Spe9 + increment2;
			return NewColor10;
		case 11:
			Spe10 = Spe10 + increment2;
			return NewColor11;
		case 12:
			Spe11 = Spe11 + increment2;
			return NewColor12;
		case 13:
			Spe12 = Spe12 + increment2;
			return NewColor13;
		case 14:
			Spe13 = Spe13 + increment2;
			return NewColor14;
		case 15:
			Spe14 = Spe14 + increment2;
			return NewColor15;
		case 16:
			Spe15 = Spe15 + increment2;
			return NewColor16;
		case 17:
			Spe16 = Spe16 + increment2;
			return NewColor17;
		case 18:
			Spe17 = Spe17 + increment2;
			return NewColor18;
		case 19:
			Spe18 = Spe18 + increment2;
			return NewColor19;
		case 20:
			Spe19 = Spe19 + increment2;
			return NewColor20;
		case 21:
			Spe20 = Spe20 + increment2;
			return NewColor21;
		case 22:
			Spe21 = Spe21 + increment2;
			return NewColor22;
		case 23:
			Spe22 = Spe22 + increment2;
			return NewColor23;
		case 24:
			Spe23 = Spe23 + increment2;
			return NewColor24;
		default:
		//Debug.Log ("spe");
			//Debug.Log (" speed color number " + fSpeedResult);
			// we dont plot speed=0 and speed>20 pixels per frame
			//should be:
			//return null;
			return NewColor1;
			//return HueColor1; test if there are any?
		}
	}
	private Scalar GetHueColor(int HueAngle){

		HueAngle = HueAngle + 180;
		//Debug.Log ("ANGLE "+ HueAngle);

		int fHueResult = 0;
		int increment = 1;//0.04f for the whole movie 601 frames
		fHueResult = (int)(HueAngle/(360/numBins)); 
 
		switch (fHueResult) {
		case 1:
			Hue0 = Hue0 + increment;//HueColor = Green/Angle
 			return HueColor1;
		case 2:
			Hue1 = Hue1 + increment;
			return HueColor2;
		case 3:
			Hue2 = Hue2 + increment;
			return HueColor3;
		case 4:
			Hue3 = Hue3 + increment;
			return HueColor4;
		case 5:
			Hue4 = Hue4 + increment;
			return HueColor5;
		case 6:
			Hue5 = Hue5 + increment;
			return HueColor6;
		case 7:
			Hue6 = Hue6 + increment;
			return HueColor7;
		case 8:
			Hue7 = Hue7 + increment;
			return HueColor8;
		case 9:
			Hue8 = Hue8 + increment;
			return HueColor9;
		case 10:
			Hue9 = Hue9 + increment;
			return HueColor10;
		case 11:
			Hue10 = Hue10 + increment;
			return HueColor11;
		case 12:
			Hue11 = Hue11 + increment;
			return HueColor12;
		case 13:
			Hue12 = Hue12 + increment;
			return HueColor13;
		case 14:
			Hue13 = Hue13 + increment;
			return HueColor14;
		case 15:
			Hue14 = Hue14 + increment;
			return HueColor15;
		case 16:
			Hue15 = Hue15 + increment;
			return HueColor16;
		case 17:
			Hue16 = Hue16 + increment;
			return HueColor17;
		case 18:
			Hue17 = Hue17 + increment;
			return HueColor18;
		case 19:
			Hue18 = Hue18 + increment;
			return HueColor19;
		case 20:
			Hue19 = Hue19 + increment;
			return HueColor20;
		case 21:
			Hue20 = Hue20 + increment;
			return HueColor21;
		case 22:
			Hue21 = Hue21 + increment;
			return HueColor22;
		case 23:
			Hue22 = Hue22 + increment;
			return HueColor23;
		case 24:
			Hue23 = Hue23 + increment;
			return HueColor24;
		default:
			//Debug.Log (" angle color number " + fHueResult);
			return HueColor1;// when the Angle is 0 , we merge it w case1
			//return NewColor1; // use completely different color to debug
		}
	}
	private void DisplayDebugText(string sDebug){
		//Imgproc.putText (MatDisplayx2, "W:" + openCVCreateMat.rgbaMat.width () + " H:" + openCVCreateMat.rgbaMat.height () + " SO:" + Screen.orientation + " FRAME: " + sDebug , new Point (MatDisplayx2.cols (), MatDisplayx2.rows ()), Core.FONT_HERSHEY_SIMPLEX, 0.5, new Scalar (255, 255, 255, 255), 1, Imgproc.LINE_AA, false);
		//Imgproc.putText (MatDisplay, "W:" + openCVCreateMat.rgbaMat.width () + " H:" + openCVCreateMat.rgbaMat.height () + " SO:" + Screen.orientation + " FRAME: " + sDebug , new Point (0,0), Core.FONT_HERSHEY_SIMPLEX, 0.5, new Scalar (255, 255, 255, 255), 2, Imgproc.LINE_AA, false);

	}
	private void DisplayLines(Point point1, Point point2, float speed){

		Vector3 pt1Vector; 
		Vector3 pt2Vector;

		//calculate offset from OpenCv Mat Top left is 0,0 to Unity (middle is 0,0). Yuck...
		pt1Vector = new Vector3 ((float)point1.x-xDisplayOffset, (((float)point1.y-yDisplayOffset)*-1), 0);
		pt2Vector = new Vector3 ((float)point2.x-xDisplayOffset, (((float)point2.y-yDisplayOffset)*-1), 0);
	}

private float CalculateSpeedFloat(Point pt1, Point pt2){

	double xPt1;
	double xPt2;
	double yPt1;
	double yPt2;

	double xResult;
	double yResult;

	float fResult;

	xPt1 = pt1.x;
	xPt2 = pt2.x;

	yPt1 = pt1.y;
	yPt2 = pt2.y;
 
	xResult = (xPt2 - xPt1)*(xPt2 - xPt1);

	yResult = (yPt2 - yPt1)*(yPt2 - yPt1);

	fResult = Mathf.Sqrt((float)xResult + (float)yResult);
	fResult = fInput01 * fResult; // multiply by scaling factor input
	fResult = Mathf.RoundToInt(fResult);  

	return fResult;//.ToString ();
}
//	public void Input01ValueChanged(){
//
//		if (Input01.text != "") {
//			fInput01 = float.Parse(Input01.text);
//			Debug.Log ("fInput01 updated=" + fInput01);
//			maxSpeed = 20 * fInput01; // for now our cut off value for speeds is 20 times the scaling factor so if there is no scaling, our cut off is 20 (pixels per frame)
//		}
//
//	}
	public void slider1updated(){
		float fSliderValue = Slider01.value;
		iGFFTMax = Mathf.RoundToInt(fSliderValue);
	}
	public void slider2updated(){
		qLevel = Slider02.value;
	}
	public void slider3updated(){
 		float fSliderValue = Slider03.value;
		minDistCorners = Mathf.RoundToInt (fSliderValue);
	}
	public void slider4updated(){
		maxSpeed = Slider04.value;
	}

	public void ToggleVideoTexture(){
		outputImage.enabled = !outputImage.enabled;	
	}
	public void ToggleGraphics(){
		bDisplayGraphics = !bDisplayGraphics;
	}		
//	public void ToggleROI(){
//		displayROI = !displayROI;
//	}
	public void ToggleBlur(){
		blurImage = !blurImage;
	}
	public void ToggleColor(){
		bSwitchAngleSpeed = !bSwitchAngleSpeed;
	}
}

