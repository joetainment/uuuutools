using UnityEngine;
using System.Collections;



public class UuuuGobj
{
	//// Check to see whether the game object has has already been destroyed
	////   see the following link for a bit more explanation of why something like this is useful:
	//// 	http://answers.unity3d.com/questions/13840/how-to-detect-if-a-gameobject-has-been-destroyed.html
	/// 
	public static bool IsDestroyed( GameObject gobj_ ){
		return (    
			(  gobj_ == null  )
				&&
			(  !ReferenceEquals(gobj_ , null )  )
		); 
	}
}

