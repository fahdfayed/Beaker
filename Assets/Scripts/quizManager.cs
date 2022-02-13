using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quizManager : MonoBehaviour
{
    public void goQuiz(){
        SceneManager.LoadScene("quiz");
    }

    public List<QuestAndAns> QnA;
    public GameObject[] choices;
    public int currentQ;
    public Text qText;

    private void Start(){
        generateQ(); 
    }

    void generateQ(){
        currentQ = Random.Range(0, QnA.Count);
        qText.text = QnA[currentQ].question;
    }

    void setAns(){
        for (int i= 0; i < choices.Length; i++){
            choices[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQ].answers[i];
        }
    }
}
