using UnityEngine;
using System.Collections;

public class SRT 
{
	public string text {
				get;
				set;
	}

	public float time {
				get;
				set;
	}

	public SRT(string _text , float _time)
	{
		text = _text;
		time = _time;
	}


}
