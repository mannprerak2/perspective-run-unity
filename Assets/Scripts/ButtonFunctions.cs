using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
public class ButtonFunctions : MonoBehaviour {
	public GameObject GetCoinPanel,AudioEffectShop,flash,MainMenuCanvas,GameModeCanvas,pauseButton,admanager,ScrollButtons,taptostartpanel,powerUpCanvas,DesignCanvas,rewardRecieve,tick,tick2,pausepanel,powerpanel,sphere,notEnoughCube,areYouSure,realpowerupCanvas,lineObject,gameOverPanel;
	static bool gameModeThruGame = false;
	GameObject unlockable;
	public Text cubeUpdateText,audiotext;
	bool PP,ppp;
	void Start(){

		ppp = false;
		PP = false;
		if(PlayerPrefs.HasKey("aud"))
		AudioListener.volume=PlayerPrefs.GetFloat ("aud");
		if (gameModeThruGame) {
			gameModeThruGame = false;
			GameModeMain ();
		}
	}
	public void GetCoinsShop(){
		GetCoinPanel.SetActive (true);
	}
	public void CloseGetCoinShop(){
		GetCoinPanel.SetActive (false);
	}
	public void GameModeThruGame(){
		gameModeThruGame = true;
		MainMenu ();
	}
	void resetGameModeStatics(){
		BallController.invertGM = 1;
		Cameraontroller.CrossCameraRot = 0;
		Cameraontroller.randomCamerarot = 0; // set this to anything except 0 to work set it to 0 to disable
		Cameraontroller.nightModeGM = 0;
		Cameraontroller.rainyModeGM = 0;// set to 1 to use
		Cameraontroller.frozenModeGM =0; // set to 1 to use
	}
	//game mode test functions
	public void GameModeInvert(){
		BallController.invertGM = -1;
		Debug.Log (BallController.invertGM.ToString () +"kkk");

	}
	public void GameModeCrossCam(){
		Cameraontroller.CrossCameraRot = 1;// set to 0 to stop usage
	}
	public void GameModeCamRot(){
		Cameraontroller.randomCamerarot = 1; // set this to anything except 0 to work set it to 0 to disable
	}
	public void GameModeNight(){
		Cameraontroller.nightModeGM = 1; // set to anything else than 1 to make inactive
	}
	public void GameModeRainyStorm(){
		Cameraontroller.rainyModeGM = 1;

	}
	//
	//main menu functions
	public void BackButtonMain(){
		GameModeCanvas.SetActive (false);
		flash.SetActive (false);
		flash.SetActive (true);
		MainMenuCanvas.SetActive (true);
	}
	public void GameModeMain(){
		GameModeCanvas.SetActive (true);
		flash.SetActive (false);
		flash.SetActive (true);
		MainMenuCanvas.SetActive (false);
	}
	public void GameModeFrozen(){
		Cameraontroller.frozenModeGM = 1;
	}
	public void ShowVid(){
		admanager.GetComponent<admobcall2> ().showrewardvid ();

	}
	public void Continue(){
		//sphere.GetComponent<BallController> ().enabled = true;
		sphere.GetComponent<BallController> ().GameOverPanel.SetActive (false);
		taptostartpanel.SetActive (true);
		pauseButton.SetActive (true);
		//Time.timeScale = 1;

	}
	public void realPlay(){
		SceneManager.LoadSceneAsync (1);
	}
	public void speedControlButton(){
		if (EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.activeInHierarchy) {
			EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.SetActive (false);
			opositePowerChecker ("scp");
			PowerUpsStatics.scActive = false;

		}
		else if (powerChecker ("scp")) {
			PowerUpsStatics.scActive = true;
			EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.SetActive (true);

		}
	}
	public void bigPathButton(){
		if (EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.activeInHierarchy) {
			EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.SetActive (false);
			opositePowerChecker ("bpp");
			PowerUpsStatics.bpActive = false;

		}
			
		else if (powerChecker ("bpp")) {
			PowerUpsStatics.bpActive = true;
			EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.SetActive (true);

		}
	}
	public void DoubleCubes(){
		if (EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.activeInHierarchy) {
			EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.SetActive (false);
			opositePowerChecker ("dcp");
			PowerUpsStatics.dcActive = false;

		}
		else if (powerChecker ("dcp")) {
			PowerUpsStatics.dcActive = true;
			EventSystem.current.currentSelectedGameObject.transform.GetChild (1).gameObject.SetActive (true);

		}
	}
	void opositePowerChecker(string powertype){
		if (PlayerPrefs.HasKey(powertype)) {
			PlayerPrefs.SetInt (powertype, PlayerPrefs.GetInt (powertype) + 1);
			EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text> ().text = PlayerPrefs.GetInt (powertype).ToString()+" left";

		}
	}
	 bool powerChecker(string powertype){
		bool r = false;
		if (PlayerPrefs.HasKey (powertype)) {
			if (PlayerPrefs.GetInt (powertype) > 0) {
				r = true;
				PlayerPrefs.SetInt (powertype, PlayerPrefs.GetInt (powertype) - 1);
				EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text> ().text = PlayerPrefs.GetInt (powertype).ToString()+" left";
			}
		 else {
			r = false;
		}
		}
		return r;
	}
	public void AudioControlButton(){
		AudioListener.volume = 1 - AudioListener.volume;
		if (AudioListener.volume > 0.5f) {
			audiotext.text = "Audio:On";
		} else {
			audiotext.text = "Audio:Off";
		}
		PlayerPrefs.SetFloat ("aud", AudioListener.volume);
	}
	public void PLayButton(){
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync (3);
	}
	public void FacebookPageButton(){
		Application.OpenURL ("https://www.facebook.com/pkmnsApps");
	}
	public void ReplayButton(){
		Time.timeScale = 1;
		if(admobcall2.InterstitialAdCounter%4 == 0)
			admanager.GetComponent<admobcall2> ().showinter ();
		SceneManager.LoadSceneAsync (3);

	}
	public void RateUsButton(){
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.pkmnAPPS.PerspectiveRun");
	}
	public void ResumeButton(){
		Time.timeScale = 1;
		pausepanel.SetActive (false);
		sphere.GetComponent<BallController> ().enabled = true;
	}
	public void PauseButton(){
		if (PP) {// when pause pane is on
			Time.timeScale = 1;
			pausepanel.SetActive (false);
			sphere.GetComponent<BallController> ().enabled = true;

		} else {// when pause pane is off
			Time.timeScale = 0;
			pausepanel.SetActive (true);
			sphere.GetComponent<BallController> ().enabled = false;

		}

		PP = !PP;
	}
	public void PowerButton(){
		if (ppp) {
			Time.timeScale = 1;
			powerpanel.SetActive (false);
			sphere.GetComponent<BallController> ().enabled = true;

		} else {
			Time.timeScale = 0;
			powerpanel.SetActive (true);
			sphere.GetComponent<BallController> ().enabled = false;

		}
		ppp = !ppp;
	}
	public void QuitButton(){


	}
	public void GetRewardButton(){
		rewardRecieve.SetActive (false);
		PlayerPrefs.SetInt ("cube",PlayerPrefs.GetInt("cube") + 100);
		cubeUpdateText.text = PlayerPrefs.GetInt ("cube").ToString();
	}
	public void PowerUpCanvasButton(){
		flash.SetActive (false);
		flash.SetActive (true);
		ScrollDeactive ();

		realpowerupCanvas.SetActive (true);
		TOP:
		if (PlayerPrefs.HasKey ("scp")) {
			GameObject.FindGameObjectWithTag ("sc").transform.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetInt ("scp").ToString ();
		}
		if (PlayerPrefs.HasKey ("bpp")) {
			GameObject.FindGameObjectWithTag ("bp").transform.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetInt ("bpp").ToString ();
		}
		if (PlayerPrefs.HasKey ("dcp")) {	
			GameObject.FindGameObjectWithTag ("dc").transform.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetInt ("dcp").ToString ();
		} else {
			PlayerPrefs.SetInt ("scp", 1);
			PlayerPrefs.SetInt ("bpp", 1);
			PlayerPrefs.SetInt ("dcp", 1); // for first time run
			goto TOP;
		}
	}
	public void ChangeShapeButton(){
		ScrollDeactive ();
		flash.SetActive (false);
		flash.SetActive (true);
		powerUpCanvas.SetActive (true);
		ShapeUnlockerStart ();
		if (PlayerPrefs.HasKey ("cdef")) {
			tick2.transform.SetParent(GameObject.Find(PlayerPrefs.GetString("cdef")).transform,false);
			tick2.transform.localPosition = Vector3.zero;
		}
			

	}
	void ShapeUnlockerStart(){
		List<GameObject> blist = new List<GameObject>();
		for (int k = 0; k <= 8; k++) {
			blist.Add (GameObject.Find ("cs" + k.ToString ()));
			if (PlayerPrefs.HasKey ("cs"+k.ToString ())) {
				blist [k].tag = PlayerPrefs.GetString ("cs"+k.ToString ());
				blist [k].transform.GetChild (0).gameObject.SetActive (false);
				//blist [k].GetComponentInChildren < ChildSpinHolder> ().enabled = true;
			}
		}
		blist = null;
	}
	public void DesignButton(){
		flash.SetActive (false);
		flash.SetActive (true);
		DesignCanvas.SetActive (true);
		ScrollDeactive ();
		DesignUnlockerstart ();
		// give ticks here
		if(PlayerPrefs.HasKey("def")){
			tick.transform.SetParent(GameObject.Find(PlayerPrefs.GetString("def")).transform,false);
			tick.transform.localPosition = Vector3.zero;
		}
	}
	void DesignUnlockerstart(){
		List<GameObject> blist = new List<GameObject>();
		for (int k = 0; k <= 9; k++) {
			blist.Add (GameObject.Find ("Button 0" + k.ToString ()));
			if (PlayerPrefs.HasKey (k.ToString ())) {
				blist [k].tag = PlayerPrefs.GetString (k.ToString ());
				blist [k].transform.GetChild (0).gameObject.SetActive (false);
			}
		}
		blist = null;
	}
	void ScrollDeactive(){
		ScrollButtons.SetActive (false);

	}
	public void ShopButton(){
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync (2);
	}
	public void MainMenu(){
		Time.timeScale = 1;
		resetGameModeStatics ();
		SceneManager.LoadSceneAsync (0);

	}

