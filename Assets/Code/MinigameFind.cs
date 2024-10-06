using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFind : MonoBehaviour
{
    public Vector2 pos;
    float timer = 0;
    float timerGoal = 0.5f;
    public bool gameOn;
    public string finding;
    public AudioSource ttsSpeaker;

    private void Start()
    {
        pos = new Vector2(Random.Range(-6f, 6f), Random.Range(-1, 4f));
        ttsSpeaker = Camera.main.gameObject.GetComponent<AudioSource>(); // Get the audio speaker of the text to speech
        TextToSpeechManager.instance.TextToSpeechReal("Move the mouse and click where the sound is faster");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn)
        {
            timer += Time.deltaTime;
            timerGoal = CalculateTime();

            if (Input.GetMouseButtonDown(0))
            {
                if (timerGoal <= 0.15f)
                {
                    Win();
                }
            }

            if (timer > timerGoal)
            {
                timer = 0;
                Beep();
            }
        }
        else
        {
            if (!ttsSpeaker.isPlaying)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Calculate time between beeps
    public float CalculateTime()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get Mouse Position
        float d = Vector2.Distance(p, pos) * 0.11f; // Scale time in function of distance between mouse & target
        return Mathf.Max(Mathf.Min(d, 1f), 0.125f); // Cap time bewteen 0.2s and 1s
    }

    public void Win()
    {
        GameManager.i.noteSystem.AddNote(finding);
        gameOn = false;
        timer = 3f;
        Destroy(gameObject);
    }

    // Play Sound
    public void Beep()
    {
        AudioManager.instance.PlayBeep();
    }
}
