using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class leaderboardController : MonoBehaviour
{
public AuthManager authmanager;

[Header("UserData")]
public TMP_Text usernameField;
public TMP_InputField scoreField;
public TMP_Text displayScore;


void Awake()
{
authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
usernameField.text = authmanager.User.Email;
StartCoroutine(LoadUserData());
}

public void goIndividual()
{
SceneManager.LoadScene("individualleaderboard");
}

public void SaveDataButton()
{
    int x = 3;
    StartCoroutine(UpdateScore((x)));
}
private IEnumerator UpdateScore(int _score)
    {
        //Set the currently logged in user xp
        var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("score").SetValueAsync(_score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Xp is now updated
        }
        }
         private IEnumerator LoadUserData()
    {
        //Get the currently logged in user data
        var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("score").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            displayScore.text = "0";

        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            displayScore.text = snapshot.Value.ToString();
        }
    }
}

