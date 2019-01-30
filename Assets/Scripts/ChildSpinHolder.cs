﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpinHolder : MonoBehaviour {
	Quaternion rotation;
	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = rotation;
	}

}
