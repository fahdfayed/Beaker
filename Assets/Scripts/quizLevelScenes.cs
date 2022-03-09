using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quizLevelScenes : MonoBehaviour
{
    // scene loaders
    public void goQuizEasy(){
        SceneManager.LoadScene("quizEasy");
    }
    public void goQuizMed(){
        SceneManager.LoadScene("quizMed");
    }
    public void goQuizHard(){
        SceneManager.LoadScene("quizHard");
    }

    public void goMenu(){
        SceneManager.LoadScene("quizDifficulty");
    }

}
