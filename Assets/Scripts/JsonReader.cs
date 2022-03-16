// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class JsonReader : MonoBehaviour
// {
    /* public TextAsset JsonText;
    public List<QuestAndAns> QnA = new List<QuestAndAns>();
    public GameObject[] choices;
    public int currentQ;
    public static string qText; */



    /* [System.Serializable]
    public class content{
        public string question;
        public string[] choices;
        public int ansIndex;
    } */

    /* [System.Serializable]
    public class easyDataList{
        public content[] easyData;
    }

    public easyDataList easyList = new easyDataList();

    void Start()
    {
        //qData = Resources.Load<TextAsset>("Resources/JsonText.txt");
        //easyList = JsonUtility.FromJson<easyDataList>(JsonText.text);
        easyList = JsonUtility.FromJson<easyDataList>(JsonText.text);
        qText = easyList.easyData[0].question;
        Debug.Log(qText);
        //easyList.easyData[0].question;
        
        //JsonReader.qText.text = easyList.easyData[0].question;
        //Debug.Log(easyList.easyData[0].question);
        //Debug.Log(easyList.easyData[0].choices[2]);
         
    } */

    

    /* void generateQ(){
        if (QnA.Count > 0){
            currentQ = Random.Range(0, QnA.Count);
            /// .question gets te question from the QuestandAns script
            
            qText.text = QnA[currentQ].question;
        
            setAns();
        }
        else{
            //Debug.Log("Out of questions");
            Debug.Log("No questions left");
        }

    } */

//}
