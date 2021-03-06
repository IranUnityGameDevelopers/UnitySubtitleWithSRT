﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class SRTHandler : MonoBehaviour 
{
	public static SRTHandler Instance;

	private SRTReader reader;


	public List<SRT> activeSRTList;
	public int currentIndexOfSubtitle = -1;
	public TextAsset srtFile;


	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		reader = new SRTReader ();
		if (reader.Load(AssetDatabase.GetAssetPath(srtFile))) {
			activeSRTList = reader.getSRTList();
			StartCoroutine(startSrt(activeSRTList));
		}
		else
			Debug.LogError("Can't load file");
	}


	IEnumerator startSrt(List<SRT> array)
	{
		foreach (var item in array) {
			currentIndexOfSubtitle = array.IndexOf(item);
			TextView.Instance.setText(item.text);
			yield return new WaitForSeconds(item.time);
		}
		currentIndexOfSubtitle = -1;
		TextView.Instance.setText("Finished");
	}


	IEnumerator startSrtFromPointToPoint(List<SRT> array , int startPoint , int finalPoint)
	{
		if (finalPoint > array.Count) {
			Debug.LogError("Final point is biger than array lenght");
			return false;
		}
		if (startPoint > finalPoint) {
			Debug.LogError("Final point is less than array startPoint");
			return false;
		}
		for (int i = startPoint; i <= finalPoint; i++) {
			currentIndexOfSubtitle = i;
			TextView.Instance.setText(array[i].text);
			yield return new WaitForSeconds(array[i].time);
		}
		currentIndexOfSubtitle = -1;
		TextView.Instance.setText("Finished");
	}
	



}
