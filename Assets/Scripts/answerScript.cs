using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ans : MonoBehaviour
{
    public bool isCorrect = false;
    public void Answer(){
        if(isCorrect){
            Debug.Log("Correct answer!");
        }
        else{
            Debug.Log("Wrong answer!");
        }

    }
}
