using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class MyWindow : EditorWindow
{
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;


	// Mine
	private List<string> texts = new List<string>();
	private List<float> times = new List<float>();
	private int index = 0;
	private Vector2 scrollPos;

	
	// Add menu item named "My Window" to the Window menu
	[MenuItem("Subtitle/Create new SRT File")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(MyWindow));
	}
	
	void OnGUI()
	{
		GUILayout.Label ("Create SRT File", EditorStyles.boldLabel);

		if (GUILayout.Button("Add new Part")) {
			addSRT();
		}
		if (GUILayout.Button("RemoveLast")) {
			removeLast();
		}
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width (position.width), GUILayout.Height (position.height - 90));

			
		for (int i = 0; i < texts.Count; i++) {
			GUILayout.Label ("SRT Number " + (i+1), EditorStyles.boldLabel);
			texts[i] = EditorGUILayout.TextField ("Text", texts[i]);
			times[i] = EditorGUILayout.Slider ("Time", times[i], 0, 35);
		}

		EditorGUILayout.EndScrollView ();

		if (GUILayout.Button("Create File")) {
			saveToFile();
		}
	}


	void saveToFile()
	{

	}

	void removeLast()
	{
		if (texts.Count > 0) {
			texts.RemoveAt (texts.Count - 1);
			times.RemoveAt(times.Count - 1);
			index--;
		}
	}


	void addSRT()
	{
		texts.Add ("");
		times.Add (0);
		index++;
		Debug.Log (index + " , " + texts.Count + " , " + times.Count);
	}
}
