using UnityEngine;
using System.Collections;

// Class adding extension methods to built in Unity types
//  This class shouldn't do anything other than call other functions

public static class UuuuUnityEx {

	// Transform extension methods
	public static void
	SetXformFromMatrix4x4(this Transform xform_, Matrix4x4 matrix_){
		UuuuMatrix.SetLocalXformFromMatrix4x4( xform_, matrix_ );
	}

	 
	
	public static void
	ResetPositionWorldSpace(this Transform xform_){
		UuuuXform.ResetPositionWorldSpace(xform_);
	}

	public static void
	ResetPositionLocalSpace(this Transform xform_){
		UuuuXform.ResetPositionLocalSpace(xform_);
	}

	public static void
	ResetRotationWorldSpace(this Transform xform_){
		UuuuXform.ResetRotationWorldSpace(xform_);
	}

	public static void
	ResetRotationLocalSpace(this Transform xform_){
		UuuuXform.ResetRotationLocalSpace(xform_);
	}

	public static void
	ResetScaleWorldSpace(this Transform xform_){
		UuuuXform.ResetScaleWorldSpace(xform_);
	}
	
	public static void
	ResetScaleLocalSpace(this Transform xform_){
		UuuuXform.ResetScaleLocalSpace(xform_);
	}

	public static void
	ResetXformWorldSpace(this Transform xform_){
		UuuuXform.ResetXformWorldSpace(xform_);
	}
	public static void
	ResetXformLocalSpace(this Transform xform_){
		UuuuXform.ResetXformLocalSpace(xform_);
	}


	
	
	public static void
	SetPositionWorldSpace(this Transform xform_, Vector3 scale_){
		UuuuXform.SetPositionWorldSpace(xform_, scale_);
	}
	public static void
	SetPositionLocalSpace(this Transform xform_, Vector3 scale_){
		UuuuXform.SetPositionLocalSpace(xform_, scale_);
	}
	
	public static void
	SetRotationWorldSpace(this Transform xform_, Quaternion rotation_){
		UuuuXform.SetRotationWorldSpace(xform_, rotation_);
	}
	public static void
	SetRotationLocalSpace(this Transform xform_, Quaternion rotation_){
		UuuuXform.SetRotationLocalSpace(xform_, rotation_);
	}
	
	public static void
	SetScaleWorldSpace(this Transform xform_, Vector3 scale_){
		UuuuXform.SetScaleWorldSpace(xform_, scale_);
	}
	public static void
	SetScaleLocalSpace(this Transform xform_, Vector3 scale_){
		UuuuXform.SetScaleLocalSpace(xform_, scale_);
	}






	// Matrix extension methods
	public static Quaternion
	GetRotation(this Matrix4x4 matrix_) {
		return UuuuMatrix.GetRotationFromMatrix4x4( matrix_ );
	}

	public static Vector3
	GetPosition(this Matrix4x4 matrix_) {
		return UuuuMatrix.GetPositionFromMatrix4x4( matrix_ );
	}

	public static Vector3
	GetScale(this Matrix4x4 matrix_){
		return UuuuMatrix.GetScaleFromMatrix4x4( matrix_ );
	}


}