	public void BackButton(){
		if (!ScrollButtons.activeInHierarchy) {
			flash.SetActive (false);
			flash.SetActive (true);
			ScrollButtons.SetActive (true);
			//deactivate other canvases here
			powerUpCanvas.SetActive(false);
			DesignCanvas.SetActive (false);
			realpowerupCanvas.SetActive (false);

		}
		else {
			SceneManager.LoadSceneAsync (0);
		}
	}
	public void DisableAnyButton(){
		EventSystem.current.currentSelectedGameObject.SetActive (false);
	}
	public void AssignDesignButton(){
		if (EventSystem.current.currentSelectedGameObject.CompareTag ("unlocked")) {
			string s = EventSystem.current.currentSelectedGameObject.name;
			tick.transform.SetParent (EventSystem.current.currentSelectedGameObject.transform, false);
			tick.transform.localPosition = new Vector3 (0, 0, 0);
			PlayerPrefs.SetString ("def", s);
			PlayerPrefs.SetInt ("cg", int.Parse (s [s.Length - 1].ToString ()));
		} else
			UnlockerFunc ();
	}
	public void AssignShapeButton(){
		if (EventSystem.current.currentSelectedGameObject.CompareTag ("unlocked")) {
			string s = EventSystem.current.currentSelectedGameObject.name;
			tick2.transform.SetParent (EventSystem.current.currentSelectedGameObject.transform, false);
			tick2.transform.localPosition = new Vector3 (0, 0, 0);
			PlayerPrefs.SetString ("cdef", s);//default tick assigner
			PlayerPrefs.SetInt ("cs", int.Parse (s [s.Length - 1].ToString ())); // tells if item is unlocked or not
		} else
			UnlockerFunc ();
	}
	void UnlockerFunc(){
		int cubesleft = int.Parse (cubeUpdateText.text);
		if (cubesleft >= int.Parse (EventSystem.current.currentSelectedGameObject.transform.GetChild (0).tag)) {
			// taking values from cubeupdate text so gotta change it on every purchase
			areYouSure.GetComponentInChildren<Text> ().text = EventSystem.current.currentSelectedGameObject.transform.GetChild (0).tag;
			unlockable = EventSystem.current.currentSelectedGameObject;
			areYouSure.SetActive (true);
			//put are u sure panel here
		} else {
			// put not enough money panel here and watch ad to earn money...
			notEnoughCube.SetActive(true);
			AudioNotEnoughCoins ();
			//this gets disabled on click now...
		}

	}
	public void yes(){
		flash.SetActive (false);
		flash.SetActive (true);
		AudioItemBought ();
		if (DesignCanvas.activeInHierarchy) {
			unlockable.tag = "unlocked";
			cubeUpdateText.text = (int.Parse (cubeUpdateText.text) - int.Parse (areYouSure.GetComponentInChildren<Text> ().text)).ToString ();
			PlayerPrefs.SetInt ("cube", int.Parse (cubeUpdateText.text));
			string s = unlockable.name;
			unlockable.transform.GetChild (0).gameObject.SetActive (false);
			tick.transform.SetParent (unlockable.transform, false);
			tick.transform.localPosition = new Vector3 (0, 0, 0);
			PlayerPrefs.SetString ("def", s);
			PlayerPrefs.SetInt ("cg", int.Parse (s [s.Length - 1].ToString ()));
			areYouSure.SetActive (false);
			PlayerPrefs.SetString (unlockable.name [unlockable.name.Length - 1].ToString (), "unlocked");
			unlockable = null;
		} else if (realpowerupCanvas.activeInHierarchy) {
			pyes ();
		}
		else
			cyes ();

	}
	 void cyes(){
		unlockable.tag = "unlocked";
		cubeUpdateText.text = (int.Parse (cubeUpdateText.text) - int.Parse (areYouSure.GetComponentInChildren<Text> ().text)).ToString();
		PlayerPrefs.SetInt ("cube", int.Parse (cubeUpdateText.text));
		string s = unlockable.name;
		unlockable.transform.GetChild (0).gameObject.SetActive (false);
		tick2.transform.SetParent (unlockable.transform, false);
		tick2.transform.localPosition = new Vector3 (0, 0, 0);
		PlayerPrefs.SetString ("cdef", s);
		PlayerPrefs.SetInt ("cs", int.Parse (s [s.Length - 1].ToString ()));
		areYouSure.SetActive (false);
		PlayerPrefs.SetString ("cs"+unlockable.name[unlockable.name.Length -1].ToString(), "unlocked");
		unlockable = null;

	}
	void pyes(){
		unlockable.transform.GetChild(1).gameObject.GetComponent<Text>().text = (int.Parse(unlockable.transform.GetChild(1).gameObject.GetComponent<Text>().text) + 1).ToString();
		cubeUpdateText.text = (int.Parse (cubeUpdateText.text) - int.Parse (areYouSure.GetComponentInChildren<Text> ().text)).ToString();
		PlayerPrefs.SetInt ("cube", int.Parse (cubeUpdateText.text));
		PowerType ();
		areYouSure.SetActive (false);

		unlockable = null;
	}

