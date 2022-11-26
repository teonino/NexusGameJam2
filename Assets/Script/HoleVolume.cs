using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleVolume : MonoBehaviour
{
    [SerializeField] private PlayerInput Input;

    private void Update()
    {
        if(Input == null)
        {
            print("Player input pas d�tecter");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("entr� dans le collider");
        if(other.gameObject.tag == "Player")
        {
            if(Input.HaveBoots)
            {
                print("tu a des boots tu meurs pas");
            }
            else
            {
                print("GAME OVER");
            }
        }
    }
}
