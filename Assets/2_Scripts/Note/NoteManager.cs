using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodeArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, 
        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodeArr[i]);
        }
    }
    public void CreateNoteGroup()
    {
        if (wholeKeyCodeArr.Length == noteGroupList.Count)
            return;

        KeyCode keyCode = this.wholeKeyCodeArr[noteGroupList.Count];
        CreateNoteGroup(keyCode);
    }
    public void CreateNoteGroup(KeyCode keycode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keycode);

        noteGroupList.Add(noteGroup);
    }

    public void  OnInput(KeyCode keyCode)
    {
        int randid = Random.Range(0, 2);
        bool isApple = randid == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if(keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }
    }
}

