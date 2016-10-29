using UnityEngine;
using System;
using System.Collections;


public class UuuuRaySensor {
	// public fields and methods
	public Vector3 pos;
	public Vector3 dir;
	public float distance;
	public float distanceMax;
	public LayerMask layerMask;
	public RaycastHit2D hit2D;
	public float 	hitTimeLast2D;
	public Transform parent;
	public Transform parentOfDir;


	public Vector3
	dirAbs { get {
		if (parentOfDir==null) return dir;
		else return parentOfDir.TransformVector( dir );
	}}
	public Vector3
	posAbs { get {
		if (parent==null) return pos;
		else return parent.TransformPoint( pos );
	}}
	public Vector2
	pos2D { get {
			return (Vector2)pos;
	}}
	public Vector2
	dir2D { get {
			return (Vector2)dir;
	}}
	public Vector2
	posAbs2D { get {
			return (Vector2)posAbs;
	}}
	public Vector2
	dirAbs2D { get {
			return (Vector2)dirAbs;
	}}
	public bool
	isHit2D { get {
		if (hit2D.collider!=null) return true;
		else return false;
	}}



	//####  Methods ######################################

	public
	UuuuRaySensor( Vector2 pos_, Vector2 dir_, Transform parent_, float distance_, float distanceMax_, LayerMask layerMask_ ){
		pos = pos_;
		dir = dir_;
		distance = distance_;
		distanceMax = distanceMax_;
		parent = parent_;
		layerMask = layerMask_;
		parentOfDir = parent_;
	}

	public void
	Update2D(){
		Sense2D();
	}
	//public void
	//Update3D(){
	//	Sense3D();
	//}
	public RaycastHit2D
	Sense2D( ){
		return this.Sense2D( distance );
	}
	public RaycastHit2D
	Sense2D( float distance_ ){
		if (distance_ > distanceMax )    distance_ = distanceMax;
		RaycastHit2D hit2D_ = Physics2D.Raycast( posAbs2D, dirAbs2D, distance_, layerMask );
		hit2D = hit2D_;
		if (isHit2D ) hitTimeLast2D = Time.time;
		return hit2D_;
	}

	public void
	Draw(){
		if (isHit2D){  // if nothing was hit, then it is null
			//Debug.Log( hit2D.point );
			Debug.DrawLine( posAbs, hit2D.point, Color.white, 0.01f );
			//Debug.DrawRay( posAbs, hit.point - posAbs2D, Color.white, 1.0f );
		}

	}

}



/*

public class RaySensorIni(){
public LayerMask lm_ground;
public float f_skinWidth = 0.03125f; //inverse power of 2
public int i_horizontalRayCount = 4;
public int i_verticalRayCount = 4;
[HideInInspector]
public float f_horizontalRaySpacing;
[HideInInspector]
public float f_verticalRaySpacing;
[HideInInspector]
public BoxCollider2D boxCollider;
public RaycastOrigins rayCastOrigins;

*/






/*


	public struct RaycastOrigins{
		public Vector2 v2_topLeft,v2_topRight;
		public Vector2 v2_bottomLeft,v2_bottomRight;
	}

	//// Member Fields and Methods
	public LayerMask 		layerMask;
	public float 			skinWidth = 0.03125f; //inverse power of 2
	public int 				rayCountX = 4;
	public int 				rayCountY = 4;
	public float 			raySpacingX = 99999F; //make huge since small could cause too many calculations if forgot to set
	public float 			raySpacingY = 99999F;
	public BoxCollider2D 	boxCollider;
	public RaycastOrigins 	rayCastOrigins;




	public void ini {
		set {
			init();
		}
	}

	public init(){
		if (boxCollider==null)  throw System.SystemException( "boxCollider can't be null at init, use ini to set" );
		if (boxCollider==null)  throw System.SystemException( "rayCastOrigins can't be null at init, use ini to set" );
		CalculateRaySpacing();
	}


	public virtual void Start(){
		CalculateRaySpacing();
	}

	public void UpdateRayCastOrigins() {
		Bounds bounds = boxCollider.bounds;
		bounds.Expand(f_skinWidth*-2);

		rayCastOrigins.v2_bottomLeft = new Vector2 (bounds.min.x,bounds.min.y);
		rayCastOrigins.v2_bottomRight = new Vector2 (bounds.max.x,bounds.min.y);
		rayCastOrigins.v2_topLeft = new Vector2 (bounds.min.x,bounds.max.y);
		rayCastOrigins.v2_topRight = new Vector2 (bounds.max.x,bounds.max.y);

	}
	public void CalculateRaySpacing( bounds ){
		Bounds bounds =
		bounds.Expand(f_skinWidth*-2);

		i_horizontalRayCount = Mathf.Clamp(i_horizontalRayCount,2,int.MaxValue);
		i_verticalRayCount = Mathf.Clamp(i_verticalRayCount,2,int.MaxValue);

		horizontalRaySpacing = bounds.size.y/(i_horizontalRayCount-1);
		verticalRaySpacing = bounds.size.x/(i_verticalRayCount-1);
	}




}




*/