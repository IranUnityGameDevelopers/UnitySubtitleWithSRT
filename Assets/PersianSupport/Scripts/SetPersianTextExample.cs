using UnityEngine;
using System.Collections;
using PersianSupport;

public class SetArabicTextExample : MonoBehaviour {
	
	public string text;
	
	// Use this for initialization
	void Start () {	
		gameObject.guiText.text = "This sentence (wrong display):\n" + text +
			"\n\nWill appear correctly as:\n" + PersianFixer.Fix(text, false, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
