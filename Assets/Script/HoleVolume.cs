using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleVolume : MonoBehaviour
{
    [SerializeField] public EndManager EndManage;


    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EndManage.Respawn();
        }
    }
}
