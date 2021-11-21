using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    void Start()
    {
        scoreValue += Convert.ToInt32(System.IO.File.ReadAllText("E:/Save/scorevalue.txt"));
        score = GetComponent<Text>();
    }
    
    void Update()
    {
        score.text = "Currency: " + scoreValue / 1000;
        
    }
}
