#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
class UuuuEditorStartup {

	static UuuuEditorStartup()
	{
		UuuuEditorApp.ReplaceUuuuEditorAppInstance();
	}
}


#endif