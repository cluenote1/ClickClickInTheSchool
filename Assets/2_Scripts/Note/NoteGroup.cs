using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] protected GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject notegameObj = Instantiate(notePrefab);
            notegameObj.transform.SetParent(noteSpawn.transform);
            notegameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
            
            Note note = notegameObj.GetComponent<Note>();

            noteList.Add(note);
        }
    }

    void Update()
    {
        
    }
}
