using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    [SerializeField] Animator BlackscreenAnimator;
    [SerializeField] Animator TextAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Joueur dans trigger");
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.8f);
        BlackscreenAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(1.5f);
        TextAnimator.SetTrigger("TriggerFade");
    }

}
