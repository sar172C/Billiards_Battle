using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    
    private bool isPopupOn;
    public Image Popup = null;

    void Start()
    {
        if (Popup != null)
        {
            Popup.enabled = false;
        }
        isPopupOn = false;
    }


    public void activatePopup()
    { 

            if (isPopupOn == true)
            {

                Popup.enabled = false;
                isPopupOn = false;
            }

            else
            {

                Popup.enabled = true;
                isPopupOn = true;
            }
        
    }

    public void quitGame()
    {
        Application.Quit();

    }

}