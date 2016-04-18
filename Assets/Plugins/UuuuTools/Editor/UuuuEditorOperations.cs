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


public class UuuuEditorOperations : MonoBehaviour {

	// Add a menu item named "Do Something" to MyMenu in the menu bar.
	
	static public void
	CreateGameObjectAtOrigin(){
		GameObject gobj_ = new GameObject();
		gobj_.name = "GameObject";
		Undo.RegisterCreatedObjectUndo(	gobj_, "Create " + gobj_.name );
		Selection.activeTransform = gobj_.transform;
	}

	static public void
	CreateRenderer(){
		GameObject gobj_ = new GameObject();
		gobj_.name = "Renderer";
		Undo.RegisterCreatedObjectUndo(	gobj_, "Create " + gobj_.name );
		Selection.activeTransform = gobj_.transform;
		Undo.RecordObject( gobj_.transform, "Add Rendering Script" );
		gobj_.AddComponent<UuuuRenderJobStandaloneScript>();
	}


	static public void
	Group(){
		//Debug.Log( " **** This feature not yet implemented ****  "  );
		Transform[] xforms_ = Selection.transforms;	
        GameObject gobj_ = new GameObject();
		gobj_.name = "Group";
		Undo.RegisterCreatedObjectUndo(	gobj_, "Create " + gobj_.name );
        
        //Array.Resize<Transform>( ref xforms_, xforms_.Length + 1 );
        //xforms_[xforms_.Length - 1] = gobj_.transform;
        
		//foreach ( Transform x_ in xforms_){ Debug.Log( x_.name ); }
        
		foreach ( Transform x_ in xforms_){
            Undo.SetTransformParent( x_, gobj_.transform, gobj_.name );
		}
	}




	
	//// Unparent is only useful in the editor, since it's already just setting a property
	//// thus this function is only in UuuuEditorOperations   it's only 
	static public void
	SelectChildrenIndividually(){
		List<Transform> xformsList_ = UuuuEditorApp.A.selectionManager.selectedTransforms;
		Transform[] xforms_ = xformsList_.ToArray();
		Undo.RecordObjects( xforms_, "Clear Parent Individually" );

		List<Transform> toSelect_ = new List<Transform>();
		List<GameObject> toSelectGobjs_ = new List<GameObject>();

		foreach ( Transform x_ in xforms_){
			toSelect_.Add( x_ );
			SelectChildrenIndividuallyHelper ( toSelect_, x_ );
		}

		foreach ( Transform x_ in toSelect_){
			toSelectGobjs_.Add ( x_.gameObject );
		}

		Selection.objects = toSelectGobjs_.ToArray();
	}

	////  we could add functions here to select first child and select parent, kinda like up and down arrows in Maya

	static public void
	SelectChildrenIndividuallyHelper( List<Transform> listToAddTo_, Transform xform_ ){
		foreach (Transform child_ in xform_) {
			listToAddTo_.Add( child_ );
			SelectChildrenIndividuallyHelper ( listToAddTo_, child_ );
		}

	}


	
	//// Unparent is only useful in the editor, since it's already just setting a property
	//// thus this function is only in UuuuEditorOperations   it's only 
	static public void
	Unparent(){
		Transform[] xforms_ = Selection.transforms;	
		Undo.RecordObjects( xforms_, "Clear Parent" );
		
		foreach ( Transform x_ in xforms_){
			x_.parent = null;
		}
	}

	//// Unparent is only useful in the editor, since it's already just setting a property
	//// thus this function is only in UuuuEditorOperations   it's only 
	static public void
	UnparentIndividually(){
		List<Transform> xformsList_ = UuuuEditorApp.A.selectionManager.selectedTransforms;
		Transform[] xforms_ = xformsList_.ToArray();
		Undo.RecordObjects( xforms_, "Clear Parent Individually" );
		
		foreach ( Transform x_ in xforms_){
			x_.parent = null;
		}
	}

	//// Parent is only useful in the editor, since it's already just setting a property
	//// thus this function is only in UuuuEditorOperations   it's only 
	static public void
	Parent(){  
		// Get an array (like a list) of all selected transforms
		
		List<Transform> xforms_ = UuuuEditorApp.A.selectionManager.selectedTransforms;

		// Tell unity that we want to be able to undo the changes,
		//  and which objects' changes need to be undo able
		//  also, we provide a name for what the undo menu will show
		Undo.RecordObjects( xforms_.ToArray() , "Parent By Selection" );
		
		// Get just the last selected transform
		Transform p_ = xforms_[ xforms_.Count - 1 ];
		
		// Get the unique id of parent, later we'll get more ids as xIds
		int pId_ = p_.GetInstanceID();
		int xId_;
		
		foreach (Transform x_ in xforms_){
			// Get the unique id of x, the child
			//  we are about to parent
			// If the ids are different,
			// it means that x and p are different
			// objects, so x can be parented to p
			
			xId_ = x_.GetInstanceID();
			if (pId_ != xId_ ) x_.parent = p_;
		}
	}

		
	///   Gets a list of the currently selected objects
	///   Checks if they are prefab instances and if so,
	///   replaces the editor prefab with the current instanced prefab.
	static public void
	PrefabApply(){
		//Debug.Log ("Applying Prefabs!");
		GameObject[] gobjs_ = Selection.gameObjects;
		PrefabApply( gobjs_ );
	}
	static public void
	PrefabApply(GameObject[] gobjs_ ){
		foreach( GameObject gobj_ in gobjs_ )
		{
			PrefabApply( gobj_ );
		}
	}
	static public void
	PrefabApply( GameObject gobj_ ){
		if (PrefabUtility.GetPrefabType(gobj_) == PrefabType.PrefabInstance) {
			//Debug.Log ("Object was a prefab! Applying.");
			UnityEngine.Object prefabParent_ = PrefabUtility.GetPrefabParent(gobj_);
			PrefabUtility.ReplacePrefab(gobj_, prefabParent_);
		}
		else {
			//Debug.Log ("Object was not a prefab!");
		}
	}
	


	
	static public void
	ResetPositionWorldSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Position in World Space" );
		UuuuXform.ResetPositionWorldSpace( xforms_);
	}
	static public void
	ResetPositionLocalSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Position in Local Space" );
		UuuuXform.ResetPositionLocalSpace( xforms_);
	}
	
	static public void
	ResetRotationWorldSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Rotation in World Space" );
		UuuuXform.ResetRotationWorldSpace( xforms_ );
	}
	static public void
	ResetRotationLocalSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Rotation in Local Space" );
		UuuuXform.ResetRotationLocalSpace( xforms_ );
	}

	static public void
	ResetScaleWorldSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Scale in World Space" );
		UuuuXform.ResetScaleWorldSpace( xforms_ );
	}
	static public void
	ResetScaleLocalSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Scale in Local Space" );
		UuuuXform.ResetScaleLocalSpace( xforms_ );
	}

	
	static public void
	ResetXformWorldSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Transform in World Space" );
		UuuuXform.ResetXformWorldSpace( xforms_ );
	}	
	static public void
	ResetXformLocalSpace(){
		Transform[] xforms_ = Selection.transforms;
		Undo.RecordObjects( xforms_, "Reset Transform in Local Space" );
		UuuuXform.ResetXformLocalSpace( xforms_ );
	}
	
	
		
}


#endif