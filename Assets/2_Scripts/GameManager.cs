using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;
    private int score;
    private int nextNoteGroupUnlookCnt;
    public float currentGameTime; // ���� ������ ����� ���� ���� �ð�
    public float bestTime; // ���� Ŭ���� ������ ǥ���� ����Ʈ Ÿ��
    

    [SerializeField] private float maxTime = 30f;

    
    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else
                return false;
        }
    }
    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);

        StartCoroutine(TImerCoroutine());

        Instance = this;
        
    }

    IEnumerator TImerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        SceneManager.LoadScene(3);
        
    }



    internal void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlookCnt++;

            

            if (noteGroupCreateScore <= nextNoteGroupUnlookCnt)
            {
                nextNoteGroupUnlookCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

             if (score >= maxScore)
            {
                SceneManager.LoadScene(2);
                Score.bestTime = Score.time;
            }
        }else
        {
            score--;

            
        }
        
        UIManager.Instance.OnScoreChange(this.score, maxScore);

        
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
