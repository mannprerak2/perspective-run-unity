using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BallController : MonoBehaviour {

	// Use this for initialization
	public GameObject pause,GameOverPanel,admanager,rankType;
	public Text ModeGameText;
	int rotangle;
	string[] scoretype = new string[]{"begginer","amateur","master","legendary","king","godlevel","god+1","god+2","god+3"};
	string[] tips = new string[]{"Try other GameModes for fun","Shop has many customizations","Buy PowerUps in Shop to get a higher score","The continue button looks mysterious..","Visit Daily to get better gifts","Floor designs can be bought from shop","Use cubes in Shop to unlock exciting prizes","Share Your score with friends"};
	public static int invertGM;// make this -1 to invert controls
	public Color a,b;
	public Sprite[] PlayerShape;
	Rigidbody rb;
	public float adder,cubevalue;
	float speed;
	float mid,l;
	int collectedint;
	public Vector2 speedvect,lastSpeed;
	Vector3 clockwise,anticlockwise,defaultrot,lastpos;
	public Text collected;
	void Start () {
		rotangle = (int)Camera.main.transform.rotation.z;
		if (invertGM ==0)
			invertGM = 1; // setting up invert controol game mode
		if (invertGM == -1)
			ModeGameText.text = "invert controls";
		lastpos = Vector3.zero;
		if (PowerUpsStatics.scActive)
			adder = PowerUpsStatics.speedadder;
		else
		adder = 0.1f;
		if (PowerUpsStatics.dcActive)
			cubevalue = 2f;
		else
			cubevalue = 1f;

		speed = 2.5f;

		if(PlayerPrefs.HasKey("cs"))
			gameObject.GetComponent<SpriteRenderer>().sprite = PlayerShape[PlayerPrefs.GetInt("cs")];
		clockwise = new Vector3 (0,0,-10f);
		anticlockwise = new Vector3 (0, 0, 10f);
		defaultrot = clockwise;


		collectedint = 0;
		mid = Screen.width * 0.5f;
		speedvect = new Vector2 (0, 1);
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = speedvect * speed;
		gameObject.transform.rotation = Quaternion.identity;

	}
	void OnEnable(){
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = speedvect * speed;
		gameObject.transform.rotation = Quaternion.identity;
	}
	// Update is called once per frame
	void Update () {
		// effects...
		gameObject.transform.Rotate(defaultrot);
		l = Mathf.Lerp (0.3f,0.4f,Mathf.PingPong(Time.time*10,1));
		gameObject.transform.localScale = new Vector3 (l, l, 1);
		//


		if (gameObject.transform.position.z > 1) {// this is when game is over
			admobcall2.InterstitialAdCounter++;
			gameObject.GetComponent<AudioSource>().Play();
			iTween.PunchScale (rankType, new Vector2 (1f, 1f), 4f);
			PlayerPrefs.SetInt("cube",collectedint + PlayerPrefs.GetInt("cube"));
			PowerUpsStatics.ResetPowers ();
			//reset position to a point here...
			//Time.timeScale = 0;
			pause.SetActive (false); // so that we cannont resume for pause menu
			gameObject.transform.position = lastpos;
			speedvect = lastSpeed;
			rb.velocity = Vector3.zero;
			speed = 2.5f;
			Debug.Log ("asd");
			// so that we start from base speed again..
			GameOverPanel.transform.GetChild (0).gameObject.GetComponent<Text> ().text = scoretype[collectedint/20];
			GameOverPanel.transform.GetChild (1).gameObject.GetComponent<Text> ().text = "Score - "+collectedint.ToString();
			GameOverPanel.transform.GetChild (2).gameObject.GetComponent<Text> ().text ="Tip-\n" + tips[Random.Range(0,tips.Length)]; // give tips to user
			GameOverPanel.SetActive (true);
			iTween.PunchPosition (GameOverPanel, new Vector2 (0,100f), 1f);

			gameObject.GetComponent<BallController> ().enabled = false;

		}
		if(EventSystem.current.currentSelectedGameObject != pause){
			if (Input.touchCount>0 &&Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x >mid || Input.GetKeyDown(KeyCode.RightArrow)) {
			// right turn action here
				defaultrot = clockwise;
				turn(1*invertGM);
				rotangle += invertGM * (-90);
		}
			if (Input.touchCount>0 &&Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x <mid || Input.GetKeyDown(KeyCode.LeftArrow)) {
			// left turn action here
				defaultrot = anticlockwise;
				turn(-1*invertGM);
				rotangle += invertGM * (90);
		}
		}
		
	}
	void turn(int R1Lm1){
		speed += adder;
		if (speedvect.x > 0.5f)
			speedvect = new Vector2 (0, -1 * R1Lm1);
		else if (speedvect.x <-0.5f)
			speedvect = new Vector2 (0,  R1Lm1);
		else if (speedvect.y>0.5f)
			speedvect = new Vector2 (R1Lm1, 0);
		else if (speedvect.y<-0.5f)
			speedvect = new Vector2 (-1*R1Lm1,0);
		rb.velocity = speedvect * speed;
		//rotate cam here
		//iTween.RotateTo (Camera.main.gameObject, new Vector3 (0, 0, rotangle), 0.5f);

		Debug.Log ("pressed");
	}

	void OnTriggerEnter(Collider c){
		collectedint += (int)cubevalue;
		if (Cameraontroller.randomCamerarot != 0) {
			if (collectedint % 3 == 0)
				iTween.RotateTo (Camera.main.gameObject, new Vector3 (0, 0, Random.Range (-90f, 90f)), 2f);
		}
		lastpos = c.transform.position;
		lastSpeed = speedvect; // or u can get speedvect
		Destroy (c.gameObject);
		collected.text = collectedint.ToString();
	}
}
