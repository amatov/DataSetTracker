using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class keepFPSHigh : MonoBehaviour {

    [SerializeField]
    private OpenCVUpdateLoop openCVUpdateLoop;


    [SerializeField]
    private VideoPlayer videoPlayer;


    public void StopTrackingToIncreaseUISpeed() {
        videoPlayer.Stop();
        Debug.Log ("StopTrackingToIncreaseUISpeed");
        openCVUpdateLoop.StartTracking = false;

    }

	public void StartTrackingToIncreaseUISpeed() {

        StartCoroutine(RestartTracking());
        Debug.Log ("StartTrackingToIncreaseUISpeed");
        openCVUpdateLoop.StartTracking = true;
        videoPlayer.Play();

    }

    IEnumerator RestartTracking() {

        yield return new WaitForSeconds(1);
        openCVUpdateLoop.StartTracking = true;
        videoPlayer.Play();

    }


}


	

