// wrriten bt Amin Sojoudi

using UnityEngine;
using System.Collections;

public class TextView : MonoBehaviour 
{
	public static TextView Instance;

	public bool isShowingText;

	void Awake()
	{
		Instance = this;
		isShowingText = false;
	}

	// use this function to show text
	public void setText(string _text)
	{
		guiText.text = _text;
	}


}
