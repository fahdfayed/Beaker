
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

public class superUser : MonoBehaviour
{
public AuthManager authmanager;
public FirebaseAuth auth;
public DatabaseReference DBreference;
public GameObject superUserButton;


void Awake()
{
    DontDestroyOnLoad(this.gameObject); 
    authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();
    superUserButton = GameObject.FindGameObjectWithTag("superUserButton");
    StartCoroutine(authenticateSuperUser());
    StartCoroutine(Start());

}
public IEnumerator Start()
{
    var dropdown = GameObject.FindGameObjectWithTag("dropDown").GetComponent<Dropdown>();
    dropdown.ClearOptions();
    List<string> items = new List<string>();
     var DBTask = authmanager.DBreference.Child("users").OrderByChild("role").GetValueAsync();
      yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {  
            DataSnapshot snapshot = DBTask.Result;
            foreach (DataSnapshot childSnapchot in snapshot.Children.Reverse<DataSnapshot>())
            {
                if (childSnapchot.Child("username").Value.ToString() == "fahd@gmail.com")
                {
                    items.Add(childSnapchot.Value.ToString());

                }
            }

        }
            items.Add("item 1");
            items.Add("item 2");
            
    foreach (var item in items)
    {
        Debug.LogFormat ("item {0}", item);
        dropdown.options.Add(new Dropdown.OptionData() {text = item});
        StartCoroutine(editUsername(dropdown));
    }
        

}

public IEnumerator editUsername (Dropdown dropdown)
{
    int index = dropdown.value;

    
    yield return new WaitForSeconds(2);
    

}
public IEnumerator authenticateSuperUser()
{
    var DBTask = authmanager.DBreference.Child("users").Child(authmanager.User.UserId).Child("role").GetValueAsync();
      yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {  
            DataSnapshot snapshot = DBTask.Result;
            
            if (snapshot.Value.ToString() == "Admin"){
                superUserButton.SetActive(true);
            }
            else{
                superUserButton.SetActive(false);
            }
        }
}

private IEnumerator test()
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
     

        }

            
}

}


