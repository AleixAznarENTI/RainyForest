using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;
    // Start is called before the first frame update

    private void Start()
    {
        PlayMusic("MenuSong");
    }
    public void PlayMusic(string name)
    {
        AudioSound s = Array.Find(musicSound, x => x.Name == name);
        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }
    }

    
    public void PlaySFX(string name)
    {
        AudioSound s = Array.Find(sfxSounds, x => x.Name == name);

        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume= volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
