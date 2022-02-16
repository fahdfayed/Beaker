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
        if (QnA.Count > 0){
            currentQ = Random.Range(0, QnA.Count);
            qText.text = QnA[currentQ].question;

            setAns();
        }
        else{
            Debug.Log("Out of questions");
        }

    }

    void setAns(){
        for (int i= 0; i < choices.Length; i++){
            // is wrong by default
            choices[i].GetComponent<answerScript>().isCorrect = false;
            choices[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQ].answers[i];

            // i + 1 cuz array starts from 0 and the correct answer is from 1-4
            if (QnA[currentQ].correctAns == i+1){
                choices[i].GetComponent<answerScript>().isCorrect = true;
            }
        }
    }

    // will generate the next question once correct answer is chosen
    public void correct(){
        // removes this question that has already been asked
        QnA.RemoveAt(currentQ);
        generateQ();
    }
}
