using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;



    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;

    private int nextNoteGroupUnlookCnt;
    public float currentGameTime; // 메인 씬에서 기록한 현재 게임 시간
    public float bestTime; // 게임 클리어 씬에서 표시할 베스트 타임
    private bool isGameClear = false;
    private bool isGameOver = false;

    [SerializeField] private float maxTime = 30f;
    public static float myTime;
    public static float minTime;


    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
            {
                minTime = PlayerPrefs.GetFloat("minTime", 1000f);
                if (minTime >= myTime)
                {
                    minTime = myTime;
                    PlayerPrefs.SetFloat("minTime", minTime);
                }
                SceneManager.LoadScene(3);
                return true;

            }
            else
                return false;


        }
    }
    private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        ScoreManager.score = 0;

        UIManager.Instance.OnScoreChange(ScoreManager.score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TImerCoroutine());
        Instance = this;
    }

    IEnumerator TImerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            myTime += currentTime;
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
            ScoreManager.score++;
            nextNoteGroupUnlookCnt++;



            if (noteGroupCreateScore <= nextNoteGroupUnlookCnt)
            {
                nextNoteGroupUnlookCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (ScoreManager.score >= maxScore)
            {
                SceneManager.LoadScene(2);
                if (ScoreManager.score > ScoreManager.bestScore)
                {
                    ScoreManager.bestScore = ScoreManager.score;
                }
            }
        }
        else
        {
            ScoreManager.score--;


        }

        UIManager.Instance.OnScoreChange(ScoreManager.score, maxScore);


    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
