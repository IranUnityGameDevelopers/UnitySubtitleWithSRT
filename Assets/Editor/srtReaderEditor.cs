using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class srtReaderEditor : EditorWindow
{
	// Add menu item named "srt Reader" to the Window menu
	[MenuItem("Subtitle/Convert srt files to txt files")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(srtReaderEditor));
	}
	public string buttonLabel = "Convert Them!";
	public bool isConverted = false; 

	void ChangeLabel() {
		if (!isConverted){
			buttonLabel = "Convert Them!";
		}else{
			buttonLabel = "Converted";
		}
	}
		
	void OnGUI()
	{

		// Creates a label to show what we do 
		EditorGUILayout.LabelField("Convertor:"," Click to Convert srt Files To txt");

			
			// Creates a button . if button clicked Start Converting
		if( GUILayout.Button(buttonLabel) )
		{
			isConverted = !isConverted;
			ChangeLabel();
		}
		
		if( isConverted == true )
		{
			// Gets all files with .srt Extention in SRTFiles folder
			string[] filePaths = Directory.GetFiles(Application.dataPath+"/SRTFiles/", "*.srt", SearchOption.AllDirectories);
			
			foreach(string file in filePaths) {
				// Makes .srt Extentions to .txt
				System.IO.File.Move(file, file.Replace(".srt", ".txt"));
			}

		}


	}

	
}