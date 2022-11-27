using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public float MusicVolume;

    [SerializeField] public AudioClip[] music;
    private AudioSource AudioMenu;
    public int AudioToPlay = 0;

 

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioMenu = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!AudioMenu.isPlaying)
        {
            ChangeMusic();
        }
        MusicVolume = AudioMenu.volume;
    }

    public void ChangeMusic()
    {
        if (AudioToPlay == 2)
        {
            AudioMenu.clip = music[AudioToPlay];
            AudioMenu.Play();
            AudioToPlay = 0;
        }
        else
        {
            AudioMenu.clip = music[AudioToPlay];
            AudioMenu.Play();
            AudioToPlay += 1;
        }
    }


}
