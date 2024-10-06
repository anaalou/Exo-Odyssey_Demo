using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioClip[] MenuClips;
    [SerializeField] private AudioClip[] AmbientClips;
    [SerializeField] private AudioClip[] GameFlowClips;


    private AudioSource audioSource;


    private void Awake(){
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    //Funciones para efectos de sonidos

    //Ambient
    public void PlayLavaLoop()
    {
        AmbientSoundManager.instance.PlayTrack(AmbientClips[0], 1f);
    }

    public void PlanetSelectSong()
    {
        AmbientSoundManager.instance.PlayTrack(AmbientClips[1], 0.2f);
    }

    public void PlayWhiteAmbientSound()
    {
        AmbientSoundManager.instance.PlayTrack(AmbientClips[2], 1f);
    }

    //Menu
    public void PlayMenu1()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(MenuClips, transform, 1f,0);
    }

    public void PlayMenu2()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(MenuClips, transform, 1f,1);
    }

    public void PlayMenu3()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(MenuClips, transform, 1f,2);
    }

    public void PlayMenuSelect()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(MenuClips, transform, 1f,3);
    }


    // Game Flow effects
    public void PlayAlarm()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(GameFlowClips, transform, 1f,0);
    }

    public void PlayNaveDeriva()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(GameFlowClips, transform, 1f,1);
    }

    public void PlayBeep()
    {
        SoundFXManager.instance.PlaySpecificSoundFXClip(GameFlowClips, transform, 1f,2);
    }



}
