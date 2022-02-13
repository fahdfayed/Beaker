using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quizManager : MonoBehaviour
{
    public void goQuiz(){
        SceneManager.LoadScene("quiz");
    }
}
