using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RockVR.Video;
using System.Diagnostics;

public class StartStopRecording : MonoBehaviour {


	private VideoCaptureCtrl VideoCtrl;

	// Use this for initialization
	void Start () {

		VideoCtrl = GetComponent<VideoCaptureCtrl> (); 
	}


	public void StartRecording(){
		
	}


	public void StopRecording(){
		VideoCtrl.StopCapture ();
		Process.Start(PathConfig.saveFolder);
	}

}
