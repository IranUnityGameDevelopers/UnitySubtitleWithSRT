// wrriten bt Amin Sojoudi

using UnityEngine;
using System.Collections;
using ArabicSupport;

public class TextView : MonoBehaviour 
{
	public static TextView Instance;

	public bool isShowingText;

	private TextMesh textMesh;

	void Awake()
	{
		Instance = this;
		isShowingText = false;
		textMesh = gameObject.GetComponent<TextMesh>();
	}

	// use this function to show text
	public void setText(string _text)
	{
		textMesh.text = ArabicFixer.Fix(_text,showTashkeel: false, useHinduNumbers: true);
	}


}
