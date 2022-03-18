using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixerControllerLeft : MonoBehaviour
{
    GameObject manager;
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("mixer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.SendMessage("newObjLeft", collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        manager.SendMessage("objExit");
    }
}
