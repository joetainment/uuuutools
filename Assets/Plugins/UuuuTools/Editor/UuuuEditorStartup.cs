#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections;

[InitializeOnLoad]
class UuuuEditorStartup {

	static UuuuEditorStartup()
	{
		UuuuEditorApp.ReplaceUuuuEditorAppInstance();
	}
}


#endif