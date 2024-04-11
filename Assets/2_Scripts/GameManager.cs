using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;

    private int score;
    private int nextNoteGroupUnlookCnt;

    [SerializeField] private float maxTime = 30f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TImerCoroutine());
    }

    IEnumerator TImerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;
        }
    }



    internal void CalculateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            nextNoteGroupUnlookCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlookCnt)
            {
                nextNoteGroupUnlookCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
        }else
        {
            score--;
        }

        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }
}
