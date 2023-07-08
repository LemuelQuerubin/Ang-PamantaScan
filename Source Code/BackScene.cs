using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour {
	// Update is called once per frame
    
    // [SerializeField] GameObject exitPanel;
    // public bool exitApp = false;

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape))
        {         
            // INTRO & TUTORIAL SECTION
			if(SceneManager.GetActiveScene().name=="Main_welcome 1")
            {
                Application.Quit();
            }
			if(SceneManager.GetActiveScene().name=="Main_welcome 2")
            {
                SceneManager.LoadScene("Main_welcome 1");

            }
			if(SceneManager.GetActiveScene().name=="Main_welcome 3")
            {
                SceneManager.LoadScene("Main_welcome 2");

            }
            if(SceneManager.GetActiveScene().name=="Main_tutorial")
            {
                SceneManager.LoadScene("Main_welcome 3");

            }

           // ABOUT SECTION
            if(SceneManager.GetActiveScene().name=="PSGuest_AboutSan")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }


           // AR / QR CAMERA SECTION
            if(SceneManager.GetActiveScene().name=="AR Demo")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }
            
            if(SceneManager.GetActiveScene().name=="QR_Scanner")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }

           // MISC. SECTION

            
            if(SceneManager.GetActiveScene().name=="GalleryScene")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }
			
            // MINIGAME SECTION

            if(SceneManager.GetActiveScene().name=="SpotStart")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }

            if(SceneManager.GetActiveScene().name=="SpotTheDifference Level1")
            {
                SceneManager.LoadScene("SpotStart");
            }

            if(SceneManager.GetActiveScene().name=="SpotTheDifference Level2")
            {
                SceneManager.LoadScene("SpotStart");
            }

            if(SceneManager.GetActiveScene().name=="SpotTheDifference Level3")
            {
                SceneManager.LoadScene("SpotStart");
            }


            if(SceneManager.GetActiveScene().name=="Spot_Instructions")
            {
                SceneManager.LoadScene("SpotStart");
            }


            // MINIGAME CORRECT, DONE, GAMEOVER

            if(SceneManager.GetActiveScene().name=="Spot_Correct1")
            {
                SceneManager.LoadScene("SpotStart");
            }

            if(SceneManager.GetActiveScene().name=="Spot_Correct2")
            {
                SceneManager.LoadScene("SpotStart");
            }

            if(SceneManager.GetActiveScene().name=="Spot_Correct3")
            {
                SceneManager.LoadScene("SpotStart");
            }

                // not sure kung tama ba, basta walang mangyayari kapag nag-back kapag ito na scene
            if(SceneManager.GetActiveScene().name=="Spot_Done 1")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }

            if(SceneManager.GetActiveScene().name=="Spot_Done 2")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }

            if(SceneManager.GetActiveScene().name=="Spot_Done 3")
            {
                SceneManager.LoadScene("PSGuest_Landing");
            }

            if(SceneManager.GetActiveScene().name=="Spot_GameOver")
            {
                SceneManager.LoadScene("SpotStart");
            }
}
}

