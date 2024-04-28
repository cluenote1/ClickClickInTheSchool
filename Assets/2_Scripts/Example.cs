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
        if (!isPause) //������
        {
            isPause = true;

            Time.timeScale = 0;
        }
        else //����
        {
            isPause = false;

            Time.timeScale = 1;
        }
    }
}
