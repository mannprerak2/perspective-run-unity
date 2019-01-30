using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CubeUpdator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("cube"))
			gameObject.GetComponent<Text> ().text = PlayerPrefs.GetInt ("cube").ToString ();
		else {
			PlayerPrefs.SetInt ("cube", 100);
			gameObject.GetComponent<Text> ().text = "100";

		}//wont be actually used but still just in case
		
	}

}
