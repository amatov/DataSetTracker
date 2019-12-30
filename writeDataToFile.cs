using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using System.IO;
using UnityEngine.UI;


public class writeDataToFile : MonoBehaviour {

	//string  fileName = Application.dataPath + "/MyFile.txt";

	string dir;
	string txtname = "output.csv";
	string textPath;
	StreamWriter writer;

	[SerializeField]
	private VideoPlayerManager videoManager;

	[SerializeField]
	private Text txtSuccess;

	public void StartWritingDtata (string filename){



		dir = Application.dataPath + "/../";
		string mDate = ""; //System.DateTime.Now.ToString ();
		textPath = Path.Combine(dir, mDate + txtname);
		Debug.Log("Writing file: " + textPath);
		writer = new StreamWriter (textPath, false);

		txtSuccess.text = "Textfile " + textPath + " created sucessfully";
		writer.WriteLine("Video path=" + videoManager.sURL_Video);
	}


	public void StopWritingDtata (){
		writer.Flush();
	}


	public string sReturtnFileURL(){
	
		return textPath;
		
	}
		

	//this gets called when finished recording // need to add parameters eg pt, pt2, angle etc
	public void WriteDataFile(Point pt, Point pt2, Scalar hueColor, Scalar newColor, long frame, float angle, float speed){

		//save it!!!!
		Debug.Log("Saving Frame " + frame);

		writer.WriteLine(
			"frame" + "," + frame.ToString()
			+",point1 x" + "," + pt.x.ToString()
			+",point1 y" + "," + pt.y.ToString()
			+ ",point2 x" + "," + pt2.x.ToString() 
			+ ",point2 y" + "," + pt2.y.ToString() 
			+ ",hueColor" + "," + hueColor.ToString() 
			+ ",newColor" + "," + newColor.ToString() 
			+ ",angle" + "," + angle.ToString() 
			+ ",speed" + "," + speed.ToString()
		); 

	}
		


}