using System;
using System.Collections;
using System.Collections.Generic;
using ISDevTemplate.Data;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField]
    private double _beforeGoodGudgeEndTime = 0.1;

    [SerializeField]
    private double _perfectGudgeEndTime = 0.05;

    [SerializeField]
    private double _afterGoodGudgeEndTime = 0.1;

    [SerializeField]
    NotesInput _notesInput;

    public void Generate()
    {
        _notesInput.ChangeCurrentNotes(new Notes(_beforeGoodGudgeEndTime, _perfectGudgeEndTime, _afterGoodGudgeEndTime));
    }
}
