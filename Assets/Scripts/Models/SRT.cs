using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[Serializable]
public class SRT : ScriptableObject
{

	public string text ;

	public float time;


	public void Init(string _text , float _time)
	{
		text = _text;
		time = _time;
	}

	public static SRT CreateInstance(string _text , float _time)
	{
		var data = ScriptableObject.CreateInstance<SRT>();
		data.Init(_text , _time);
		return data;
	}


}
