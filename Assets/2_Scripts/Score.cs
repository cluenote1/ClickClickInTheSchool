using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int time = 0;
    public static int bestTime = 0;
    Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        time = 0;
    }

    void Update()
    {
        uiText.text = time.ToString();
    }




}
