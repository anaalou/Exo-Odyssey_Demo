using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public List<Note> notes;
    public GameObject notePrefab;

    public void AddNote(string content, string title = "")
    {
        foreach (var note in notes)
        {
            //Debug.Log($"Note: {note.content}, new {content}");
            if (note.content == content && note.title == title)
            {
                return;
            }
        }

        GameObject sun = Instantiate(notePrefab, transform);
        Note n = sun.GetComponent<Note>();
        n.Format(title, content);
        notes.Add(n);
    }
}
