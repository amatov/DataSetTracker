using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_FadeOut : MonoBehaviour {


	[SerializeField]
	private float FadeDuration;

	[SerializeField]
	private Color CurrentColor;

	private Image TrackerImage;



	public Color StartColor;
	public Color EndColor;



	void Start(){
		TrackerImage = GetComponent<Image> ();
		StartCoroutine(FadeTo(0.0f, FadeDuration));
	
	}



	IEnumerator FadeTo(float aValue, float aTime)
	{

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			CurrentColor = Color.Lerp (StartColor, EndColor, t);
			//Color newColor = new Color(r, g, b, Mathf.Lerp(alpha,aValue,t));
			TrackerImage.color = CurrentColor;
			yield return null;
		}

		Destroy (this.gameObject);
	}

}
