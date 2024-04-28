using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static int time = 0;
    public static int bestTime = 0;
    Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "BestTime : " + Score.time.ToString();
    }
}
