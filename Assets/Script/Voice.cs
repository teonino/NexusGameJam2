using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    [SerializeField] public AudioClip[] Technicalvoiceline;
    [SerializeField] public AudioClip[] Introvoiceline;
    [SerializeField] public AudioClip[] Moonvoiceline;
    private AudioSource AudioMenu;
    public float VoiceVolume;
    public Music musicScript;
    public MoonManagement MoonRef;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioMenu = GetComponent<AudioSource>();
    }



    public IEnumerator introVoiceLine()
    {
        AudioMenu.clip = Introvoiceline[0];
        AudioMenu.Play();
        yield return new WaitForSeconds(7.2f);
    }

    public void MoonSkillsVoiceLine()
    {
        AudioMenu.clip = Moonvoiceline[MoonRef.MoonShapeRandom];
        AudioMenu.Play();
    }



}
