using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//// UuuuXform often referred to as jxform
////		the refresh stuff returns a bool, in order to return false
//// 	if null refs found
public class UuuuXform {

	
	// //////////////////////////////////
	// Static Methods and Variables
	

	//;// Position Resets and Sets
	static public void
	ResetPositionWorldSpace( Transform[] xforms_){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			ResetPositionWorldSpace( xforms_[i_] );
		}
	}
	static public void
	ResetPositionWorldSpace( Transform xform_ ){
		SetPositionWorldSpace( xform_, Vector3.zero );
	}
	
	static public void
	ResetPositionLocalSpace( Transform[] xforms_){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			ResetPositionLocalSpace( xforms_[i_] );
		}
	}
	static public void
	ResetPositionLocalSpace( Transform xform_ ){
		xform_.localPosition = Vector3.zero;
	}
	
	static public void
	SetPositionWorldSpace( Transform[] xforms_, Vector3 position_){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			SetPositionWorldSpace( xforms_[i_], position_ );
		}
	}
	static public void
	SetPositionWorldSpace( Transform xform_, Vector3 position_ ){
		xform_.position = position_;
	}
	static public void
	SetPositionLocalSpace( Transform[] xforms_, Vector3 position_){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			SetPositionLocalSpace( xforms_[i_], position_ );
		}
	}
	static public void
	SetPositionLocalSpace( Transform xform_, Vector3 position_ ){
		xform_.localPosition = position_;
	}

	
	


	//;// Rotation Resets and Sets	
	static public void
	ResetRotationWorldSpace( Transform[] xforms_ ){
		SetRotationWorldSpace( xforms_, Quaternion.identity );
	}	
	static public void
	ResetRotationWorldSpace( Transform xform_ ){
		SetRotationWorldSpace( xform_, Quaternion.identity );
	}
	
	static public void
	ResetRotationLocalSpace( Transform[] xforms_ ){
		SetRotationLocalSpace( xforms_, Quaternion.identity );
	}
	
	static public void
	ResetRotationLocalSpace( Transform xform_ ){
		SetRotationLocalSpace( xform_, Quaternion.identity );
	}
	
	
	static public void
	SetRotationWorldSpace( Transform[] xforms_, Quaternion rotation_ ){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			SetRotationWorldSpace( xforms_[i_], rotation_ );
		}
	}
	static public void
	SetRotationWorldSpace( Transform xform_, Quaternion rotation_ ){
		xform_.rotation = rotation_;
	}
	
	static public void
	SetRotationLocalSpace( Transform[] xforms_, Quaternion rotation_ ){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			SetRotationLocalSpace( xforms_[i_], rotation_ );
		}
	}
	static public void
	SetRotationLocalSpace( Transform xform_, Quaternion rotation_ ){
		xform_.localRotation = rotation_;
	}
	
	
	
	//;// Scale Resets and Sets
	static public void
	ResetScaleWorldSpace( Transform[] xforms_ ){
		SetScaleWorldSpace( xforms_, Vector3.one );
	}
	static public void
	ResetScaleWorldSpace( Transform xform_ ){
		SetScaleWorldSpace( xform_, Vector3.one );
	}

	static public void
	ResetScaleLocalSpace( Transform[] xforms_ ){
		SetScaleLocalSpace( xforms_, Vector3.one );
	}
	static public void
	ResetScaleLocalSpace( Transform xform_ ){
		SetScaleLocalSpace( xform_, Vector3.one );
	}
	
	
	static public void
	SetScaleWorldSpace( Transform[] xforms_, Vector3 scale_ ){
		int l_ = xforms_.Length;
		for (int i_=0;i_ < l_;i_++){
			SetScaleWorldSpace( xforms_[i_], scale_ );
		}
	}	
	static public void
	SetScaleWorldSpace( Transform xform_, Vector3 scale_ ){
		Transform p_ = xform_.parent;
		xform_.parent = null;
		xform_.localScale = scale_;
		xform_.parent = p_;
	}
	
	static public void
	SetScaleLocalSpace( Transform[] xforms_, Vector3 scale_ ){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			SetScaleLocalSpace( xforms_[i_], scale_ );
		}
	}
	static public void
	SetScaleLocalSpace( Transform xform_, Vector3 scale_ ){
		xform_.localScale = scale_;
	}
	
	
	


	//;// Transform (all TRS) Resets and Sets
	static public void
	ResetXformWorldSpace( Transform[] xforms_ ){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			ResetXformWorldSpace(xforms_[i_]); 
		}
	}
	static public void
	ResetXformWorldSpace( Transform xform_ ){
		xform_.position = Vector3.zero;
		xform_.rotation = Quaternion.identity;
		xform_.localScale = Vector3.one;
	}
	

	static public void
	ResetXformLocalSpace( Transform[] xforms_ ){
		int l_ = xforms_.Length;
		for (int i_=0;i_<l_;i_++){
			ResetXformLocalSpace(xforms_[i_]);
		}	
	}
	static public void
	ResetXformLocalSpace( Transform xform_ ){
		xform_.localPosition = Vector3.zero;
		xform_.localRotation = Quaternion.identity;
		xform_.localScale = Vector3.one;
	}




	
	public HashSet<Transform>
	GetXformAndChildrenRecursive( Transform[] xforms_){
		HashSet<Transform> xformsResult_ = new HashSet<Transform>();
		return GetXformAndChildrenRecursive( xforms_, xformsResult_ );
	}
	public HashSet<Transform>
	GetXformAndChildrenRecursive( Transform xform_){
		HashSet<Transform> xformsResult_ = new HashSet<Transform>();
		return GetXformAndChildrenRecursive( xform_, xformsResult_ );
	}
	public HashSet<Transform>
	GetXformAndChildrenRecursive( Transform[] xforms_, HashSet<Transform> xformsResult_ ){
		int l_ = xforms_.Length; // to be checked by loop
		Transform xform_; // to be used in loop
		
		for (int i_=0;i_ < l_; i_++){
			xform_ = xforms_[i_];
			xformsResult_ = GetXformAndChildrenRecursive( xform_.GetChild(i_), xformsResult_ );
		}
		return xformsResult_;
	}

	public HashSet<Transform>
	GetXformAndChildrenRecursive( Transform xform_, HashSet<Transform> xformsResult_ ){
		int childCount_ = xform_.childCount;
		if (xform_.childCount==0){
			xformsResult_.Add( xform_ );
		}
		else {
			for (int i_=0; i_ < childCount_ ; i_++){
				xformsResult_ = GetXformAndChildrenRecursive( xform_.GetChild(i_), xformsResult_ );
			}
		}
		xformsResult_.Add( xform_ );
		return xformsResult_;
	}

}
