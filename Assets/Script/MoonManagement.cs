using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonManagement : MonoBehaviour
{
    [SerializeField] private List<Sprite> MoonShape;
    [SerializeField] private List<Material> MoonColor;
    [SerializeField] private float MoonShapeRandom = Random.Range(0, 3);
    [SerializeField] private float MoonColorRandom = Random.Range(0, 3);

    // Update is called once per frame
    void Update()
    {
        print(MoonShapeRandom + MoonColorRandom);
    }
}
