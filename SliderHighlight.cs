using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHighlight : MonoBehaviour {
		
	[SerializeField]
	private float FadeDuration;

	[SerializeField]
	private Color CurrentColor;

	[SerializeField]
	private RawImage HighlightImage;

	[SerializeField]
	private Text HighlightText;

	[SerializeField]
	private Color HighlightColor;

	[SerializeField]
	private Color StartColor;



	void Start(){

		HighlightImage.color = StartColor;
		HighlightText.color = StartColor;
		StartCoroutine(FadeTo(0.0f, FadeDuration));

	}



	IEnumerator FadeTo(float aValue, float aTime)
	{
		Color CurrentColor;

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			CurrentColor = Color.Lerp (StartColor, HighlightColor, t);
			//Color newColor = new Color(r, g, b, Mathf.Lerp(alpha,aValue,t));
			HighlightImage.color = CurrentColor;
			HighlightText.color = CurrentColor;
			yield return null;
		}
	}
		
		public void HighlightOnMouseEnter() {
			StartCoroutine(FadeTo(1.0f, FadeDuration));
		}


		public void HighlightOnMouseExit() {
		StartCoroutine(FadeTo(0.0f, FadeDuration));
		}



//
//
//		void OnMouseOver() {
//			rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
//		}
//		void OnMouseExit() {
//			rend.material.color = Color.white;
//		}
//
}
