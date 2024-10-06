using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public string title;
    public string content;

    public void Format(string title, string content)
    {
        this.title = title;
        this.content = content;
        if (title != string.Empty)
        {
            txt.text = $"{title}: {content}";
        }
        else
        {
            txt.text = content;
        }

        if (GameManager.i.DescriptiveAudioOn)
        {
            TextToSpeechManager.instance.TextToSpeechReal(txt.text, true);
        }
    }
}
