using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialView : MonoBehaviour {
	public Color a,b;
	public GameObject sphere;
	Image i;
	// Use this for initialization
	void Start () {
		i =gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		i.color = Color.Lerp (a, b, Mathf.PingPong (Time.time*2
			, 1));
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetKeyDown(KeyCode.UpArrow)) {
			sphere.GetComponent<BallController> ().enabled = true;
			gameObject.SetActive (false);

		}
	}
}
