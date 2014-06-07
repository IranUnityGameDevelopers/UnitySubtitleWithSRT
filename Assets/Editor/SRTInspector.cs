using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SRT))]
public class SRTInspector : Editor {

	public override void OnInspectorGUI () {
		serializedObject.Update();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("time"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("text"));
		serializedObject.ApplyModifiedProperties();
	}
}
