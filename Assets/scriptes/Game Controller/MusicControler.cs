using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    public static MusicControler instance;
    private AudioSource audiosource;

    void Awake()
    {
        MakeSingleton();
        audiosource = GetComponent<AudioSource>();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
            else
            {
                if (audiosource.isPlaying)
                {
                    audiosource.Stop();
                }
            }
        }
    }
}
