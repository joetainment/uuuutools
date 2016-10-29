using UnityEngine;
using System.Collections;

public class UuuuRaySensorTest01Scr : MonoBehaviour {

	public bool isDirectionInWorldSpace=false;
	public int rayCount = 10;
	public LayerMask maskForRaySensor;
	//protected RaySensor raySensor;
	protected UuuuRaySensor[] raySensors;




	// Use this for initialization
	void Awake () {
		
		raySensors = new UuuuRaySensor[rayCount];
		float x = 0;
		for (int i=0;i<raySensors.Length;i++){
			x = -0.5f;
			x += i/(float)(raySensors.Length-1);
			//x = x - 0.5f;
			//x = x * 0.1f;

			raySensors[i]=
				new UuuuRaySensor(
				new Vector3( x,-0.5f,0f ), //pos
				Vector3.down, //dir
				transform,
				999f, //distance
				999f, //distanceMax
				maskForRaySensor //layerMask
			);
			if (isDirectionInWorldSpace) raySensors[i].parentOfDir=null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0;i<raySensors.Length;i++){
			raySensors[i].Sense2D();
			raySensors[i].Draw();
		}
	}
}


