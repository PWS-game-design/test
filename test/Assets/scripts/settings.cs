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

        audioMixer.SetFloat("volume", volume);
        
    }
    public void SetMusic(float volume)
    {

        audioMixer.SetFloat("Music", volume);
    }
    public void SetSFX(float volume)
    {

        audioMixer.SetFloat("SFX", volume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
