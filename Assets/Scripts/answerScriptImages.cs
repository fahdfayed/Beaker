using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerScriptImages : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManagerImages quizManagerImages;
    public void Answer(){
        if(isCorrect){
            quizManagerImages.correct();
            Debug.Log("Correct answer!");
            
        }
        else{
            quizManagerImages.wrong();
            Debug.Log("Wrong answer!");
        }

    } 
}

