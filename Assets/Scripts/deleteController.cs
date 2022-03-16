using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("shouldDestroy");
    }
}
