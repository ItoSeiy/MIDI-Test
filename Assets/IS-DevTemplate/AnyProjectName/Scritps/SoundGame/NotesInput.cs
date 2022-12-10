using UnityEngine;
using ISDevTemplate;

public class NotesInput : MonoBehaviour
{
    [SerializeField]
    KeyCode _inputKey = KeyCode.Mouse0; 

    private Notes _currentNotes;

    private void Update()
    {
        if (Input.GetKeyDown(_inputKey))
        {
            _currentNotes?.Input();
            _currentNotes = null;
        }
    }

    public void ChangeCurrentNotes(Notes notes)
    {
        _currentNotes = notes;
    }
}
