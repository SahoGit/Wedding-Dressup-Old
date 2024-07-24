using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Threading;

public class SoundManager : MonoBehaviour
{

    #region Variables, Constants & Initializers

    public bool isTesting;
    public bool isSoundPlaying;

    public bool showDebugLogs;
    public GameObject bgSound;
    public AudioClip[] GPSounds;
    public AudioClip buttonclick;
    public AudioClip sparklevoice;
    public AudioClip cameravoice;
    public AudioClip dressSound;
    public AudioClip hairSound;
    public AudioClip niceColorSound;
    public AudioClip scoreSound;
    public AudioClip errorrSound;
    public AudioClip photoflip;
    public AudioClip characterAppear;

    public AudioClip playBtn;
    public AudioClip settingBtn;
    public AudioClip moregame;
    public AudioClip rateus;
    public AudioClip logo;
    public AudioClip playerWin;

    public AudioClip[] voices;
    public AudioClip[] sparkles;
    public AudioClip[] achivements;

    // persistant singleton
    private static SoundManager _instance;

    #endregion

    #region Lifecycle methods

    public static SoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        //Debug.Log("Awake Called");

        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(gameObject);
        }
    }

   public void PlayGPSound(int SoundIndex)
    {
        if(PlayerPrefs.GetInt("muted", 1) == 1) return;
        AudioSource source = bgSound.GetComponent<AudioSource>();

        source.clip = GPSounds[SoundIndex];
        source.loop = true;
        source.Play();
    }

    public void PlayAndPause(bool IsTrue)
    {
        AudioSource source = bgSound.GetComponent<AudioSource>();
        if (IsTrue) source.Play();
        else source.Pause();
    }
    void Start()
    {
        isSoundPlaying = true;

    }

    #endregion

    #region Utility Methods 

    public void playBtnSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(playBtn);
        }
            
    }
    public void playPhotoFlip()
    {
        if (PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(photoflip);
        }
    }

    public void settingBtnSound()
    {
        if (PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(settingBtn);
        }
    }

    public void errorSound()
    {
        if (PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(errorrSound);
        }
    }

    public void moregameSound()
    {
        if (PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(moregame);
        }
    }

    public void rateusSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(rateus);
        }
    }

    public void logoSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(logo);
        }
    }

    public void PlayPlayerWin()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(playerWin);
        }
        bgSound.GetComponent<AudioSource>().mute = true;
        Invoke("bgSoundPlay", 2.0f);
    }



    public void PlayButtonClickSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(buttonclick);
        }
    }

    public void PlayScoreAddSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(scoreSound);
        }
    }

    public void PlaysdressSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.Length - 1)]);
            gameObject.GetComponent<AudioSource>().PlayOneShot(dressSound);
        }
        bgSound.GetComponent<AudioSource>().mute = true;
        Invoke("bgSoundPlay", 1.0f);

    }

    public void PlayhairSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.Length - 1)]);
            gameObject.GetComponent<AudioSource>().PlayOneShot(hairSound);
        }
        bgSound.GetComponent<AudioSource>().mute = true;
        Invoke("bgSoundPlay", 1.0f);
    }

    public void PlayniceColorSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.Length - 1)]);
            gameObject.GetComponent<AudioSource>().PlayOneShot(niceColorSound);
        }
        bgSound.GetComponent<AudioSource>().mute = true;
        Invoke("bgSoundPlay", 1.0f);
    }

    public void PlayLipsSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            if (isSoundPlaying)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(niceColorSound);
                isSoundPlaying = false;
                bgSound.GetComponent<AudioSource>().mute = true;
                Invoke("bgSoundPlay", 1.0f);
                Invoke("isSoundPlayingInvoke", 4.0f);
            }
        }
        
    }

    public void PlayChecksSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            if (isSoundPlaying)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(niceColorSound);
                isSoundPlaying = false;
                bgSound.GetComponent<AudioSource>().mute = true;
                Invoke("bgSoundPlay", 1.0f);
                Invoke("isSoundPlayingInvoke", 4.0f);
            }
        }
        
    }

    public void PlayEyeLashSound()
    {
        if (PlayerPrefs.GetInt("SoundController") == 1)
        {
            if (isSoundPlaying)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(niceColorSound);
                isSoundPlaying = false;
                bgSound.GetComponent<AudioSource>().mute = true;
                Invoke("bgSoundPlay", 1.0f);
                Invoke("isSoundPlayingInvoke", 4.0f);
            }
        }
        
    }
    void isSoundPlayingInvoke()
    {
        isSoundPlaying = true;
    }

    public void PlaysparkleClickSound()
    {
        if (PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.Length - 1)]);
        }
        bgSound.GetComponent<AudioSource>().mute = true;
        Invoke("bgSoundPlay", 1.0f);
        Invoke("playSparkles", 0.5f);
    }

    void playSparkles()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(sparkles[Random.Range(0, sparkles.Length - 1)]);
        }
    }

    public void playEndSparkles()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.Length - 1)]);
        }
    }

    public void playCharacterAppear()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(characterAppear);
        }
    }

    public void PlaysparkleAchivementSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(achivements[Random.Range(0, achivements.Length - 1)]);
        }
            bgSound.GetComponent<AudioSource>().mute = true;
            Invoke("bgSoundPlay", 4.0f);
    }

    void bgSoundPlay()
    {
        bgSound.GetComponent<AudioSource>().mute = false;
    }

    public void PlaycameraClickSound()
    {
        if(PlayerPrefs.GetInt("SoundController") == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(cameravoice);
        }
    }

    #endregion

    #region Callback Methods 


    #endregion
}
