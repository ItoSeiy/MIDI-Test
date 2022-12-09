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

    private List<Notes> _generatedNotes = new List<Notes>();

    private Notes _currentNotes;

    public void Generate()
    {
        _generatedNotes.Add(new Notes(_goodGudgeRange, _perfectGudgeRange));
    }
}
