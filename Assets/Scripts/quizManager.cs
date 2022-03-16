using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quizManager : MonoBehaviour
{
    
    public List<QuestAndAns> QnA;
    public GameObject[] choices;
    public int currentQ;
    public Text qText;
    public Text scoreText;

    public GameObject goPanel;
    public GameObject quizPanel;
    
    int totalQues = 0;
    public int score;

    private void Start(){
        totalQues = QnA.Count;
        // if(goPanel == null)
        // {
        //     goPanel = GameObject.FindGameObjectWithTag("goPanel");
        //     if(goPanel == null)
        //     Debug.LogError(name + " could not find goPanel");
        // }

        goPanel.SetActive(false);
        generateQ(); 
    }
    public void gameOver(){
        quizPanel.SetActive(false);
        goPanel.SetActive(true);
        
        scoreText.text = score + "/" + totalQues;
    }

    public void returnToMenu()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("quizDifficulty");
    }

    public void generateQ()
    {
        if (QnA.Count > 0){
            currentQ = Random.Range(0, QnA.Count);
            qText.text = QnA[currentQ].question;
            setAns();

        }
        else  
        {
            Debug.Log("No questions left");
            gameOver();
        }

    } 

    // creates answer for the question
    void setAns(){
        for (int i= 0; i < choices.Length; i++){
            // is wrong by default
            // sets all the choices of that question to wrong answer
            choices[i].GetComponent<answerScript>().isCorrect = false;
            // each button has text as a child, gets child allows us to access the text of the button, then get component<txt) allows us to see the text
            // wrote transform to use the properties from that library
            // blabla.text sets the text
            choices[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQ].choices[i];
            if (QnA[currentQ].ansIndex == i){
                choices[i].GetComponent<answerScript>().isCorrect = true;
            }
        }
    } 

    // will generate the next question once correct answer is chosen
    public void correct(){
        // removes this question that has already been asked
        scoreScript.instance.addPoint();
        score ++;
        QnA.RemoveAt(currentQ);
        generateQ();
        
    } 

    public void wrong(){
        QnA.RemoveAt(currentQ);
        generateQ();
    }
    
    
}
