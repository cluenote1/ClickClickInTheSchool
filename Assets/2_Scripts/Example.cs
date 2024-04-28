using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    bool isPause = false;

    void Awake()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (!isPause) //정지됨
        {
            isPause = true;

            Time.timeScale = 0;
        }
        else //해제
        {
            isPause = false;

            Time.timeScale = 1;
        }
    }
}
