using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndDoor : MonoBehaviour
{
    public EndManager EndManagement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Joueur dans trigger");
            StartCoroutine(EndManagement.Victory());
        }
    }

   

}
