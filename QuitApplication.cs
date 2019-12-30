using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour {

	public void QuitApp(){

		Application.Quit ();

	}


	public void ShowMainMenu(){

		SceneManager.LoadScene ("Login");

	}


	public void ShowHelp(){

		Application.OpenURL ("http://www.datasetanalysis.com/help");
	}

}
