using UnityEngine;
using System;
using System.Collections;

// A Utility class for helping with matrix math

public class UuuuMatrix {

	
	public static void
	SetLocalXformFromMatrix4x4( Transform xform_, Matrix4x4 matrix_ ){
		xform_.localScale = GetScaleFromMatrix4x4( matrix_ );
		xform_.localRotation = GetRotationFromMatrix4x4( matrix_ );
		xform_.localPosition = GetPositionFromMatrix4x4( matrix_ );
	}

	// SetWorldXformFromMatrix4x4(

	// TRS/PRS  getters
	public static Vector3
	GetPositionFromMatrix4x4( Matrix4x4 matrix){
		var x = matrix.m03;
		var y = matrix.m13;
		var z = matrix.m23;
		
		return new Vector3(x, y, z);
	}

	public static Quaternion
	GetRotationFromMatrix4x4( Matrix4x4 matrix_){
		var qw = Mathf.Sqrt(1f + matrix_.m00 + matrix_.m11 + matrix_.m22) / 2;
		var w = 4 * qw;
		var qx = (matrix_.m21 - matrix_.m12) / w;
		var qy = (matrix_.m02 - matrix_.m20) / w;
		var qz = (matrix_.m10 - matrix_.m01) / w;
		
		return new Quaternion(qx, qy, qz, qw);
	}
	
	public static Vector3
	GetScaleFromMatrix4x4( Matrix4x4 m_){  //// m_ because matrix__ would be too long to type!
		var x_ = Mathf.Sqrt(m_.m00 * m_.m00 + m_.m01 * m_.m01 + m_.m02 * m_.m02);
		var y_ = Mathf.Sqrt(m_.m10 * m_.m10 + m_.m11 * m_.m11 + m_.m12 * m_.m12);
		var z_ = Mathf.Sqrt(m_.m20 * m_.m20 + m_.m21 * m_.m21 + m_.m22 * m_.m22);

		return new Vector3(x_, y_, z_);
	}

	// Potential future work...
	//
	// This get's the world space matrix from an xform:
	// xform_.localToWorldMatrix
	// 
	//
	//This would calculate and get the local transformation matrix:
	//(relative to parent, what it would be if parent was reset xfrorm to origin in world)
	//from http://answers.unity3d.com/questions/156698/copy-a-transform.html
	//worldToLocalMatrix  *  localToWorldMatrix


}
