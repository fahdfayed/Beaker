using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset JsonText;

    [System.Serializable]
    public class easyD{
        public string question;
        public string[] choices;
        public int ansIndex;
    }

    [System.Serializable]
    public class easyDataList{
        public easyD[] easyData;
    }

    public easyDataList easyList = new easyDataList();

    // Start is called before the first frame update
    void Start()
    {
        //qData = Resources.Load<TextAsset>("Resources/JsonText.txt");
        easyList = JsonUtility.FromJson<easyDataList>(JsonText.text);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
