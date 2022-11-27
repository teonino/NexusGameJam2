using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoonManagement : MonoBehaviour
{
    [SerializeField] internal GameObject MoonObject;
    [SerializeField] internal List<Material> MoonShape;
    private Renderer PlaneMaterial;
    public int MoonShapeRandom;
    [SerializeField] public HoleVolume Blackhole;
    [SerializeField] public List<bool> SkillsAccess;
    //0 -> Dash
    //1 -> Jump
    //2 -> Slide
    public Voice VoiceScript;
    internal int i = 0;

    private void Start()
    {
        PlaneMaterial = MoonObject.GetComponent<Renderer>();
        PlaneMaterial.enabled = true;
        GenerateShapeAndColors();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GenerateShapeAndColors(); 
        }
        if(VoiceScript == null)
        {
            VoiceScript = GameObject.Find("VoiceMusic").GetComponent<Voice>();
        }

    }

    internal void GenerateShapeAndColors()
    {
        if(MoonShapeRandom == 2)
        {
            MoonShapeRandom = 0;
        }
        else
        {
            MoonShapeRandom += 1;
        }



        for(int i = 0; i < SkillsAccess.Count; i++)
        {
            SkillsAccess[i] = false;
        }

        SkillsAccess[MoonShapeRandom] = true;
        PlaneMaterial.sharedMaterial = MoonShape[MoonShapeRandom];
        Blackhole.EndTime -= 5f;

        VoiceScript.MoonSkillsVoiceLine();
        print("MoonShapeRandom :" + MoonShapeRandom);

       
    }

    public void DisableAllSkills()
    {
        for (int i = 0; i < SkillsAccess.Count; i++)
        {
            SkillsAccess[i] = false;
        }
    }

}
