using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quizManagerImages : MonoBehaviour
{
    public List<QuesAndAnsImages> qna;
    public GameObject[] choices;
    public int currentQ;
    public Text questionText;
    public Text scoreText;

    public GameObject goPanel;
    public GameObject quizPanel;
    
    int totalQues = 0;
    public int score;

    private void Start(){
        totalQues = qna.Count;
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
        if (qna.Count > 0){
            currentQ = Random.Range(0, qna.Count);
            questionText.text = qna[currentQ].question;
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
            choices[i].transform.GetChild(0).GetComponent<Image>().sprite = qna[currentQ].choices[i];
            if (qna[currentQ].ansIndex == i){
                choices[i].GetComponent<answerScript>().isCorrect = true;
            }
        }
    } 

    // will generate the next question once correct answer is chosen
    public void correct(){
        // removes this question that has already been asked
        scoreScript.instance.addPoint();
        score ++;
        qna.RemoveAt(currentQ);
        generateQ();
        
    } 

    public void wrong(){
        qna.RemoveAt(currentQ);
        generateQ();
    }
}
