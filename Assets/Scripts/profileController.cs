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

public void Awake()
{
GameObject.DontDestroyOnLoad(this.gameObject);
authmanager = GameObject.FindGameObjectWithTag("authmanager").GetComponent<AuthManager>();

userName.text = "KHELLO";
userName.text = "KHAI";   
userName.text = authmanager.User.Email; 



}
}
