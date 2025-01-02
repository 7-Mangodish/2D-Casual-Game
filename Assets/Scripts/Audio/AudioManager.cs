using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sfxSounds;
    public Sound[] bgSounds;

    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    public string curScene;
    public string curBackgroundSound;
    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Second AudioManager is initiated");
            Destroy(gameObject);
            return;
        }
        //Debug.Log(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        foreach(Sound sound in sfxSounds)
        {
            sound.audioSource = this.gameObject.AddComponent<AudioSource>();

            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.name = sound.name;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.volume = sound.volumn = 0.4f;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.mute = sound.mute;
        }

        foreach (Sound sound in bgSounds)
        {
            sound.audioSource = this.gameObject.AddComponent<AudioSource>();

            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.name = sound.name;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.volume = sound.volumn =0.4f;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.mute = sound.mute;

        }


    }

    public void Start()
    {
        curScene = "MainMenu";
        curBackgroundSound = "MenuBackground";
        this.PlayBackgroundSound("MenuBackground");
    }

    public void Update()
    {        
        
    }

    public void PlaySfx(string name)
    {
        Sound res = null;
        foreach (Sound sound in sfxSounds)
        {
            if (sound.name == name)
            {
                res = sound;
                break;
            }
        }
        if(res == null)
        {
            Debug.Log("Sound" + name + "Not found");
            return;
        }
        else
        {
            res.audioSource.Play();
        }
    }

    public void PlayBackgroundSound(string name)
    {
        Sound res = null;
        //Debug.Log(name);
        foreach (Sound sound in bgSounds)
        {
            if (sound.name == name)
            {
                res = sound;
                break;
            }
        }
        if (res == null)
        {
            Debug.Log("Sound" + name + "Not found");
            return;
        }
        else
        {
            res.audioSource.Play();
        }
    }

    public void MuteSound(string name)
    {
        Sound res = null;
        //Debug.Log(name);
        foreach (Sound sound in bgSounds)
        {
            if (sound.name == name)
            {
                res = sound;
                break;
            }
        }
        if (res == null)
        {
            Debug.Log("Sound" + name + "Not found");
            return;
        }
        else
        {
            res.audioSource.mute = true;
        }
    }

    public void UpdateVolumn(string str, float volumn)
    {
        if(str == "music")
        {
            foreach (Sound sound in bgSounds)
            {
                sound.audioSource.volume = volumn;
            }
        }
        else if(str == "sfx")
        {
            foreach (Sound sound in sfxSounds)
            {
                sound.audioSource.volume = volumn;
            }
        }

    }
}
