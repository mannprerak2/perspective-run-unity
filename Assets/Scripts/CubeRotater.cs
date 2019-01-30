using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotater : MonoBehaviour {
	public Color a,b;
	Renderer rd;
	// Use this for initialization
	void Start () {
		rd = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		rd.material.color = Color.Lerp (a, b, Mathf.PingPong (Time.time *3f, 1));
		gameObject.transform.Rotate (new Vector3 (3,4,1));
	}
}