	public void no(){
		AudioItemNotBought ();
		areYouSure.SetActive (false);
	}

	public void GivePowerUpButton(){
		PowerUnlock ();
	}

	void PowerType(){
		int c = 0;
		if (unlockable.tag == "sc") {
			if (PlayerPrefs.HasKey ("scp"))
				c = PlayerPrefs.GetInt ("scp");
			PlayerPrefs.SetInt ("scp", c + 1);
		} else if (unlockable.tag == "bp") {
			if (PlayerPrefs.HasKey ("bpp"))
				c = PlayerPrefs.GetInt ("bpp");
			PlayerPrefs.SetInt ("bpp", c + 1);
		} else if (unlockable.tag == "dc") {
			if (PlayerPrefs.HasKey ("dcp"))
				c = PlayerPrefs.GetInt ("dcp");
			PlayerPrefs.SetInt ("dcp", c + 1);
		}
	}
	void PowerUnlock(){
		int cubesleft = int.Parse (cubeUpdateText.text);
		if (cubesleft >= int.Parse (EventSystem.current.currentSelectedGameObject.transform.GetChild (0).tag)) {
			// taking values from cubeupdate text so gotta change it on every purchase
			areYouSure.GetComponentInChildren<Text> ().text = EventSystem.current.currentSelectedGameObject.transform.GetChild (0).tag;
			unlockable = EventSystem.current.currentSelectedGameObject;
			areYouSure.SetActive (true);
			//put are u sure panel here
		} else {
			// put not enough money panel here and watch ad to earn money...
			notEnoughCube.SetActive(true);
			AudioNotEnoughCoins ();
			//this gets disabled on click now...
		}
	}
	void AudioNotEnoughCoins(){
		AudioEffectShop.GetComponents<AudioSource> () [2].Play ();
	}
	void AudioItemBought(){
		AudioEffectShop.GetComponents<AudioSource> () [0].Play ();
	}
	void AudioItemNotBought(){
		AudioEffectShop.GetComponents<AudioSource> () [1].Play ();
	}

}
