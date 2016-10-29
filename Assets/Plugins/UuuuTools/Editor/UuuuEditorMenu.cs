#if UNITY_EDITOR

// C# example:
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


//// For hotkeys...
////    % is Ctrl     # is shift    & is alt
////     then put the letter that should be the hotkey
////     make sure it's a new one


public class UuuuEditorMenu : MonoBehaviour {

	// Add a menu item named "Do Something" to MyMenu in the menu bar.
	
	[  MenuItem ("GameObject/Create Game Object At Origin - UuuuTools",false, 99100)  ] //  hotkey #F7  can be put right before end quote 
	static public void
	CreateGameObjectAtOrigin(){
		UuuuEditorOperations.CreateGameObjectAtOrigin();
	}
	
	[  MenuItem ("GameObject/Create Renderer - UuuuTools",false, 99102)  ]
	static public void
	CreateRenderer(){
		UuuuEditorOperations.CreateRenderer();
	}
	
	[  MenuItem ("GameObject/Group and Parent To New At Origin - UuuuTools",false, 99104)  ]  //  hotkey %F7  can be put right before end quote 
	static public void
	Group(){
		UuuuEditorOperations.Group();
	}

    
	//[  MenuItem ("GameObject/Apply Changes to Selected Prefabs - UuuuTools #%&F8",false, 99200)  ]
	//static public void
	//PrefabApply(){
	//	UuuuEditorOperations.PrefabApply();
	//}



	
	
	[ MenuItem("GameObject/Select Children Individually - UuuuTools",false, 99300) ] //  hotkey #F5  can be put right before end quote 
	static public void
	SelectChildrenIndividually(){
		UuuuEditorOperations.SelectChildrenIndividually();
	}


	[ MenuItem("GameObject/Make Parent Individually - UuuuTools",false, 99300) ] //  hotkey #F5  can be put right before end quote 
	static public void
	Parent(){
		UuuuEditorOperations.Parent();
	}

	[ MenuItem("GameObject/Clear Parent Individually - UuuuTools",false, 99305) ] //  hotkey #F6  can be put right before end quote 
	static public void
	Unparent(){
		UuuuEditorOperations.UnparentIndividually();		
	}








	//// Reset Transform Functions
	
	
	[ MenuItem("GameObject/Reset Transforms in World Space - UuuuTools/Reset Position in World Space &F2",false, 99405) ]
	public static void
	ResetPositionWorldSpace(){
		UuuuEditorOperations.ResetPositionWorldSpace();
	}
	
	[ MenuItem("GameObject/Reset Transforms in Local Space - UuuuTools/Reset Position in Local Space #F2",false, 99410) ]
	public static void
	ResetPositionLocalSpace(){
		UuuuEditorOperations.ResetPositionLocalSpace();
	}



	[ MenuItem("GameObject/Reset Transforms in World Space - UuuuTools/Reset Rotation in World Space &F3",false, 99415 ) ]
	public static void
	ResetRotationWorldSpace(){
		UuuuEditorOperations.ResetRotationWorldSpace();
	}
	
	[ MenuItem("GameObject/Reset Transforms in Local Space - UuuuTools/Reset Rotation in Local Space #F3",false, 99420 ) ]
	public static void
	ResetRotationLocalSpace(){
		UuuuEditorOperations.ResetRotationLocalSpace();
	}


	[ MenuItem("GameObject/Reset Transforms in World Space - UuuuTools/Reset Scale in World Space &F4",false, 99425) ]
	public static void
	ResetScaleWorldSpace(){
		UuuuEditorOperations.ResetScaleWorldSpace();
	}
	
	[ MenuItem("GameObject/Reset Transforms in Local Space - UuuuTools/Reset Scale in Local Space #F4",false, 99430) ]
	public static void
	ResetScaleLocalSpace(){
		UuuuEditorOperations.ResetScaleLocalSpace();
	}


	[ MenuItem("GameObject/Reset Transforms in World Space - UuuuTools/Reset Transform in World Space &F1", false , 99435) ]
	public static void
	ResetXWorldSpace(){
		UuuuEditorOperations.ResetXformWorldSpace();
	}

	[ MenuItem("GameObject/Reset Transforms in Local Space - UuuuTools/Reset Transform in Local Space #F1", false, 99440) ]
	public static void
	ResetXformLocalSpace(){
		UuuuEditorOperations.ResetXformLocalSpace();
	}


	
	/*
	[  MenuItem("GameObject/Test Create Asset")  ]
	public static void
	TestCreateAsset(){
		Debug.Log( Application.dataPath );

		string templatePath_ = "Plugins/GameObject/Editor";

		try {
			FileUtil.CopyFileOrDirectory(
				Application.dataPath + "/" + templatePath_ + "/" + "UuuuTextAssetTemplate.txt",
				Application.dataPath + "/" + templatePath_ + "/" + "newTextAsset.txt"
			);
		}
		catch( System.IO.IOException e ){
			//Debug.Log( "couldn't make new asset" );
		}

		AssetDatabase.Refresh();

		string textAssetFullPath_ = "Assets" + "/" + templatePath_ + "/" + "newTextAsset.txt";

		Debug.Log( textAssetFullPath_ );

		TextAsset t_ =
			AssetDatabase.LoadAssetAtPath(
				textAssetFullPath_,
				typeof(TextAsset)
			)
			as TextAsset;

		Debug.Log( t_ );
				

		//AssetDatabase.CreateAsset(    new Material(  Shader.Find("Specular")  ), "Assets/UuuuTestMaterial.mat");
		//AssetDatabase.CreateAsset( new TextAsset() as UnityEngine.Object, "Assets/UuuuTestAsset.txt" );

	}
	*/
	
	/*
	[  MenuItem("GameObject/Refresh Auto-Loaded AnimLoader Anims")  ]
	public static void
	RefreshAutoLoaded(){
		UuuuEditorAnimLoader.RefreshAutoLoaded();
	}
	*/
	
	/*
	[  MenuItem("GameObject/Real Time Editor Updates - Enable %#u")  ]
	public static void
	RealTimeEditorUpdatesEnable(){
		UuuuEditorSettings.IsRealTimeUpdateEnabled = true;
	}
	[  MenuItem("GameObject/Real Time Editor Updates - Disable %#i")  ]
	public static void
	RealTimeEditorUpdatesDisable(){
		UuuuEditorSettings.IsRealTimeUpdateEnabled = false;
	}
	*/
	




	
	//[MenuItem ("GameObject/Export GameObjects - UuuuTools/Export whole selection to single Obj file", false, 999720)]
	//static void ObjExporterExportWholeSelectionToSingleObjFile(){
	//	UuuuEditorObjExporter.ExportWholeSelectionToSingle();
	//}

	//[MenuItem ("GameObject/Export GameObjects - UuuuTools/Export each selected to single Obj file", false, 999740)]
	//static void ObjExporterExportEachSelectionToSingleObj(){
	//	UuuuEditorObjExporter.ExportEachSelectionToSingle();
	//}

	//[MenuItem ("GameObject/Export GameObjects - UuuuTools/Export all MeshFilters in selection to separate Obj Files", false, 999760)]
	//public static void
	//ObjExporterExportSelectionToSeparateObjFiles(){
	//	UuuuEditorObjExporter.ExportSelectionToSeparate();
	//}

	
	[  MenuItem("Window/UuuuTools Preferences...", false, 999520  )  ]
	public static void
	PreferencesWindowShow(){
		UuuuEditorApp.A.ShowWindow();
	}


}
#endif
