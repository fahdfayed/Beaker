using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManager quizManager;
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
