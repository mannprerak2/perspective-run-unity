using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailyGiftAndTips : MonoBehaviour {
	public Color a,b;
	public GameObject dailyGiftpanel;
	Image i;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("day")) {
			if (System.DateTime.Now.Day != PlayerPrefs.GetInt ("day")) {
				dailyGiftpanel.SetActive (true);
				if (System.DateTime.Now.Day - PlayerPrefs.GetInt ("day") == 1) {
					// give daily gift here
					dailyGiftpanel.transform.GetChild (0).gameObject.GetComponent<Text> ().text = "200";
				}
			} else
				gameObject.SetActive (false);
		} else {// for first time runners
			dailyGiftpanel.SetActive(true);
		}

		i =dailyGiftpanel.GetComponent<Image> ();
		iTween.PunchRotation (dailyGiftpanel, new Vector3 (0,0, 100), 7f);
		iTween.PunchScale (dailyGiftpanel, new Vector3 (1.5f, 1.5f, 0), 5f);
	}
	public void OnGiftRecieveButton(){
		PlayerPrefs.SetInt("cube",PlayerPrefs.GetInt("cube")+int.Parse(dailyGiftpanel.transform.GetChild(0).gameObject.GetComponent<Text>().text));
		PlayerPrefs.SetInt ("day", System.DateTime.Now.Day);
		iTween.MoveTo (dailyGiftpanel, Vector3.zero, 2f);
		iTween.ScaleTo (dailyGiftpanel, new Vector3 (0, 0, 0), 2f);
		StartCoroutine (collectTimer (2f));
	}
	// Update is called once per frame
	void Update () {
		i.color = Color.Lerp (a, b, Mathf.PingPong (Time.time*2
			, 1));
	}
	 IEnumerator collectTimer(float time){
		yield return new WaitForSeconds (time);
		dailyGiftpanel.SetActive (false);
		iTween.Stop ();
		gameObject.SetActive (false);
	}
}
