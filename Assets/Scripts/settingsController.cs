using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class settingsController : MonoBehaviour
{
    private GameObject navBar;
    private GameObject cog;
    public uiController ui;

    public void Start()
    {
        ui = GameObject.FindGameObjectWithTag("navManager").GetComponent<uiController>();
    }

    private void goLogin()
    {
        SceneManager.LoadScene("login");
        navBar = GameObject.FindGameObjectWithTag("navBar");
        cog = GameObject.FindGameObjectWithTag("settingsCog");
        if (navBar != null)
        {
            if (ui.onScreen)
            {
                navBar.transform.position = new Vector2(navBar.transform.position.x + 10000, navBar.transform.position.y);
                ui.onScreen = false;
            }
        }
    }
}