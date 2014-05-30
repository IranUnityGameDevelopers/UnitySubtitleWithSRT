using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

public class SRTReader : MonoBehaviour 
{

	public TextAsset srtFile;

	private List<SRT> srtArray = new List<SRT>();


	public bool Load()
	{
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(AssetDatabase.GetAssetPath(srtFile), Encoding.UTF8);
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				readState state;
				state = readState.srtNumber;
				string temp = "";
				float diffTime = 0;
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();
					if (line != null)
					{
						line = line.Trim();
						switch (state) {
						case readState.srtNumber :
							state = readState.time;
							break;
						case readState.time :
							string[] entries = line.Split(new string[] { "-->" } , System.StringSplitOptions.None);
							if (entries.Length > 0)
							{
								Debug.Log("initial Time : " + getTime( entries[0]));
								Debug.Log("final Time : " + getTime( entries[1]));
							}
							diffTime = getTime( entries[1]) - getTime( entries[0]);
							state = readState.text;
							break;
						case readState.text :
							if (line.Equals("")) {
								state = readState.srtNumber;
								Debug.Log("text : " + temp);
								srtArray.Add(new SRT(temp , diffTime));
								temp = "";
							}
							else {
								temp = temp + " " + line;
							}
							break;
						}
					}
				}
				while (line != null);
				Debug.Log("text : " + temp);
				srtArray.Add(new SRT(temp , diffTime));
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (IOException e)
		{
			Debug.LogError("Error : " + e.Data.ToString());
			return false;
		}
	}

	public List<SRT> getList()
	{
		return srtArray;
	}

	private float getTime(string _time)
	{
		float time = 0;
		string[] entries = _time.Split(',');
		string[] entries2 = entries[0].Split(':');
		time = float.Parse( entries2[0]) * 3600 
			+ float.Parse(entries2[1]) * 60 
				+ float.Parse(entries2[2])
				+  float.Parse(entries[1]) /(float) Mathf.Pow(10 , entries[1].Trim().Length);
		return time;
	}


}

public enum readState{
	srtNumber ,
	time , 
	text ,
}
