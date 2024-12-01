using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sfxSounds;
    public Sound[] bgSounds;
    public static AudioManager instance;
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
            sound.audioSource.volume = sound.volumn;
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
            sound.audioSource.volume = sound.volumn;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.mute = sound.mute;

        }
    }

    public void Start()
    {
        //curScene = SceneManager.GetActiveScene().buildIndex;
        //this.PlayBackgroundSound("MenuBackground");
        curScene = "MainMenu";
        curBackgroundSound = "MenuBackground";
        this.PlayBackgroundSound("MenuBackground");
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex==1 || SceneManager.GetActiveScene().buildIndex == 6)
            return;
        if (curScene != SceneManager.GetActiveScene().name)
        {
            curScene = SceneManager.GetActiveScene().name;
            //Debug.Log(curScene);
            //Debug.Log(SceneManager.GetActiveScene().buildIndex);
            this.MuteSound(curBackgroundSound);
            if (curScene == "MainMenu")
            {
                this.PlayBackgroundSound("MenuBackground");
                curBackgroundSound = "MenuBackground";

            }
            else if (curScene == "Level0")
            {
                this.PlayBackgroundSound("Level0Background");
                curBackgroundSound = "Level0Background";
            }
            else if (curScene == "Level1")
            {

                this.PlayBackgroundSound("Level1Background");
                curBackgroundSound = "Level1Background";

            }
            else if (curScene == "Level2")
            {
                this.PlayBackgroundSound("Level2Background");
                curBackgroundSound = "Level2Background";

            }
            else if (curScene == "Level3")
            {
                this.PlayBackgroundSound("Level3Background");
                curBackgroundSound = "Level3Background";

            }
        }
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
}
