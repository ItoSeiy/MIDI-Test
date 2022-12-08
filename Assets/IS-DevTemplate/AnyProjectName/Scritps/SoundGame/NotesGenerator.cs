using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    private List<Notes> _generatedNotes = new List<Notes>();

    private Notes _currentNotes;

    public void Generate()
    {
        _generatedNotes.Add(new Notes());
    }
}
