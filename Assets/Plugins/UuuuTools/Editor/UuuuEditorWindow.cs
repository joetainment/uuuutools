#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

// to get them back, use: 
// EditorUtility.InstanceIDToObject( id_ )


public class UuuuEditorWindow : EditorWindow {


	// Static	

	public static UuuuEditorWindow 			Window {    get { return GetUuuuEditorWindow(); }    }
	protected static UuuuEditorWindow 			_Window;
	public static string Title	= 			"UuuuTools";


	//static public void
	//Show() {
	//	GetWindow<UuuuEditorWindow>();
	//}

	static public UuuuEditorWindow
	GetUuuuEditorWindow(){
		if (_Window==null){
			_Window = GetWindow<UuuuEditorWindow>();
			_Window.title = Title;
			//_Window.minSize = new Vector2( 200, 200 )
		}
		return _Window;
	}

	public void
	OnGUI() {

		/*
		GUILayout.Button(
			"Button_Test"
		);
		*/

		/*
		EditorGUILayout.Space();
		*/

		UuuuEditorSettings.IsAssetProcessingEnabled = EditorGUILayout.Toggle(
			"Process Assets",
			UuuuEditorSettings.IsAssetProcessingEnabled
		);
		UuuuEditorSettings.IsProcessUcx = EditorGUILayout.Toggle(
			"Process UCX Colliders",
			UuuuEditorSettings.IsProcessUcx
		);
		
		UuuuEditorSettings.IsProcessFixesDefaultScale = EditorGUILayout.Toggle(
			"Process Fix FBX Scale",
			UuuuEditorSettings.IsProcessUcx
		);
		UuuuEditorSettings.IsProcessFixesDefaultNormalsAndTangents = EditorGUILayout.Toggle(
			"Process Fix Tangents",
			UuuuEditorSettings.IsProcessFixesDefaultNormalsAndTangents
		);

		
		UuuuEditorSettings.IsRealTimeUpdateEnabled = EditorGUILayout.Toggle(
			"Realtime Editor",
			UuuuEditorSettings.IsRealTimeUpdateEnabled
		);

		UuuuEditorSettings.IsIgnoreUuuuTests = EditorGUILayout.Toggle(
			"Ignore Uuuu Tests",
			UuuuEditorSettings.IsIgnoreUuuuTests
		);
		
		EditorGUILayout.HelpBox( "Generally you should keep Realtime Editor set to be on.  UuuuTools has several features that need real time updates to work properly.", MessageType.Info, true );
		
	}

	public void
	OnSelectionChange(){
		UuuuEditorApp.A.selectionManager.onSelectionChange();
	}

	public void
	show(){
		if (_Window==null) _Window.Show();
	}
}




/*
	class EditorGUILayoutToggle extends EditorWindow {
		
		var showBtn : boolean = true;
		
		@MenuItem("Examples/Editor GUILayout Toggle Usage")
		static function Init() {
			var window = GetWindow(EditorGUILayoutToggle);
			window.Show();
		}
		function OnGUI() {
			showBtn = EditorGUILayout.Toggle("Show Button", showBtn);
			if(showBtn)
				if(GUILayout.Button("Close"))
					this.Close();
		}
	}
*/











//public int[] selectionIDs : int[];
//@MenuItem("Example/Selection Saver")

	//public static function Init() {
	//	var window = GetWindow(SelectionChange);
	//	window.Show();
	//}
/*
	function OnGUI() {
		if(GUILayout.Button("Save"))
			SaveSelection();
		if(GUILayout.Button("Load"))
			LoadLastSavedSelection();
	}
	function OnSelectionChange() {
		selectionIDs = Selection.instanceIDs;
	}
*/



#endif