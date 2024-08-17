using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreShow : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI score;
    Score s;
    
    void Awake()
    {
        
        s = GameObject.Find("ScoreManager").GetComponent<Score>();
        timer.text = ("You Survived " + (int)s.time + " seconds!").ToString();
        score.text = ("Your score was " +  s.score).ToString();
    }


}
