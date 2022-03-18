
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class teamController : MonoBehaviour
{

    public TMP_Text[] teamMembers;
    public TMP_Text[] teamMembersScores;
    public string[] memberss;
    public TMP_Text teamShow;
    public string team;
    public string teamMembers1;
    public AuthManager authmanager;
    public FirebaseAuth auth;
    public DatabaseReference DBreference;

    int counter = 0;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
        StartCoroutine(showLeaderboard());
    }

    public void goIndividual()
    {
        SceneManager.LoadScene("individualleaderboard");
    }
    private IEnumerator showLeaderboard()
    {

        List<string> userss = new List<string>();
        List<string> scoress = new List<string>();

        var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("team").GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            team = snapshot.Value.ToString();
            teamShow.text = ("Team " + snapshot.Value.ToString());
        }
        var DDTask = authmanager.DBreference.Child("users").OrderByChild("team").GetValueAsync();
        yield return new WaitUntil(predicate: () => DDTask.IsCompleted);

        if (DDTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DDTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot2 = DDTask.Result;
            foreach (DataSnapshot childSnapchot in snapshot2.Children.Reverse<DataSnapshot>())
            {
                if (childSnapchot.Child("team").Value.ToString() == team)
                {
                    userss.Add(childSnapchot.Child("username").Value.ToString());
                    scoress.Add(childSnapchot.Child("score").Value.ToString());
                    counter++;
                }
                int[] scoressArray = new int[userss.Count];
                string[] userssArray = new string[userss.Count];

                for (int i = 0; i < scoressArray.Length; i++)
                {
                    userssArray[i] = userss[i];
                    scoressArray[i] = Int32.Parse(scoress[i]);
                }
                Array.Sort(scoressArray, userssArray);
                Array.Reverse(scoressArray);
                Array.Reverse(userssArray);
                for (int i = 0; i < scoressArray.Length; i++)
                {
                    teamMembers[i].text = userssArray[i];
                    teamMembersScores[i].text = scoressArray[i].ToString();
                }

            }

        }

    }
}
