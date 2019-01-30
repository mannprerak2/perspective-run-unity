using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class powerManager : MonoBehaviour {
	public GameObject speedControlButton,DoubleCubebutton,BigPathButton;
	// Use this for initialization
	int s,b,d;
	void Start () {
		TOP:
		if (PlayerPrefs.HasKey ("scp")) {
			speedControlButton.GetComponentInChildren<Text> ().text = PlayerPrefs.GetInt ("scp").ToString ()+"left";
			s = PlayerPrefs.GetInt ("scp") ;
		}
		if (PlayerPrefs.HasKey ("bpp")) {
			BigPathButton.GetComponentInChildren<Text> ().text = PlayerPrefs.GetInt ("bpp").ToString ()+"left";
			b = PlayerPrefs.GetInt ("bpp") ;
		}
		if (PlayerPrefs.HasKey ("dcp")) {
			DoubleCubebutton.GetComponentInChildren<Text> ().text = PlayerPrefs.GetInt ("dcp").ToString () + "left";
			d = PlayerPrefs.GetInt ("dcp");
		} else {
			PlayerPrefs.SetInt ("scp", 1);
			PlayerPrefs.SetInt ("bpp", 1);
			PlayerPrefs.SetInt ("dcp", 1); // for first time run 
			goto TOP;
		}
	}

	public void MenuBeforeStart(){
		PlayerPrefs.SetInt ("scp", s);
		PlayerPrefs.SetInt ("bpp", b);
		PlayerPrefs.SetInt ("dcp", d);
		PowerUpsStatics.ResetPowers ();
		SceneManager.LoadSceneAsync (0);
	}

}
