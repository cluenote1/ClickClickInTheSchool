using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        foreach(KeyCode keycode in initKeyCodeArr)
        {
            CreateNoteGroup(keycode);
        }
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
        int randid = Random.Range(0, noteGroupList.Count);
        bool isApple = randid == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if(keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }
    }
}

