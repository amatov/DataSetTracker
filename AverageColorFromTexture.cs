using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class AverageColorFromTexture : MonoBehaviour
{


	[SerializeField]
	private OpenCVCreateMat openCVMat;

	[SerializeField]
	private OpenCVUpdateLoop openCVUpdateLoop;

	public VideoClip videoToPlay;

	private Color targetColor;
	private VideoPlayer videoPlayer;
	private VideoSource videoSource;
	private Renderer rend;
	private Texture tex;
	private AudioSource audioSource;

	void Start()
	{
		videoFrame = new Texture2D(2, 2);
		Application.runInBackground = true;
		StartCoroutine(playVideo());
	}

	IEnumerator playVideo()
	{
		rend = GetComponent<Renderer>();

		videoPlayer = gameObject.AddComponent<VideoPlayer>();
		audioSource = gameObject.AddComponent<AudioSource>();

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;

		//videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.source = VideoSource.Url;



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
		rend.material.mainTexture = tex;

		//Enable new frame Event
		videoPlayer.sendFrameReadyEvents = true;

		//Subscribe to the new frame Event
		videoPlayer.frameReady += OnNewFrame;

		//Play Video
		videoPlayer.Play();

		//Play Sound
		audioSource.Play();

		Debug.Log("Playing Video");
		while (videoPlayer.isPlaying)
		{
			Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
			yield return null;
		}
		Debug.Log("Done Playing Video");
	}

	//Initialize in the Start function
	Texture2D videoFrame;

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


		openCVMat.CreateMats (videoPlayer.texture);
		openCVUpdateLoop.StartTracking = true;


		//targetColor = CalculateAverageColorFromTexture(videoFrame);
		//lSource.color = targetColor;
	}

}