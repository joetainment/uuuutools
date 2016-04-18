#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;




public class UuuuEditorUtils : MonoBehaviour {


	public class UuuuEditorXform {
		public Vector3 		position = Vector3.zero;
		public Quaternion	rotation = Quaternion.identity;
		public Vector3 		scale = Vector3.one;
		public Transform	src = null;
		
		public UuuuEditorXform(){
			
		}
		public UuuuEditorXform( Transform xform_, bool isWorldSpace_ ){
			if (isWorldSpace_){
				//position = xform_.position;
				//position = xform_.local;
				//position = xform_..xform_.position;
			}
			
		}
	}
	
	public static List<UuuuEditorXform>		XformsLocal = new List<UuuuEditorXform>();
	public static List<UuuuEditorXform>		XformsWorld = new List<UuuuEditorXform>();

	public static void
	SetStoredXform(  List<UuuuEditorXform> xforms_ ){
		XformsLocal.Clear();
		XformsWorld.Clear();
	}









	public static bool IsFbx(  ModelImporter importer_  ){

		string name_ = importer_.assetPath;
		string nameLower_ = name_.ToLower();


		string ext_ = ".fbx";
		int eLen_ = ext_.Length;

		//Debug.Log(  ext_ + "   " + eLen_.ToString()   );
		

		string testStr_ = nameLower_.Substring( nameLower_.Length - eLen_, eLen_ );
		//Debug.Log( testStr_ );

		if (  testStr_ ==ext_ ){
			return true;
		}

		return false;
	}


	/*
	// // These are not used and kept mostly for reference

	public static void
	FixImporterDefaultScaleTo( ModelImporter importer_ ){
		importer_.globalScale = 1;		
	}
	
	public static void
	FixImporterDefaultNormalsAndTangents( ModelImporter importer_ ){
		//// Unity by default has stupid default settings for the normals
		////   and tangents of imported objects.  Fix this, to use imported
		////   normals and tangents calculated the way Unity does it, which
		////   our normal map baking software can be matched to.
		importer_.normalSmoothingAngle = 180;
		importer_.normalImportMode = ModelImporterTangentSpaceMode.Import;
		importer_.tangentImportMode = ModelImporterTangentSpaceMode.Calculate;
	}

	public static void
	FixImporterDefaultMaterials( ModelImporter importer_ ){
		//// Fix the material settings which aren't very good by default
		importer_.importMaterials = true;
		importer_.materialName = ModelImporterMaterialName.BasedOnMaterialName;
		importer_.materialSearch = ModelImporterMaterialSearch.RecursiveUp;
	}
	*/


	public static void
	LoopXforms(){}





/*
	function GetParentScale(): Vector3 {
		var sf: Vector3 = Vector3.one;
		
		var parentTransform: Transform = null;
		if (thisTransform.parent) parentTransform = thisTransform.parent;
		
		while (parentTransform) {
			sf.x *= 1.0f / parentTransform.localScale.x;
			sf.y *= 1.0f / parentTransform.localScale.y;
			sf.z *= 1.0f / parentTransform.localScale.z;
			if (parentTransform.parent) {
				parentTransform = parentTransform.parent;
			} else {
				parentTransform = null;
			}
		}
		return sf;
	}
*/
	
	
	
	
	
	
	
	
	
	
	/*
		ModelImporter importer_ = assetImporter as ModelImporter;
        string name_ = importer_.assetPath.ToLower();
		if (name_.ToLower().Substring(name_.Length - 4, 4)==".fbx") {
			importer_.globalScale = 1;
		}
		AssetDatabase.Refresh();  //// Commit and make changes visible in the UI
*/



}


#endif