using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settings : MonoBehaviour
{
    public static settings instance;
    public AudioMixer audioMixer;
    public GameObject Settings;

    
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        
    }
    public void SetMusic(float volume)
    {

        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetSFX(float volume)
    {

        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
