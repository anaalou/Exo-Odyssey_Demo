using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnHoverScript : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public string overrideText;

    void Start()
    {
        if (overrideText != string.Empty)
        {
            if (txt == null)
            {
                txt = GetComponent<TextMeshProUGUI>();
            }

            if (txt == null)
            {
                txt = GetComponentInChildren<TextMeshProUGUI>();
            }
        }
    }

    public void OnHover()
    {
        //Debug.Log($"{txt.text} ||| rnd{Random.Range(100, 1000)}");
        //
        if (GameManager.i.DescriptiveAudioOn)
        {
            if (overrideText != string.Empty)
            {
                TextToSpeechManager.instance.TextToSpeechReal(overrideText);
            }
            else if (txt != null)
            {
                TextToSpeechManager.instance.TextToSpeechReal(txt.text);
            }
        }
    }
}
