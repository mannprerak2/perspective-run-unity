using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
	int[] pm =new int[]{-1,1};
	int a;
	void Start(){
		a = pm[Random.Range (0, 2)];
	}

	void Update(){
		gameObject.transform.Rotate (0, 0, Random.Range (2f,5f)* a);

	}

}
