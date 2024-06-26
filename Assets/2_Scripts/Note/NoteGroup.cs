using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab ;
    [SerializeField] protected GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private Animation anim;
    private AudioSource didguswns;

    public AnimationClip spawnAnim;
    public AnimationClip btnAnim;
    
   
    private void Start()
    {
        anim.clip = spawnAnim;
        anim.Play();
        anim.clip = btnAnim;
        
        
    }

    private KeyCode keyCode;
    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }
    private List<Note> noteList = new List<Note>();

    public void Create(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        keyCodeTmp.text = keyCode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }

        InputManager.Instance.AddKeyCode(keyCode);
    }

    private void CreateNote(bool isApple)
    {
        GameObject notegameObj = Instantiate(notePrefab);
        notegameObj.transform.SetParent(noteSpawn.transform);
        notegameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
        Note note = notegameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    internal void OnInput(bool isApple)
    {
        //노트 삭제
        if (noteList.Count > 0)
        {
            Note delNote = noteList[0];
            delNote.GiveScoreAndDeleteNote();
            noteList.RemoveAt(0);
        }
        
        
        //줄 내려오기
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //생성
        CreateNote(isApple);

        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;



        //키보드 반짝
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
        
        
    }

    public void CallAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
