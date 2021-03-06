using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class VideoPlayerManager : MonoBehaviour
{


	[SerializeField]
	private OpenCVCreateMat openCVMat;

	[SerializeField]
	private OpenCVUpdateLoop openCVUpdateLoop;

	[SerializeField]
	private TracePoints tracePoints;

	[SerializeField]
	private Text FrameRateText;

	[SerializeField]
	private Slider VideoSlider;

	[SerializeField]
	private Text VideoResolution;

	[SerializeField]
	private Text VideoName;

	[SerializeField]
	private RecordUI recordUI;


	[SerializeField]
	private Slider seekBar;

	public VideoClip videoToPlay;


	[SerializeField]
	public string sURL_Video;


	private Color targetColor;
	private VideoPlayer videoPlayer;
	private VideoSource videoSource;
	private Renderer rend;
	private Texture tex;
	private AudioSource audioSource;
	public Texture2D videoFrame;
	private bool bCallMatCreationOnce = false;

	private bool bRecordingMode = false;

	private bool startUP = true;

	void Start()
	{



		audioSource = gameObject.AddComponent<AudioSource>();
		videoPlayer = gameObject.GetComponent<VideoPlayer>();

		//sURL_Video = Application.dataPath + "/StreamingAssets/ebTrack_synethic_2.mp4";
		sURL_Video = Application.dataPath + "/StreamingAssets/lesha1.mp4";


		initVideo ();

	}

	public void initVideo(){

		bCallMatCreationOnce = false;
		videoFrame = new Texture2D(2, 2);
		Application.runInBackground = true;

		StartCoroutine(playVideo());
	}

	IEnumerator playVideo()
	{
		//rend = GetComponent<Renderer>();



		//videoPlayer.Stop ();

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;

		//videoPlayer.url =  Application.dataPath + VideoSource.Url;
		videoPlayer.url =  Application.dataPath + "/StreamingAssets/ebTrack_synethic_2.mp4";//VideoSource.Url;
		//videoPlayer.source = VideoSource.VideoClip;

		//videoPlayer.url = sURL_Video;



		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);

		//Set video To Play then prepare Audio to prevent Buffering
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();

		//Wait until video is prepared
		while (!videoPlayer.isPrepared)
		{
			Debug.Log("Preparing Video");
			yield return null;
		}
		Debug.Log("Done Preparing Video");

		//Assign the Texture from Video to Material texture
		tex = videoPlayer.texture;
		//rend.material.mainTexture = tex;

		//force vidoe player to not skip frames
		videoPlayer.skipOnDrop = false;


		//Enable new frame Event
		videoPlayer.sendFrameReadyEvents = true;

		//Subscribe to the new frame Event
		videoPlayer.frameReady += OnNewFrame;

		//Subscribe to the new frame Event
		videoPlayer.loopPointReached += OnLoop;

		//setup seek bar
		seekBar.maxValue = videoPlayer.frameCount;


		//Play Video
		videoPlayer.Play();

		//Play Sound
		audioSource.Play();

		Debug.Log("Playing Video");
		while (videoPlayer.isPlaying)
		{
			//Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
			yield return null;
		}
		Debug.Log("Done Playing Video");

	}


	public void StartRecordingData(){
	

		bRecordingMode = true;
		VideoSlider.value = 1.0f;

		//clear out data
		openCVUpdateLoop.ResetLoop ();

		//reset video
		videoPlayer.frame = 0;
		videoPlayer.Play ();

	}


	public void FinishedRecordingData(){

		//Do something with the data in TracePoints class
		tracePoints.FinishedRecordingGiveMeAllTheTracers();
	}

	void OnLoop(VideoPlayer source){
	
		if (bRecordingMode == true) {
			videoPlayer.Pause ();
			FinishedRecordingData ();
			bRecordingMode = false;
			recordUI.successRecordUI ();
			openCVUpdateLoop.ResetLoop ();

		} else {

			//reset
			Debug.Log ("Loop  Video");
			openCVUpdateLoop.ResetLoop ();
		}


	}


	//Initialize in the Start function

	void OnNewFrame(VideoPlayer source, long frameIdx)
	{
		videoPlayer.Pause ();
		seekBar.value = videoPlayer.frame;

		RenderTexture renderTexture = source.texture as RenderTexture;

		if (videoFrame.width != renderTexture.width || videoFrame.height != renderTexture.height)
		{
			videoFrame.Resize(renderTexture.width, renderTexture.height);
		}
		RenderTexture.active = renderTexture;
		videoFrame.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		videoFrame.Apply();
		RenderTexture.active = null;

		VideoResolution.text = "W:" + renderTexture.width.ToString () + " x " + "H:" + renderTexture.height.ToString ();
		VideoName.text = videoPlayer.url;
			

		if (bCallMatCreationOnce == false) {
			openCVMat.CreateMats (videoFrame);
			openCVUpdateLoop.initOpenCV (videoFrame);
			openCVUpdateLoop.StartTracking = true;
			bCallMatCreationOnce = true;
		}

		openCVUpdateLoop.RunOpenCV (videoFrame, frameIdx.ToString ());
		FrameRateText.text = "Video frame: " + frameIdx.ToString () + " of " + videoPlayer.frameCount.ToString();

		//targetColor = CalculateAverageColorFromTexture(videoFrame);
		//lSource.color = targetColor;
	}

	public void VideoSpeed(){

		videoPlayer.playbackSpeed = 1.0f;//VideoSlider.value;
	
	}



	public void Seek(){

		//videoPlayer.Pause ();

		//clear out data
		//openCVUpdateLoop.ResetLoop ();

		videoPlayer.frame = (long)seekBar.value;
		//videoPlayer.Play ();

	
	}

}