using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    [SerializeField] public AudioClip[] voiceline;
    private AudioSource AudioMenu;
    public float VoiceVolume;
    public Music musicScript;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioMenu = GetComponent<AudioSource>();
    }

    //AudioMenu.clip = music[AudioToPlay];
    //        AudioMenu.Play();


}
