using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using System;

public class TracePoints : MonoBehaviour {

	private OpenCVUpdateLoop openCVUpdateLoop;
	private writeDataToFile dataFileClass;


	[SerializeField]
	private long MaxParticles = 120000;

	[SerializeField]
	private VideoPlayerManager videoManager;

	List<TracerData> Tracers0;
	List<TracerData> TracerRecord;


	void Awake(){

		openCVUpdateLoop = GetComponent<OpenCVUpdateLoop> ();
		dataFileClass = GetComponent<writeDataToFile> ();

		CreateStorgaeForTracers ();
	}

	public void KillDisplayTracers(){

		Tracers0 = new List<TracerData> ();

	}


	public void CreateStorgaeForTracers(){
		Tracers0 = new List<TracerData> ();
		TracerRecord = new List<TracerData> ();
	}


	public void AddTracersToStorage (Point pt, Point pt2, Scalar hueColor, Scalar newColor, long frame, float angle, float speed){
		Tracers0.Add (new TracerData(pt, pt2, hueColor, newColor, frame, angle, speed));
		TracerRecord.Add (new TracerData(pt, pt2, hueColor, newColor, frame, angle, speed));
	}

	public void AddTracersToMat(Mat DisplayMat, long CurrentVideoFrame){
		
		int iCurrentIndex = 0;

		foreach(TracerData T  in Tracers0){
			openCVUpdateLoop.RenderTracerToScreen (T.mPt, T.mPt2, T.mHue, T.mNew);
			iCurrentIndex++;
		}


		if (Tracers0.Count > MaxParticles) {
			Tracers0.RemoveRange (0, 6000);
		}

		//Tracers0.Clear ();

	}

	public void FinishedRecordingGiveMeAllTheTracers(){

		int iCurrentIndex = 0;

		dataFileClass.StartWritingDtata (videoManager.sURL_Video + ".csv");


		foreach(TracerData T  in TracerRecord){
			//Call a function to write to file
			dataFileClass.WriteDataFile(T.mPt, T.mPt2, T.mHue, T.mNew, T.mFrame, T.mAngle, T.mSpeed);
			//openCVUpdateLoop.RenderTracerToScreen (T.mPt, T.mPt2, T.mHue);
			iCurrentIndex++;
		}


		dataFileClass.StopWritingDtata ();

		Debug.Log ("Finished passing data");
			
	}

}
