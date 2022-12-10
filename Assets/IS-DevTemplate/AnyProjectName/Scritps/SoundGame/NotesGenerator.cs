using System;
using System.Collections;
using System.Collections.Generic;
using ISDevTemplate.Data;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField]
    private RangeValueStruct<double> _goodGudgeRange = new RangeValueStruct<double>(0.1, 1.1);

    [SerializeField]
    private RangeValueStruct<double> _perfectGudgeRange = new RangeValueStruct<double>(0.05, 1.05);

    [SerializeField]
    NotesInput _notesInput;

    public void Generate()
    {
        _notesInput.ChangeCurrentNotes(new Notes(_goodGudgeRange, _perfectGudgeRange));
    }
}
