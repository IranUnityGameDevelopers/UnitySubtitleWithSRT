using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class CreateNewSRTFile : EditorWindow
{
	
	private List<string> texts = new List<string>();
	private List<float> times = new List<float>();
	private int index = 0;
	private Vector2 scrollPos;

	private SRTWriter writer;
	
	[MenuItem("Subtitle/Create new SRT File")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(CreateNewSRTFile));
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
		writer = new SRTWriter ();
		writer.writeToFile (texts , times , Application.dataPath+"/SRTFiles/newSRTFile.txt");
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
		//Debug.Log (index + " , " + texts.Count + " , " + times.Count);
	}
}
