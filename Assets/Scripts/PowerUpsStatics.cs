using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsStatics : MonoBehaviour {

	public static float width=2f,cubeValue=2f,speedadder=0.05f;
	public static bool scActive=false,dcActive=false,bpActive=false;
	// make these bools true to use powerup now...

	public static void ResetPowers(){
		scActive = false;
		dcActive = false;
		bpActive = false;
	}
}
