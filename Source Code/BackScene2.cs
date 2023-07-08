using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene2 : MonoBehaviour
{
   [SerializeField] GameObject exitPanel;
    public bool exitApp = false;

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape))
        {  if(SceneManager.GetActiveScene().name=="PSGuest_Landing" && exitApp == false)
            {
				exitPanel.SetActive (true);
                exitApp = true;
                Debug.Log(exitApp);

			}

            else{
                Debug.Log("Exit");
                Application.Quit();
            }
            
        }
    }
    public void Later()
    {
        exitPanel.SetActive (false);
        exitApp = true;
        Debug.Log(exitApp);
    }



    public void ReviewApp(){
        Application.OpenURL("https://forms.gle/tKug4C6DmYH5kuJfA");
        exitPanel.SetActive (false);
    }

}
