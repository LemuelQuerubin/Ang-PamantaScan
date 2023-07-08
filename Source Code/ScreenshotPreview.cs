using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotPreview : MonoBehaviour {

	
	
	[SerializeField]
	GameObject canvas;
	[SerializeField]
	Sprite defaultImage;
	string[] files = null;
	int whichScreenShotIsShown= 0;


	void Start () {
		canvas.GetComponent<Image> ().sprite = defaultImage;
		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
		if (files.Length > 0) {
			GetPictureAndShowIt ();
		}
	}
	public void Share(){
        StartCoroutine(ShareSomething());
    }

    public IEnumerator ShareSomething()
	{
        Texture2D image = Resources.Load("image", typeof(Texture2D)) as Texture2D;
        yield return null;
        
		string pathToFile = files [whichScreenShotIsShown]; 
		Texture2D texture = GetScreenshotImage (pathToFile); 

		new NativeShare().AddFile( pathToFile )
		.SetSubject("Ang PamantaScan").SetText("Hello!").SetUrl("www.facebook.com/angpamantasanplm")
	    .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
	    .Share();
	}

	void GetPictureAndShowIt() //display lang
	{
		string pathToFile = files [whichScreenShotIsShown]; 
		Texture2D texture = GetScreenshotImage (pathToFile); 
		Sprite sp = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height),
			new Vector2 (0.5f, 0.5f));
		canvas.GetComponent<Image> ().sprite = sp;
	}

	Texture2D GetScreenshotImage(string filePath) 
	{
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists (filePath)) {
			fileBytes = File.ReadAllBytes (filePath);
			texture = new Texture2D (2, 2, TextureFormat.RGB24, false);
			texture.LoadImage (fileBytes);
		}
		return texture;
	}

	public void DeleteImage()
	{
		if (files.Length > 0) {
			string pathToFile = files [whichScreenShotIsShown];
			if (File.Exists (pathToFile))
				File.Delete (pathToFile);
			files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
			if (files.Length > 0)
				NextPicture ();
			else
				canvas.GetComponent<Image> ().sprite = defaultImage;
		}
	}

	public static void shareImage(string subject, string title, string message, string imagePath) {
    #if UNITY_ANDROID

    AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
    AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
    intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
    intentObject.Call<AndroidJavaObject>("setType", "image/png");
    intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
    intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), title);
    intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), message);

    AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
    AndroidJavaClass fileClass = new AndroidJavaClass("java.io.File");

    AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + imagePath);

    intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

    AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
    currentActivity.Call("startActivity", intentObject);

    #endif
	}

	

	public void NextPicture()
	{
		if (files.Length > 0) {
			whichScreenShotIsShown += 1;
			if (whichScreenShotIsShown > files.Length - 1)
				whichScreenShotIsShown = 0;
			GetPictureAndShowIt ();
		} 
	}

	public void PreviousPicture()
	{
		if (files.Length > 0) {
			whichScreenShotIsShown -= 1;
			if (whichScreenShotIsShown < 0)
				whichScreenShotIsShown = files.Length - 1;
			GetPictureAndShowIt ();
		} 
	}
}
