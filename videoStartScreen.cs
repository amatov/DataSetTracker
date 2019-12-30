using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class videoStartScreen : MonoBehaviour
{



	private VideoClip videoToPlay;

	private Color targetColor;
	private VideoPlayer videoPlayer;
	private VideoSource videoSource;
	private Renderer rend;
	[SerializeField]
	private Texture tex;
	private AudioSource audioSource;
	private Texture2D videoFrame;
	private bool bCallMatCreationOnce = false;

	private bool bRecordingMode = false;


	void Start()
	{
		initVideo ();
	}

	public void initVideo(){

		videoFrame = new Texture2D(2, 2);
		Application.runInBackground = true;
		StartCoroutine(playVideo());
	}

	IEnumerator playVideo()
	{
		//rend = GetComponent<Renderer>();

		videoPlayer = gameObject.GetComponent<VideoPlayer>();
		audioSource = gameObject.AddComponent<AudioSource>();

		//videoPlayer.Stop ();

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;

		//videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.source = VideoSource.Url;


		videoPlayer.url =  Application.dataPath + "/StreamingAssets/logo.mp4";//VideoSource.Url;




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



	void OnLoop(VideoPlayer source){


	}


	//Initialize in the Start function

	void OnNewFrame(VideoPlayer source, long frameIdx)
	{

		RenderTexture renderTexture = source.texture as RenderTexture;

		if (videoFrame.width != renderTexture.width || videoFrame.height != renderTexture.height)
		{
			videoFrame.Resize(renderTexture.width, renderTexture.height);
		}
		RenderTexture.active = renderTexture;
		videoFrame.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		videoFrame.Apply();
		RenderTexture.active = null;

		tex = renderTexture;

	}



}
