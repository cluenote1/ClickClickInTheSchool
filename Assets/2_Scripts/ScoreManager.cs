using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTmp;
    public TextMeshProUGUI bestScoreTmp;
    public static int score;
    public static int bestScore;
    

    private void Start()
    {
        scoreTmp.text = $"Score : {score}";
        bestScoreTmp.text = $"Best Score : {bestScore}";
        
        
       
    }

    void Update()
    {
        
    }
}
