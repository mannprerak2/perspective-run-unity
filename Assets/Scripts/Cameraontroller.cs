using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cameraontroller : MonoBehaviour {
	public GameObject sphere,nightMode,rainymode,frozenMode;
	public Text ModeGameText;
	public static int CrossCameraRot,randomCamerarot,nightModeGM,rainyModeGM,frozenModeGM;
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, 0, 30f);
		if (CrossCameraRot != 1) {
			CrossCameraRot = 0;
			ModeGameText.text = "classic mode";
		}
		if (nightModeGM == 1) {
			nightMode.SetActive (true);
			ModeGameText.text = "night mode";
		}
		if (rainyModeGM == 1) {
			rainymode.SetActive (true);
			ModeGameText.text = "rain storm";
		}
		if (frozenModeGM == 1) {
			frozenMode.SetActive (true);
			frozenMode.GetComponent<RainCameraController> ().Play ();
			ModeGameText.text = "snow blind";
		}
		if(randomCamerarot!=0)
			ModeGameText.text = "camera fun";
		
		gameObject.transform.rotation = new Quaternion (0, 0,CrossCameraRot*0.5f , 1);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(sphere.transform.position.x,sphere.transform.position.y,-10f);

	}
}
