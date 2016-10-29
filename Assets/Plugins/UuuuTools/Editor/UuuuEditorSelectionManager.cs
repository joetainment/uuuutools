#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

// to get them back, use: 
// EditorUtility.InstanceIDToObject( id_ )


public class UuuuEditorSelectionManager {

	// Non Static

	protected bool				_isSelectionTooBigToTrack = false;
	public bool 				isSelectionTooBigToTrack {
										get { return _isSelectionTooBigToTrack; }
										set { _isSelectionTooBigToTrack = value; }
								}

	protected List<int> 		_selectedIds = new List<int>();
	public List<int> 			selectedIds
									{ get { return _selectedIds; } }

	protected List<GameObject> 	_selectedGameObjects = new List<GameObject>();
	public List<GameObject> 	selectedGameObjects
									{ get { return _selectedGameObjects; } }

	protected List<Transform> 	_selectedTransforms = new List<Transform>();
	public List<Transform> 		selectedTransforms
									{ get { return _selectedTransforms; } }

	public bool dirty = false;


	public void
	OnSelectionChange( ){
		dirty = true;
		if ( ! UuuuEditorSettings.IsIgnoreUuuuTests) Debug.Log( "onSelectionChangeWasCalled!" );
		ProcessSelectionChange();
	}

	public void
	Update( ){
		ProcessSelectionChange();
		dirty = false;
	}


	public void
	ProcessSelectionChange(){


		int[] ids_ = Selection.instanceIDs;

		if (ids_.Length > UuuuEditorSettings.SelectionLengthMax ){
			selectedIds.Clear();
			selectedTransforms.Clear();
			selectedGameObjects.Clear();
			isSelectionTooBigToTrack = true;
			return;
		}

		
		else {
			isSelectionTooBigToTrack = false;

			//var idsToRemove_ = new List<int>();

			// Make sure the anything in the old selection order
			// that isn't in the new selection order gets removed
			// from the ordered selection (selectedIds)
			for ( int i = selectedIds.Count - 1; i >= 0 ; i -= 1 ){
				if (    -1 == Array.IndexOf( ids_, selectedIds[i]  )    ){
					selectedIds.RemoveAt( i );
				}
			}
			
			//// Add the ids_ of any newly selected things
			//// to our ordered selection list.
			//// only things all selected at the same time
			///  will happen, since this once once every selection
			int id_=0;
			for ( int i = 0 ;  i < ids_.Length ; i++ ){
				id_ = ids_[i];
				if (  !selectedIds.Contains( id_ )  ){
					selectedIds.Add( id_ );
				}
			}

			//// Go through all selectedIds and make a
			////  a list of the xforms it contains, in the selection order			
			selectedTransforms.Clear();
			Transform[] editorXforms_ = Selection.GetTransforms( SelectionMode.ExcludePrefab | SelectionMode.Editable );
			foreach( int gid_ in selectedIds ){
				
				//// Get the actual object from the id we have
				UnityEngine.Object o_;
				GameObject g_;
				o_ = EditorUtility.InstanceIDToObject( gid_ );
				g_ = o_ as GameObject;

				//// Check that the xform we got from the list
				////  is also in the editor's xform selection
				////  list (from the Selection class) otherwise
				////  we don't want it
				if (g_ != null ){
					//// If the xform is in Selection.transforms we add it
					////  but because our id list is sorted by selection order
					////   the added xforms will be too, better than 
					Transform xform_ = g_.transform;
					int indexOf_ = Array.IndexOf( editorXforms_, xform_ );
					bool contained_ = -1 != indexOf_;
					if ( contained_ ){
							selectedTransforms.Add( xform_ );
					}
				}
				//// Next line is old garbage notes for debugging...
				//  int gId_ = g_.GetInstanceID();	int xId_ = xform_.GetInstanceID();Debug.Log( gId_ );		Debug.Log( xId_ );		Debug.Log(  Array.IndexOf(editorXforms_, xId_ )  );				}				//Debug.Log( o_.GetType() ); 	Debug.Log( g_ );


			}

		
			//// Print out a bunch of debugging information...
			//// Print out a bunch of ids the show the selected objects
			//debugStr_ = "";
			//foreach( int idDebug_ in selectedIds ){
			//	debugStr_ += (idDebug_.ToString() + "  ");
			//}
			//Debug.Log( "Selected objects are:  " + debugStr_ );
			
			//// Print out a bunch of transforms
			//string debugStr_;
			//debugStr_ = "";
			//foreach( Transform xform_ in selectedTransforms ){
			//	debugStr_ += ( xform_.ToString() + "  ");
			//}
			//Debug.Log( "Selected transforms are:  " + debugStr_ );
		}		
		
		UuuuEditorApp.A.SetSelectionObjectsLengthFromLastUpdate( Selection.objects.Length );

		//Debug.Log( "selection processed!" );
		//Debug.Log( Selection.objects.Length );
		//Debug.Log( selectedTransforms.Count );
		          
	}
}


#endif