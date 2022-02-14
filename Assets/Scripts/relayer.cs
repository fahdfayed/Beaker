using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relayer : MonoBehaviour
{
    private GameObject ui;
    private void Move()
    {
        ui = GameObject.FindGameObjectWithTag("navManager");
        ui.SendMessage("Move");
    }
}
