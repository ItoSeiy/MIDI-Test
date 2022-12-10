using System.Collections;
using System.Collections.Generic;
using ISDevTemplate.Data;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField]
    private RangeValueStruct<float> _goodGudgeRange;

    [SerializeField]
    private RangeValueStruct<float> _perfectGudgeRange;

    [SerializeField]
    NotesInput _notesInput;

    public void Generate()
    {
        _notesInput.ChangeCurrentNotes(new Notes(_goodGudgeRange, _perfectGudgeRange));
    }
}
