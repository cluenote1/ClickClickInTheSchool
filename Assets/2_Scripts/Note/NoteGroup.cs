using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] protected GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private Animation anim;
    [SerializeField] private KeyCode keyCode;
    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }
    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
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
            noteList[0].DeleteNote();
            noteList.RemoveAt(0);
        }
        
        
        //줄 내려오기
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //생성
        CreateNote(isApple);

        //키보드 반짝
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
        
        
    }

    public void CallAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
