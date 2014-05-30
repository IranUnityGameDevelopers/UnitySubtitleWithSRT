using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SRTHandler : MonoBehaviour 
{
	private SRTReader reader;


	void Start()
	{
		reader = gameObject.GetComponent<SRTReader>();
		if (reader.Load()) {
			StartCoroutine(startSrt(reader.getList()));
		}
		else
			Debug.LogError("Can't load file");
	}


	IEnumerator startSrt(List<SRT> array)
	{
		foreach (var item in array) {
			TextView.Instance.setText(item.text);
			yield return new WaitForSeconds(item.time);
		}
		TextView.Instance.setText("Finished");
	}

}
