using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerScript : MonoBehaviour
{
    public bool isCorrect = false;

    // initialised a reference because it uses the correct method from quizManager
    public quizManager quizManager;

    //gets called when we click on a button
    public void Answer(){
        if(isCorrect){
            Debug.Log("Correct answer!");
            quizManager.correct();
        }
        else{
            Debug.Log("Wrong answer!");
        }

    }
}
