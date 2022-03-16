using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManager quizManager;
    public void Answer(){
        if(isCorrect){
            quizManager.correct();
            Debug.Log("Correct answer!");
            
        }
        else{
            quizManager.wrong();
            Debug.Log("Wrong answer!");
        }

    } 
}
