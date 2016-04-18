using UnityEngine;
using System.Collections;

// This is a Utility class to help with editing and storing transformations
//  it isn't meant to operate directly on xforms most of the time
//  those functions are mostly in UuuuXform, not here.

public class UuuuUxform {
	// //////////////////////////////////
	// Static Methods and Members	
	
	public static bool
	SetBySrc( UuuuUxform jxform_, Transform src_ ){
		if ( src_!=null &&  jxform_!=null ){
			SetBySrcWithoutNullCheck( jxform_, src_);
			jxform_.lastRefreshOk = true;
			return true;
		}
		else {
			jxform_.lastRefreshOk = false;
			return false;
		}
	}
	
	public static void
	SetBySrcWithoutNullCheck( UuuuUxform uxform_, Transform src_ ){
		// //  This will intentionally fail if either is null, that's good
		uxform_.localPosition = src_.localPosition;
		uxform_.localRotation = src_.localRotation;
		uxform_.localScale = src_.localScale;
		uxform_.localMatrix = src_.worldToLocalMatrix * src_.localToWorldMatrix;
		
		uxform_.worldPosition = src_.position;
		uxform_.worldRotation = src_.rotation;
		uxform_.worldScale = src_.lossyScale;
		uxform_.worldMatrix = src_.localToWorldMatrix;
	}
	
	// //////////////////////////////////
	// Instance Methods and Members
	
	public Transform			src;
	
	//// these local values are all relative to the parent space
	public Vector3 			localPosition;
	public Quaternion 		localRotation;
	public Vector3 			localScale;
	public Matrix4x4 		localMatrix;
	
	public Vector3 			worldPosition;
	public Quaternion 		worldRotation;
	public Vector3 			worldScale;
	public Matrix4x4		worldMatrix;
	
	public bool				lastRefreshOk;
	
	
	// Constructor
	public
	UuuuUxform( Transform xform_ ){
		setByXform( xform_ );
	}
	
	
	public bool
	refreshFromSrc( ){
		return SetBySrc( this, src );
	}
	
	public bool
	setByXform( Transform xform_ ){
		src = xform_;
		return refreshFromSrc();
	}
	
	
	//public 
	//setByMatrix
	
}
