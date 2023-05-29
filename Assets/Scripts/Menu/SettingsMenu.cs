using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("musicVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectMixer.SetFloat("effectVolume", volume);
    }
}
