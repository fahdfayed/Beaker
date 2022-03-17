
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
public class editProfile : MonoBehaviour
{
    private GameObject navBar;
    private GameObject cog;
    public uiController ui;
    public AuthManager authmanager;
    public FirebaseAuth auth;
    public DatabaseReference DBreference;
    public TMP_InputField newUsername;

    public void Start()
    {
        authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
        ui = GameObject.FindGameObjectWithTag("navManager").GetComponent<uiController>();
        navBar = GameObject.FindGameObjectWithTag("navBar");
        navBar.SetActive(true);
    }

    private IEnumerator changeUsername(TMP_InputField username)
    {
        var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("username").SetValueAsync(username.text);
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
        }
    }

    public void changePassword()
    {
   
    authmanager.auth.SendPasswordResetEmailAsync(authmanager.auth.CurrentUser.Email).ContinueWith(task => {
    if (task.IsCanceled) {
      Debug.LogError("SendPasswordResetEmailAsync was canceled.");
      return;
    }
    if (task.IsFaulted) {
      Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
      return;
    }

    Debug.Log("Password reset email sent successfully.");
  });

    }
    public void changeUsernameButton()
    {
        StartCoroutine(changeUsername(newUsername));
    }

}
