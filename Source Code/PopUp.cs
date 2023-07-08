using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] GameObject closePanel;
    private bool exitApp;
    public void Later()
    {
        exitApp = true;
        closePanel.SetActive (false);
    }

    public void ReviewApp(){
        Application.OpenURL("https://forms.gle/6Qs4wtC76C3RQfZx9");
    }
}
