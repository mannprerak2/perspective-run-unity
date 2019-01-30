using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMode : MonoBehaviour {
	public GameObject sphere;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (0, 0, -3);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (sphere.transform.position.x, sphere.transform.position.y, -3);
	}
}
