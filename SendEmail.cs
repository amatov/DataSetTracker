using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SendEmail : MonoBehaviour {


	[SerializeField]
	Text TextCounter;

	List<TrackData> mTracks;

	public bool bCaptureData = false;
	private int icounter;

		
	public void ResetRecording(){
		bCaptureData = false;
		TextCounter.text = "record";
		mTracks = new List<TrackData> ();
		icounter = 1;
	}
		
	public void StartRecording(){

	
		if (bCaptureData == false) {
			//start recording
			bCaptureData = true;
	
		} else {
			//stop
			bCaptureData = false;
			SendEmailMessage ();
			ResetRecording ();		

		}

	}

	public void AddDataTrack(string newString, string newStringA){

		string sTemp;
		float sumSpeed = 0;
		float muSpeed = 0;//mean speed = sum of all speeds / number of cars, i.e. icounter
		float sumAngle = 0;
		float muAngle = 0;

		if (bCaptureData == false) {
			return;
		}

		TextCounter.text = icounter.ToString();

		if (newString != "0") {

			sumSpeed = sumSpeed + float.Parse (newString);
			muSpeed = sumSpeed / icounter;
			sumAngle = sumAngle + float.Parse (newStringA);
			muAngle = sumAngle / icounter;

			sTemp = "\n" + "Frame #: " + icounter + ", dTime (sec): " + Time.deltaTime + ", Instanteneous Velocity: " + newString +  ", Mean Speed (current): " + muSpeed + ", Angular Orientation of Motion: " + newStringA +  ", Mean Angle (current): " + muAngle;
			icounter++;

			mTracks.Add(new TrackData(sTemp));
		}
	}
		


	public void SendEmailMessage ()
	{
		string email = "";
		string subject = MyEscapeURL("EBs tracking data      " + System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy")); // add mean and std

		//LOOP THROUGH DATA CLASS

		//string body = MyEscapeURL(csvCaptureobj.CSVFile);
		string body = "";

		foreach (TrackData mData in mTracks)
		{
			body = body + mData.GetDataForObj ();

			// do something with this group!
		}


		body = MyEscapeURL (body);

		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);

		Debug.Log ("mailto:" + email + "?subject=" + subject + "&body=" + body);

		ResetRecording();
	}

	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}
}
