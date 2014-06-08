using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EditExistingSRTFile : EditorWindow {

	private List<string> texts = new List<string>();
	private List<float> times = new List<float>();
	private int index = 0;
	private Vector2 scrollPos;
	private string helpBoxMessage = "Load a SRT file or text file to begin";
	private MessageType helpBoxMessageType = MessageType.Info;

	private SRTReader reader;
	private SRTWriter writer;

	public Object source;
	
	[MenuItem("Subtitle/Edit a SRT File")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(EditExistingSRTFile));
	}
	
	void OnGUI()
	{
		GUILayout.Label ("Edit a SRT File", EditorStyles.boldLabel);

		EditorGUILayout.BeginHorizontal();
		source = EditorGUILayout.ObjectField(source, typeof(Object), true);
		EditorGUILayout.EndHorizontal();
		if (GUILayout.Button ("Load File"))
				if (source == null) {
					helpBoxMessage = "No object selected for searching";
					helpBoxMessageType = MessageType.Error;
				} else {
						ReadFromFile ();
						helpBoxMessage = "SRT File Loaded";
						helpBoxMessageType = MessageType.Info;
				}
		EditorGUILayout.HelpBox (helpBoxMessage , helpBoxMessageType);
		
		if (GUILayout.Button("Add new Part")) {
			addSRT();
		}
		if (GUILayout.Button("RemoveLast")) {
			removeLast();
		}
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width (position.width), GUILayout.Height (position.height - 175));
		
		
		for (int i = 0; i < texts.Count; i++) {
			GUILayout.Label ("SRT Number " + (i+1), EditorStyles.boldLabel);
			texts[i] = EditorGUILayout.TextField ("Text", texts[i]);
			times[i] = EditorGUILayout.Slider ("Time", times[i], 0, 35);
		}
		
		EditorGUILayout.EndScrollView ();
		
		if (GUILayout.Button("Save Changes to File")) {
			saveToFile();
		}
	}
	
	
	void ReadFromFile()
	{
		reader = new SRTReader ();
		if (reader.Load(AssetDatabase.GetAssetPath(source))) {
			texts = reader.getTexts();
			times = reader.getTimes();
		}
	}


	void saveToFile()
	{
		writer = new SRTWriter ();
		writer.writeToFile (texts , times , AssetDatabase.GetAssetPath(source));
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
