using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
public class admobcall : MonoBehaviour {
	public GameObject rewardButtonRecive;
	bool clicked;
	public Text tester;
	public InterstitialAd interstitial;
	public RewardBasedVideoAd rewardbasedvid;
	void Start(){
		clicked = false;
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
		string adUnitId = "ca-app-pub-3940256099942544/1033173712";
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
		if(interstitial !=null && interstitial.IsLoaded())
		interstitial.Show();

		}
		public void showrewardvid(){
		if(this.rewardbasedvid.IsLoaded())
		this.rewardbasedvid.Show ();
		this.rewardbasedvid = null;
		}


		public void loadrewardvid(){
		if (!clicked) {// so that duplicate events dont occur
			#if UNITY_EDITOR
			string adUnitId = "unused";
			#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/5224354917";
			#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/1712485313";
			#else
		string adUnitId = "unexpected_platform";
			#endif
			//AdRequest request = new AdRequest.Builder ().Build ();

		    tester.text = "pressed";
			clicked = true;

			this.rewardbasedvid = RewardBasedVideoAd.Instance;

			rewardbasedvid.OnAdLoaded += HandleRewardBasedVideoLoaded;
			rewardbasedvid.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
			rewardbasedvid.OnAdRewarded += HandleRewardBasedVideoRewarded;

			this.rewardbasedvid.LoadAd (createAdRequest (), adUnitId);
		}
		}

		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
		//award user here
		tester.text = "video complete";
		rewardButtonRecive.SetActive (true);
		}
		public void HandleRewardBasedVideoLoaded(object sender,System.EventArgs args){
		//when video is loaded
		clicked = false;
		tester.text = "Video loaded";
		//showrewardvid ();
		}
		public void HandleRewardBasedVideoFailedToLoad(object sender,System.EventArgs args){
		// when video fails to load
		clicked = false;
		tester.text = "Video load failed";

		}
		}
