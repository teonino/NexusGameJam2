using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManagement : MonoBehaviour
{
    public Music MusicSave;
    public Slider SliderMusic;
    public Slider SliderVoice;
    public Music musicScript;
    public Voice voiceScript;
    public AudioSource BackgroundMusic;
    public AudioSource VoiceVolume;
    public AudioClip TestVoiceLine;
  

    private void Start()
    {
        AudioListener.volume = SliderMusic.value;
        musicScript.MusicVolume = AudioListener.volume;
    }

    public void OnValueChangedBackgroundMusic()
    {
        musicScript.MusicVolume = SliderMusic.value;
        BackgroundMusic.volume = SliderMusic.value;
    }

    public void OnValueChangedVoiceMusic()
    {
        VoiceVolume.clip = TestVoiceLine;
        VoiceVolume.Play();
        voiceScript.VoiceVolume = SliderVoice.value;
        VoiceVolume.volume = SliderVoice.value;
    }

}
