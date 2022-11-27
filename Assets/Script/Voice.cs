using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    [SerializeField] public AudioClip[] Technicalvoiceline;
    [SerializeField] public AudioClip[] Introvoiceline;
    [SerializeField] public AudioClip[] Moonvoiceline;
    private AudioSource AudioMenu;
    public float VoiceVolume = 1;
    public Music musicScript;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioMenu = GetComponent<AudioSource>();
    }

    public IEnumerator Intro()
    {
        AudioMenu.clip = Introvoiceline[0];
        AudioMenu.Play();
        yield return new WaitForSeconds(9f);
        AudioMenu.clip = Technicalvoiceline[4];
        AudioMenu.Play();
    }



}
