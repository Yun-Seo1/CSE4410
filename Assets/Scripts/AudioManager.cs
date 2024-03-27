using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip DarkSouls;

    public void PlaySong(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
