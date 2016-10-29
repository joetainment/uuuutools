#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;


public class UuuuEditorAssetPostprocessorFor3dFbx : AssetPostprocessor {
	
	public void OnPreprocessModel()
	{
		
		//// Check if processing is disabled, and bail early if so!
		
		if (UuuuEditorSettings.IsAssetProcessingEnabled == false){
			return;
		}
		
		////  **** These prefs really should not be hardcoded!!!!
		////    instead there should be a Editor Prefs key or something
		////    also, each model should get checked to see if it's prefs have already
		////    been autoadjusted, and if not at the auto state, that change should stay!
		
		
		////    Get the assetImporter, which is a member of the AssetPostprocessorBaseClass
		////	we try getting it as a ModelImporter, to be sure it's a model we're importing, not an image
		ModelImporter importer_ = assetImporter as ModelImporter;
		if (importer_==null)  return;  // Bail early!
		
		//// We completely ignore the importer if it wasn't a model importer
		if ( importer_!= null ){
			
			//// Check if it is an fbx file, and if so, process the fbx
			////  use to lower to we don't have to worry about case sensivitity
			
			bool isFbx_ = UuuuEditorUtils.IsFbx( importer_ );
			
			if ( isFbx_ == true ){
				_Preprocess3dFbx(importer_ );
			}
		}
		
		
		
		AssetDatabase.Refresh();  //// Commit and make changes visible in the UI
		Debug.Log( "UuuuTools processed an asset using Unity's OnPreprocessModel." + "\n" + 
		          " If this is unwanted, please turn off asset processing in the UuuuTools window.");
	}
	
	
	
	protected void _Preprocess3dFbx( ModelImporter importer_ ){
		if (UuuuEditorSettings.IsProcessFixesDefaultScale==true){	
			importer_.globalScale = 1;
		}
		if (UuuuEditorSettings.IsProcessFixesDefaultNormalsAndTangents==true){	
			importer_.normalSmoothingAngle = 180;
			importer_.importNormals = ModelImporterNormals.Import;
			importer_.importTangents = ModelImporterTangents.CalculateMikk;
			
			importer_.importMaterials = true;
			importer_.materialName = ModelImporterMaterialName.BasedOnMaterialName;
			importer_.materialSearch = ModelImporterMaterialSearch.RecursiveUp;
		}
		/*
		string templatePath_ = "Plugins/UuuuTools/Editor";
		string templateFileNoPath_ = "UuuuTextAssetTemplate.txt";
		
		string rootPathWithoutAssetsPart_ = (Application.dataPath).Substring(0, Application.dataPath.Length - "Assets/".Length );

		Debug.Log( importer_.assetPath );
		Debug.Log( (Application.dataPath).Substring(0, Application.dataPath.Length - 7 )  );

		
		try {
			FileUtil.CopyFileOrDirectory(
				Application.dataPath + "/" + templatePath_ + "/" + templateFileNoPath_,
				rootPathWithoutAssetsPart_ + "/" + importer_.assetPath + ".uuuutools.settings.txt"
				);
		}
		catch( System.IO.IOException e ){
			//Debug.Log( "couldn't make new asset" );
		}

		//string textAssetFullPath_ = "Assets" + "/" + templatePath_ + "/" + "newTextAsset.txt";
		


		AssetDatabase.Refresh();

		string textAssetFullPath_ =  importer_.assetPath + ".uuuutools.settings.txt";

		Debug.Log( "textAssetFullPath_:  " + textAssetFullPath_ );
		
		TextAsset t_ =
			AssetDatabase.LoadAssetAtPath(
				textAssetFullPath_,
				typeof(TextAsset)
				)
				as TextAsset;
		
		Debug.Log( t_ );
		*/
		
		
		/*
		
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

		*/
		
		
		
		
		
		
		
		
		////   **** THIS PART CAN'T DO WHAT WE WANT YET
		////    CAUSES ERRORS, I SUSPECT CREATE ASSET SIMPLE CAN"T BE USED IN PREPROCESS FUNCTIONS 
		//string pathForAssetData_ = importer_.assetPath.Replace( ".fbx", ".txt" ); //".UuuuToolsAssetData.txt";
		//TextAsset foundTextAsset_ = AssetDatabase.LoadAssetAtPath( pathForAssetData_, typeof(TextAsset) ) as TextAsset;
		//if (foundTextAsset_==null){
		//	Debug.Log( "was null" );
		//	TextAsset textAsset_ = new TextAsset();
		//	Debug.Log( pathForAssetData_ );
		
		//   **** THIS PART CAUSES ERRORS, I SUSPECT CREATE ASSET SIMPLE CAN"T BE USED IN PREPROCESS FUNCTIONS
		//	EditorPrefs.SetString( "UuuuToolsFbxProcessorTextAssetToCreate", pathForAssetData_ );
		//AssetDatabase.CreateAsset( new TextAsset(), pathForAssetData_ );
		//}
		
		
		//string guid_ = AssetDatabase.AssetPathToGUID( importer_.assetPath );
		//EditorPrefs.SetKey
	}

