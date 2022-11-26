using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoonManagement : MonoBehaviour
{
    [SerializeField] internal GameObject MoonObject;
    [SerializeField] internal List<Material> MoonShape;
    [SerializeField] internal List<Color> MoonColor;
    private Renderer PlaneMaterial;
    private int MoonShapeRandom;
    private int MoonColorRandom;
    [SerializeField] public List<bool> SkillsAccess;
    //0 -> Dash
    //1 -> Jump
    //2 -> Slide
    public TextMeshProUGUI BannedText;
    public TextMeshProUGUI AllowedText;
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
            i += 1;
            GenerateShapeAndColors(); 
        }

    }

    internal void GenerateShapeAndColors()
    {
        MoonShapeRandom = Random.Range(0, 3);
       MoonColorRandom = Random.Range(0, 3);
        while (MoonShapeRandom == MoonColorRandom)
        {
            Debug.LogWarning("Same Value Detected And changed");
            MoonColorRandom = Random.Range(0, 3);
        }

        for(int i = 0; i < SkillsAccess.Count; i++)
        {
            SkillsAccess[i] = false;
        }

        SkillsAccess[MoonShapeRandom] = true;
        SkillsAccess[MoonColorRandom] = false;
        PlaneMaterial.sharedMaterial = MoonShape[MoonShapeRandom];
        PlaneMaterial.sharedMaterial.color = MoonColor[MoonColorRandom];
        

        print("----- TEST " + i + "-----");
        print("MoonShapeRandom :" + MoonShapeRandom);
        print("MoonColorRandom :" + MoonColorRandom);
        print("-------------------");
        BannedText.text = "Banned Skills: " + MoonColorRandom;
        AllowedText.text = "Allowed Skills: " + MoonShapeRandom;
    }

    public void DisableAllSkills()
    {
        for (int i = 0; i < SkillsAccess.Count; i++)
        {
            SkillsAccess[i] = false;
        }
    }

}
