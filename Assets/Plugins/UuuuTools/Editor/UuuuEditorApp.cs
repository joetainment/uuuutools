#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections;




public class UuuuEditorApp {

	////////////////////////////////////////
	//// Static Members and Methods

	public static UuuuEditorApp 			A	{  get { return _GetUuuuEditorAppInstance(); }  }

	protected static UuuuEditorApp 		_A;
	
	public static void
	UpdateStaticCallback(){
		if (_A!=null){
			 _A.UpdateCallback();
			//Debug.Log( "Updated!" );
		}
		else {
			_A = GetUuuuEditorAppInstance();
			_A.UpdateCallback();
			//Debug.Log( "Not Updated!" );
		}
	}

	//// Static Public Methods	
	public static void
	FirstUpdateStaticCallback(){
		A.FirstUpdateCallback();
		EditorApplication.update -= FirstUpdateStaticCallback;
	}


	public static UuuuEditorApp
	ReplaceUuuuEditorAppInstance(){
		_A = new UuuuEditorApp();
		
		EditorApplication.update -= FirstUpdateStaticCallback;
		EditorApplication.update += FirstUpdateStaticCallback;
		
		EditorApplication.update -= UpdateStaticCallback;
		EditorApplication.update += UpdateStaticCallback;

		//EditorApplication.update -= Update;
		//EditorApplication.update += Update;

		return _A;
	}

	public static UuuuEditorApp
	GetUuuuEditorAppInstance(){
		return _GetUuuuEditorAppInstance();
	}

	protected static UuuuEditorApp
	_GetUuuuEditorAppInstance(){
		UuuuEditorApp a_ = _A;
		if (a_!=null){
			return a_;
		} else {
			return new UuuuEditorApp();
		}

	}







	////////////////////////////////////////
	//// Instance Members and Methods


	//// Public members
	//// 	public members with matching protected getters go last
	public 	  UuuuEditorWindow					window  { get { return _Window; }  }	
	public 	  UuuuEditorSelectionManager		selectionManager  { get { return _selectionManager; }  }


	//// Protected Members
	//// 	protected members with matching public getters go first
	protected UuuuEditorSelectionManager		_selectionManager;
	protected static UuuuEditorWindow					_Window;



	
	protected int 								_counter = 0;
	protected int 								_selectionObjectsLengthFromLastUpdate;
	
	//// public List<string, string>					pathsFor


	protected string selectionIdStringLast = "";

	//// Constructor
	public
	UuuuEditorApp() {
		_selectionObjectsLengthFromLastUpdate = Selection.objects.Length;
		_selectionManager = new UuuuEditorSelectionManager();
		// showWindow();
	}


	////   Public Methods

	public void
	UpdateCallback(){
		//if Editor.
		if (UuuuEditorSettings.IsRealTimeUpdateEnabled==true){
			string newSelectionIdStr_ = "UuuuSelectionInstanceIdsAsString";
			for (int i_ = 0; i_ < Selection.instanceIDs.Length; i_++){
				newSelectionIdStr_ = newSelectionIdStr_ + " " + Selection.instanceIDs[i_].ToString();
			}
			//Debug.Log( "IdStrings:" );
			//Debug.Log( selectionIdStringLast );
			//Debug.Log( newSelectionIdStr_ );

			if (newSelectionIdStr_ != selectionIdStringLast){
				_selectionManager.Update( );
			}
			selectionIdStringLast = newSelectionIdStr_;
			
			UpdateLast();
		}

	}

	// //  Put anything here that needs to happen after everything else in update
	public void
	UpdateLast(){
		//Debug.Log(  _selectionObjectsLengthFromLastUpdate  );
		_selectionObjectsLengthFromLastUpdate = Selection.objects.Length;
	}
	
	public void
	FirstUpdateCallback(){
		//Debug.Log( "UuuuEditor scripted plugin started." );

		// We can do stuff here that should only occur on the first update!
	}

	public void
	SetSelectionObjectsLengthFromLastUpdate( int len_ ){
		_selectionObjectsLengthFromLastUpdate = len_;
	}

	public void
	ShowWindow(){
		if (_Window==null){
			_Window = UuuuEditorWindow.GetUuuuEditorWindow();
		}
		_Window.Show();
	}

	// **** Idea, later on, try implementing something that uses this:
	//       DidReloadScripts
	//


	// **** Make both the CSI interpreter and the Java lang interpreter work
	//     can you make boo.lang.interpreter work in the editor? maybe...
	//  can you make iron python work???  maybe...
	//
	//   yep, it really looks like you can... try this!
	//    http://techartsurvival.blogspot.ca/2013/12/embedding-ironpython-in-unity-tech-art.html
}


#endif