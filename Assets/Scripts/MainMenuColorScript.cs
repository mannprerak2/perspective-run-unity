using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuColorScript : MonoBehaviour {
	public Gradient[] colorgrad;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("cg"))
			gameObject.GetComponent<LineRenderer>().colorGradient = colorgrad [PlayerPrefs.GetInt ("cg")];

		if (!PlayerPrefs.HasKey ("cube"))
			PlayerPrefs.SetInt ("cube", 15000);
	}

}
