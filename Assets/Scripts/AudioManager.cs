using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    AudioSource audioSource;
    public void MusicVolume(int value)
    {
        audioSource.volume = value;
    }
}
