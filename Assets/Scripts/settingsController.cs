
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class settingsController : MonoBehaviour
{
    private GameObject navBar;
    private GameObject cog;
    public uiController ui;
    public AuthManager authmanager;
    public FirebaseAuth auth;
    public DatabaseReference DBreference;

    public void Start()
    {
        authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
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

     public void SignOutButton()
    {
        navBar = GameObject.FindGameObjectWithTag("navBar");
        authmanager.auth.SignOut();
        navBar.SetActive(false);
        SceneManager.LoadScene("login");   
       
    }
}