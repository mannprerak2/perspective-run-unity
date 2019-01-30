using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itweentesting : MonoBehaviour {
	Hashtable argu;
	// Use this for initialization
	void Start () {
		
		//changes color to a value in given time
		//iTween.ColorTo (gameObject, new Color (0, 0, 1, 1), 3f);

		// do for all to avoid errors
		iTween.Init(gameObject);
		//look at particular direction
		//iTween.PunchPosition(gameObject,new Vector3(5f,0,0),15f);
		//iTween.PunchScale(gameObject,Vector3.one*2,2f);
		//iTween.ShakePosition(gameObject,Vector3.one*0.2f,10f);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
