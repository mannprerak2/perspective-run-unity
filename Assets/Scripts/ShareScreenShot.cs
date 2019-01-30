	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;
	using System.IO;

	public class ShareScreenShot : MonoBehaviour {

		private bool isProcessing = false;
		public float startX;
		public float startY;
		public int valueX;
		public int valueY;

		public void shareScreenshot(){

			if(!isProcessing && GameObject.Find("Share").GetComponent<Image>().enabled)
				StartCoroutine( captureScreenshot() );
		}

		public IEnumerator captureScreenshot(){
			isProcessing = true;
			yield return new WaitForEndOfFrame();

			Texture2D screenTexture = new Texture2D(Screen.width*valueX/10000, Screen.height*valueY/10000,TextureFormat.RGB24,true);

			// put buffer into texture
			//screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
			//create a Rect object as per your needs.
			screenTexture.ReadPixels(new Rect
				(Screen.width*startX, (Screen.height*startY), Screen.width*valueX/10000, Screen.height*valueY/10000),0,0);

			// apply
			screenTexture.Apply();
			//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO

			//byte[] dataToSave = Resources.Load<TextAsset>("everton").bytes;
			byte[] dataToSave = screenTexture.EncodeToPNG();

			string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");

			File.WriteAllBytes(destination, dataToSave);


		if(Application.isMobilePlatform)
			{
				AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
				AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
				intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
				AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
				AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
				intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
				intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Can You Beat My Score in *MAZE Dodge* ?\n" +
					"Download the game on play store at "+"\nhttps://play.google.com/store/apps/");
				intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Maze Dodge by PkmnApps?");
				intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
				AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			//chooser
			AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share screenshot Via");
			currentActivity.Call("startActivity", jChooser);


			}
			isProcessing = false;

		}
	public void RateUs(){
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=YUR_ID");
		#endif
	}
	}

