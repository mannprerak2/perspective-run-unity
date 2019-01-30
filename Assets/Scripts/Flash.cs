using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {
	public Color[] clr;
	Color a;
	Color b = Color.clear;
	SpriteRenderer sp;
	float  c;
	// Use this for initialization
	void Start () {
		c = 0;
		a = clr [(int)Random.Range (0, 6)]; 
		sp=gameObject.GetComponent<SpriteRenderer> ();
		sp.color = a;
	}
	void OnEnable(){
		c = 0;
		a = clr [(int)Random.Range (0, 6)]; 
		sp=gameObject.GetComponent<SpriteRenderer> ();
		sp.color = a;
	}
	// Update is called once per frame
	void Update () {
		sp.color = Color.Lerp(a,b,Mathf.PingPong(c*0.1f,1));
		c = c + 0.05f;
		if (c > 10)
			gameObject.SetActive (false);
	}
}
