using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMap : MonoBehaviour
{
    public AudioSource[] BGmusic;
    public AudioSource[] SFX;

    public static AudioMap instance;
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playsfx(int sfxToPlay)
    {
        if(sfxToPlay < SFX.Length)
        {
            SFX[sfxToPlay].Play();
        }
        
    }
    public void playBGM(int musicToPlay)
    {
        if (!BGmusic[musicToPlay].isPlaying)
        {
            StopMusic();

            if (musicToPlay < BGmusic.Length)
            {
                BGmusic[musicToPlay].Play();
            }
        }

        
    }

    public void StopMusic()
    {
        for(int i=0; i<BGmusic.Length; i++)
        {
            BGmusic[i].Stop();
        }
    }
}
