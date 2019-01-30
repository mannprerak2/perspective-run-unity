using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class admobcall2 : MonoBehaviour {
	public static bool adrunnercomplete,adrunnerloaded,adrunnerClosed;
	public GameObject ButtonFUnc,conti;
	public static int InterstitialAdCounter=3;
	public Text tester,cubetext; 
	public InterstitialAd interstitial;
	public RewardBasedVideoAd rewardbasedvid;
	public Color white;
	void OnDestroy(){
		this.rewardbasedvid = null;
	}
	void Start(){
		if ((InterstitialAdCounter+1)% 4 == 0)
			interstital ();
		adrunnercomplete = false;
		adrunnerloaded = false;
		adrunnerClosed = false;
		loadrewardvid ();
		rewardbasedvid.OnAdLoaded += HandleRewardBasedVideoLoaded;
		rewardbasedvid.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		rewardbasedvid.OnAdRewarded += HandleRewardBasedVideoRewarded;
		rewardbasedvid.OnAdClosed += HandleRewardBasedVideoClosed;
	}
	void Update(){
		if (adrunnerloaded) {
			AdLoaded ();
			adrunnerloaded = false;
		}

		if (adrunnercomplete) {
			AdComplete ();
			adrunnercomplete = false;
		}
		if (adrunnerClosed) {
			tester.text = "Try later...";
			conti.SetActive (false);
			adrunnerClosed = false;
		}

	}

	public void banner(){
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/2934735716";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder().Build();
		// Load a banner ad.
		bannerView.LoadAd(request);


	}
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
			.Build();
	}
	public void interstital(){
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4649460901646137/3931124201"; // this is my id
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);

		// Load an interstitial ad.
		//AdRequest request = new AdRequest.Builder ().Build ();

		interstitial.LoadAd(createAdRequest());


	}
		public void showinter(){
		if (interstitial != null && interstitial.IsLoaded ())
			interstitial.Show ();
		else
			InterstitialAdCounter--;
		Debug.Log ("inter " + InterstitialAdCounter.ToString ());

		}
		public void showrewardvid(){
		if (this.rewardbasedvid.IsLoaded ()) {
			this.rewardbasedvid.Show ();
			this.rewardbasedvid = null;
		}
		}


		public void loadrewardvid(){
			#if UNITY_EDITOR
			string adUnitId = "unused";
			#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4649460901646137/8500924603"; // this is my id
			#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/1712485313";
			#else
		string adUnitId = "unexpected_platform";
			#endif
			//AdRequest request = new AdRequest.Builder ().Build ();


			this.rewardbasedvid = RewardBasedVideoAd.Instance;
			this.rewardbasedvid.LoadAd (createAdRequest (), adUnitId);
			
		}
		void AdComplete(){
		//award user here
		if (cubetext!=null) {
		//for shop
			PlayerPrefs.SetInt ("cube", PlayerPrefs.GetInt ("cube") + 100);
			cubetext.text = PlayerPrefs.GetInt ("cube").ToString ();
			conti.SetActive (false);
			tester.text = "You got 100 cubes !!\n";
			iTween.PunchScale (cubetext.gameObject, new Vector3 (10f, 10f, 0), 4f);
			iTween.PunchRotation (cubetext.gameObject, new Vector3 (0, 0, 45), 8f);
		} else {
		//for game
			conti.GetComponent<Image> ().color = Color.clear; //button not visible
			ButtonFUnc.GetComponent<ButtonFunctions> ().Continue ();
		}
		}
		void AdLoaded(){
			conti.GetComponent<Image> ().color = white;
			tester.text = "Watch Ad";
		}
		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
		admobcall2.adrunnercomplete = true;

		}
		public void HandleRewardBasedVideoLoaded(object sender, System.EventArgs arg){
		admobcall2.adrunnerloaded = true;
		}
		public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs arg){
		tester.text = arg.Message;
		}
		public void HandleRewardBasedVideoClosed(object sender,System.EventArgs arg){
		adrunnerClosed = true;
	    }

		}
