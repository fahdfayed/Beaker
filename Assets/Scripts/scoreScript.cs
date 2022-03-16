using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public static scoreScript instance;
    public Text scoreText;
    public int score = 0;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString();
        
    }

    // Update is called once per frame
    public  void addPoint(){
        score += 1;
        scoreText.text = score.ToString();
    }
    
    public void Setup(int score)
    {
        scoreText.text = score.ToString();
    }
}
