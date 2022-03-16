using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class teamController : MonoBehaviour
{

public TMP_Text[] teamMembers;
public string[] membersTeam;
public TMP_Text teamShow;
public string teamMembers1;
public AuthManager authmanager;
public DatabaseReference DBreference;
int counter = 0;
void Awake()
{
authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
}
public void load_deets(){
StartCoroutine(showLeaderboard());

}
 private IEnumerator showLeaderboard()
    {
      var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("team").GetValueAsync();
      yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            teamMembers[1].text = snapshot.Value.ToString();
        
    }
}
}
