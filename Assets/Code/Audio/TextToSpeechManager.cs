using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToSpeechManager : MonoBehaviour
{
    public static TextToSpeechManager instance;
    public AudioSource speaker;
    public bool dontInterrupt;
    public string prueba;


    private void Awake(){
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        speaker = Camera.main.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (dontInterrupt && speaker != null)
        {
            if (!speaker.isPlaying)
            {
                dontInterrupt = false;
            }
        }
    }

    public void TextToSpeechReal(string inputTextReal, bool dontInterrupt=false)
    {
        // Text to speech priority
        if (this.dontInterrupt)
        {
            return;
        }
        this.dontInterrupt = dontInterrupt;

        // Run text to speech
        RunJets.instance.inputText = inputTextReal;
        RunJets.instance.TextToSpeech();
    }
    

    
}

