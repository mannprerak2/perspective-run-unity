using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePathCreator : MonoBehaviour {
	// only 2 possible turbs left or right...
	// u cannot go right/left more than 2 times and can
	public GameObject colliderbox,collectablecude;//colliderplacer is used to place both
	public Gradient[] colorgrad;
	float width;
	int points,rc,lc;
	LineRenderer lr;
	Vector3 currentpoint,prepoint,sufpoint;
	int[] dirint = new int[]{-1,1};
	// Use this for initialization
	void Start () {
		lc = 0;
		rc = 0;
		points = 100;
		lr = GetComponent<LineRenderer> ();
		if (PowerUpsStatics.bpActive)
			lr.startWidth = 2f;
		if (PlayerPrefs.HasKey ("cg"))
			lr.colorGradient = colorgrad [PlayerPrefs.GetInt ("cg")]; // set cg in the player pref through designs menu
		// the default set is red white
		width = lr.startWidth;
		CreateLine ();

	}

	void CreateLine(){
		currentpoint = new Vector3 (0, 3, 0);
		prepoint = new Vector3 (0, 0, 0);
		// line creator loop...
		// begginer ppositions so that llevel start is same
		lr.SetPosition(0,prepoint);
		lr.SetPosition (1, currentpoint);

		for (int i = 2; i < points; i++) {
			ColliderPlacer ();
			Vector3 pos = Turner (RandomDirectionChooser ());
			lr.SetPosition (i,pos );
			PastPointChanger ();
		}

	}

	void ColliderPlacer(){
		Vector3 colliderPos = (currentpoint + prepoint)*0.5f;
		Vector3 diff = currentpoint - prepoint;
		float mag = (currentpoint - prepoint).magnitude;
		GameObject cd = Instantiate(colliderbox,colliderPos,Quaternion.identity);
		if (diff.x > 1 || diff.x < -1)
			cd.transform.localScale = new Vector3 (mag +1f, width, 1);
		else
			cd.transform.localScale = new Vector3 (width, mag +1f, 1);
			
		//placing collectable
		Instantiate(collectablecude,colliderPos + new Vector3(0,0,-0.7f),Quaternion.identity);

	}
	int RandomScale(){
		// gives length of path
		// minimumk length should be more than half of max length
		int x = Random.Range (3, 7);
		return x;
	}
	void PastPointChanger(){
		prepoint = currentpoint;
		currentpoint = sufpoint;
	}
	Vector3 Turner(int movedir){
		Vector3 pd = (currentpoint - prepoint);
		Vector3 newcurrentpoint;
		if (pd.x > 1) {
			newcurrentpoint = currentpoint + new Vector3 (0, movedir * RandomScale (), 0);
		} else if (pd.x < -1) {

			newcurrentpoint = currentpoint + new Vector3 (0, -1 * movedir * RandomScale (), 0);

		} else if (pd.y > 1) {

			newcurrentpoint = currentpoint + new Vector3 (-1 * movedir * RandomScale (), 0, 0);

		} else if (pd.y < -1) {

			newcurrentpoint = currentpoint + new Vector3 (movedir * RandomScale (), 0, 0);
		} else {
			newcurrentpoint = new Vector3 (0, 0, 0);// just for error
		}

		sufpoint = newcurrentpoint;

		return newcurrentpoint;

	}
	int RandomDirectionChooser(){
		int dirc = dirint[Random.Range (0,2)];
		if (dirc == (int)Dir.left) {
			lc++;
			rc = 0;
				
		} else { // dirc is 1 else
			rc++;
			lc = 0;
		}
		if (lc > 2) {
			dirc = (int)Dir.right;
			rc++;
			lc = 0;
		} else if (rc > 2) {
			dirc = (int)Dir.left;
			lc++;
			rc = 0;
		}
		return dirc; 
	}
	// Update is called once per frame
	void Update () {
		
	}
	enum Dir{
		right = -1,
		left = 1
	}
}
