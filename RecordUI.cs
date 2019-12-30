using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MaterialUI;

public class RecordUI : MonoBehaviour {

	[SerializeField]
	private GameObject recordButton;

	[SerializeField]
	private GameObject fileOpenButton;

	[SerializeField]
	private GameObject controlsPanel;

	[SerializeField]
	private GameObject diagnosticsPanel;


	[SerializeField]
	private Text recordButtonText;

	[SerializeField]
	private Text openFileButtonText;


	[SerializeField]
	private MaterialSlider seekBarSlider;

	[SerializeField]
	private GameObject SuccessPopup;


	[SerializeField]
	private Image seekBarBlockFocus;

	private Color seekBarColor;

	private bool bRecord = false;

	// Use this for initialization
	void Start () {
		resetRecordUI ();
	}



		public void resetRecordUI(){

			seekBarBlockFocus.enabled = false;
			
			controlsPanel.SetActive (true);
		diagnosticsPanel.SetActive (true);
			seekBarColor = seekBarSlider.enabledColor;
			recordButtonText.text = "Record";
			SuccessPopup.SetActive (false);
		}

	public void recordingRecordUI(){

		bRecord = !bRecord;

		//start recording
		if (bRecord) {
			seekBarBlockFocus.enabled = true;

			controlsPanel.SetActive (false);
			diagnosticsPanel.SetActive (false);
			seekBarSlider.enabledColor = Color.red;
			recordButtonText.text = "Cancel";
			SuccessPopup.SetActive (false);

		} else {

			seekBarBlockFocus.enabled = false;
			diagnosticsPanel.SetActive (true);
			controlsPanel.SetActive (true);
			seekBarSlider.enabledColor = seekBarColor;

			recordButtonText.text = "Record";
			SuccessPopup.SetActive (false);

		}
	}
		
	public void successRecordUI(){
		bRecord = !bRecord;
		seekBarBlockFocus.enabled = false;

		controlsPanel.SetActive (true);
		diagnosticsPanel.SetActive (true);
		seekBarSlider.enabledColor = seekBarColor;
		recordButtonText.text = "Record";
		SuccessPopup.SetActive (true);
		StartCoroutine (HidePopUp());

	}

	IEnumerator HidePopUp(){

		yield return new WaitForSeconds (5);
		SuccessPopup.SetActive (false);
		

	}




}
