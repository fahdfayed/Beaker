using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loginController : MonoBehaviour
{
    public GameObject navBar;
    public uiController ui;

 

    private void goLab()
    {
        SceneManager.LoadScene("lab");
        navBar = GameObject.FindGameObjectWithTag("navBar");
        if (navBar != null)
        {
            ui = GameObject.FindGameObjectWithTag("navManager").GetComponent<uiController>();
            if (!ui.onScreen)
            {  
                navBar.transform.position = new Vector2(ui.baseNavX, navBar.transform.position.y);
                ui.onScreen = true;
            }
        }
    }
    private void goSettings()
    {
        SceneManager.LoadScene("settings");
    }
    private void goRegister()
    {
        SceneManager.LoadScene("register");
    }
}