    public void OnPostprocessModel( GameObject gobj ) {

		//// Check if processing is disabled, and bail early if so!
		if (	
				UuuuEditorSettings.IsAssetProcessingEnabled == false
				||
		    	UuuuEditorSettings.IsProcessUcx == false
			){
			return;
		}


		
		//string pathForAssetData_ = EditorPrefs.GetString( "UuuuToolsFbxProcessorTextAssetToCreate");
		
		//Debug.Log( "Postprocessor:  " + pathForAssetData_ );

		//// Get the path and name of the asset we are working with,
		//// also get a version that isn't case sensitive
		//// and check if the extention is case insensitive ".fbx"
		ModelImporter importer_ = this.assetImporter as ModelImporter;
		if (importer_==null)  return;  // Bail early!


		////  If this is an FBX file, apply the changes we want!
		if (  UuuuEditorUtils.IsFbx( importer_ ) ) {

			/* This small commented section has been fixed
				////    not done in the preprocess, so we're doing them here in postprocess
				UuuuEditorUtils.FixImporterDefaultMaterials( importer_ );
				UuuuEditorUtils.FixImporterDefaultNormalsAndTangents( importer_ );
			*/

			////  Apply the addColliders function
			////    this should make physics colliders, remove rendering components
			////    and add physics materials based on the names of objects.
			////    Do not be case sensitive!			
			_AddColliders(gobj.transform, importer_.assetPath );
		}
		
		//// Commit and make changes visible in the UI
		AssetDatabase.Refresh();
		Debug.Log( "UuuuTools processed an asset using Unity's OnPostprocessModel." + "\n" + 
		          " If this is unwanted, please turn off asset processing in the UuuuTools window.");
    }

    protected void _AddColliders(Transform xform_, string pathAndName_ ) {
		//Debug.Log( "Found object named: " + xform_.name );
		string xName_ = xform_.name.ToLower();
		bool isUcx_ = xName_.StartsWith("ucx_");
		bool isUcv_ = xName_.StartsWith("ucv_");
		
        if ( xform_.name.ToLower().StartsWith("ucx_")  ||  xform_.name.ToLower().StartsWith("ucv_") ){ //// use to lower to avoid case sensitivity
            MeshCollider mcol = xform_.gameObject.AddComponent<MeshCollider>();
			
			if (isUcx_)  mcol.convex = true;
			else if (isUcv_) mcol.convex = false;
			
			foreach (MeshRenderer m_ in xform_.gameObject.GetComponents<MeshRenderer>() ){
				_DestroyImmediate(m_);
            }
            foreach (MeshFilter m_ in xform_.gameObject.GetComponents<MeshFilter>()){
                _DestroyImmediate(m_);
            }
			
			//// If the UCX object found has any children, then they might be objects
			//// put in and named to specify physmats.
			//// Search for them and apply if required
			//// also remove objects that are physmats but are otherwise unneeded
			foreach (Transform child_ in xform_){
				PhysicMaterial physmat_;
				
				//pathOfNewAsset_ = AssetDatabase.GetAssetPath( )
				
				string name_ = child_.name;
				
				string[] dirs_ = pathAndName_.Split('/');
				string dir_ = "";
				string sep_ = "";
				
				//Debug.Log( "Finding and applying physics materials..." );
				
				for ( int i_=0; i_ < dirs_.Length - 1; i_++ ){   //// minue one because we don't want the filename!
					if (i_==0 )   sep_="";
					else  sep_="/";
					dir_ = dir_ + sep_ + dirs_[i_];
					
					//string subPath = "/Physmats/" + name_ + ".physicMaterial";
					
					string pName_ = dir_  + "/Physmats/" + name_ + ".physicMaterial";
					
					physmat_ = AssetDatabase.LoadMainAssetAtPath(
						pName_
					) as PhysicMaterial;
					
					////  If the physmat isn't null and this point, then the name matches the physmat
					////  so we can go ahead and apply the physmat
					if (physmat_!= null){
						try {
							mcol.GetComponent<Collider>().sharedMaterial = physmat_;
						}
						catch(System.Exception e){
							Debug.Log(e);
						}
						
						//Debug.Log(  child_.gameObject.GetComponents<Component>().Length  );
						//// Delete physmat only objects
						//// (only in the above if block where we've found the physmat!)
						//// Check to see if the object has any components or children
						//// other than it's own transform component.
						//// If it doesn't have any, then it's useless and we get rid of it!
						//// Note that this only gets rid of physmat objects that matched
						//// known physics materials, and won't get rid of other random nulls.
						//// This is good!
						if  (   child_.gameObject.GetComponents<Component>().Length<=1  && child_.childCount==0 ){
								_DestroyImmediate(child_.gameObject);
						}
					}
					
				}
				
			}	
			
		}  //// end of the "if is ucx or if is ucv" block!
		
		//// Recurse through any additional children, regardless of whether or not they are UCX or UCV
        foreach (Transform child_ in xform_){
			_AddColliders(child_, pathAndName_);
		}
	}
    
	/*
    public void _destroyImmediate( ArrayList list_ ){
        for (int i_=list_.Count; i_>0; i_--){
            Object obj_ = list_[i_] as Object;
            if (obj_) _destroyImmediate( obj_ );
            list_.RemoveAt(i_);
        }
    }
    */
    
    
	public void _DestroyImmediate( Object obj_ ){
		Object.DestroyImmediate(obj_, true);
	}
}
#endif







/*
		string pathAndName_ = importer_.assetPath;
		string lowerPathAndName_ = pathAndName_.ToLower();
		int lowerPathAndNameLen_ = lowerPathAndName_.Length;
		string fbxExt_ = ".fbx";
		int fbxExtLen_ = fbxExt_.Length;
		string ext_ = lowerPathAndName_.Substring(
					lowerPathAndNameLen_ - fbxExtLen_,
					fbxExtLen_
		);
				//Debug.Log( "pathAndName and is:");
				//Debug.Log( pathAndName_ );
				
*/