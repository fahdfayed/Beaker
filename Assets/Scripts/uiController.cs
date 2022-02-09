using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    public GameObject ui;
    public static GameObject thisInstance;
    public static GameObject uiInstance;

    public Image labSprite;
    public Image quizSprite;
    public Image leaderboardSprite;
    public Image profileSprite;

    public bool onScreen = true;

    public GameObject nav;
    public float baseNavX;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (thisInstance == null)
        {
            thisInstance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(ui);

        if (uiInstance == null)
        {
            uiInstance = ui;
        }
        else
        {
            Destroy(ui);
        }
        baseNavX = nav.transform.position.x;
    }
    private void goLab()
    {
        labSprite.color = new Color32(254, 95, 85, 255);
        quizSprite.color = new Color32(160, 160, 160, 255);
        leaderboardSprite.color = new Color32(160, 160, 160, 255); 
        profileSprite.color = new Color32(160, 160, 160, 255);
        SceneManager.LoadScene("lab");
    }
    private void goQuiz()
    {
        labSprite.color = new Color32(160, 160, 160, 255);
        quizSprite.color = new Color32(254, 95, 85, 255);
        leaderboardSprite.color = new Color32(160, 160, 160, 255);
        profileSprite.color = new Color32(160, 160, 160, 255);
        SceneManager.LoadScene("quizDifficulty");
    }
    private void goLeaderboard()
    {
        labSprite.color = new Color32(160, 160, 160, 255);
        quizSprite.color = new Color32(160, 160, 160, 255);
        leaderboardSprite.color = new Color32(254, 95, 85, 255);
        profileSprite.color = new Color32(160, 160, 160, 255);
        SceneManager.LoadScene("teamLeaderboard");
    }
    private void goProfile()
    {
        labSprite.color = new Color32(160, 160, 160, 255);
        quizSprite.color = new Color32(160, 160, 160, 255);
        leaderboardSprite.color = new Color32(160, 160, 160, 255);
        profileSprite.color = new Color32(254, 95, 85, 255);
        SceneManager.LoadScene("profile");
    }
    private void goSettings()
    {
        labSprite.color = new Color32(160, 160, 160, 255);
        quizSprite.color = new Color32(160, 160, 160, 255);
        leaderboardSprite.color = new Color32(160, 160, 160, 255);
        profileSprite.color = new Color32(160, 160, 160, 255);
        SceneManager.LoadScene("settings");
    
}}
    