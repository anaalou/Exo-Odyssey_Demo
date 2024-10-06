using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AmbientSoundManager : MonoBehaviour
{
    private AudioSource track;
    public AudioClip song1;
    public AudioMixerGroup AmbientMixer;
    public static AmbientSoundManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    
        track = gameObject.AddComponent<AudioSource>();

        track.loop = true;

        track.outputAudioMixerGroup = AmbientMixer;

        track.clip = song1;
    }

    private void Start()
    {
        
    }

    public void PlayTrack(AudioClip newClip, float volume)
    {
        track.Stop();
        track.volume = volume;
        track.clip = newClip;
        track.Play();
    }




}
