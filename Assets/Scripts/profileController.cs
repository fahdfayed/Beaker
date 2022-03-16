using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

using TMPro;

public class profileController : MonoBehaviour
{
public AuthManager authmanager;
public DatabaseReference DBreference;

public TMP_Text userName;
public TMP_Text errorMessage;

public void Awake()
{
GameObject.DontDestroyOnLoad(this.gameObject);
authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
StartCoroutine(getUsername());

}
private IEnumerator getUsername()
{
    var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("username").GetValueAsync();
    yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {  
            DataSnapshot snapshot = DBTask.Result;
            userName.text = snapshot.Value.ToString();
        }

}

//function to update pfp
private IEnumerator updateProfilePicture(string __newPfpUrl)
{
    // check if user is not null and that we have an actual user
    if (authmanager.User!= null)
    {
        // creating a new user profile to set the photo url to the account
        UserProfile profile = new UserProfile();
        try
        {
            UserProfile _profile = new UserProfile
            {
                PhotoUrl = new System.Uri(__newPfpUrl),
            };
            profile = _profile;
        }
        catch
        {
            errorMessage.text = ("Error please try again");
            yield break;
        }
        var pfptask = authmanager.User.UpdateUserProfileAsync(profile);
        yield return new WaitUntil(predicate: () => pfptask.IsCompleted);
        if (pfptask.Exception != null)
        {
            Debug.LogError($"Updating profile picture was not successful: {pfptask.Exception}");
        }
        else
        {
            errorMessage.text = ("Profile picture successfullt changed");
        }
    }
}


}
