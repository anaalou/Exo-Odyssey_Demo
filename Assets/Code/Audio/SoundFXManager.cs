using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///SFX DE MENÚ NO ES LICENCIA COMERCIAL!!!!!!!!! 


public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake(){
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Assign audiolcip
        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get lenght of sound FX clip
        float clipLength = audioSource.clip.length;

        //destroy clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);

    }


    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //Assign random index
        int rand = Random.Range(0, audioClip.Length);

        //spawn gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Assign audiolcip
        audioSource.clip = audioClip[rand];

        //Assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get lenght of sound FX clip
        float clipLength = audioSource.clip.length;

        //destroy clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);

    }

     public void PlaySpecificSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume, int index)
    {

        //spawn gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Assign audiolcip
        audioSource.clip = audioClip[index];

        //Assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get lenght of sound FX clip
        float clipLength = audioSource.clip.length;

        //destroy clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);

    }
}

