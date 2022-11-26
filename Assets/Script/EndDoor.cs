using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndDoor : MonoBehaviour
{
    [SerializeField] Animator BlackscreenAnimator;
    [SerializeField] Animator TextAnimator;
    [SerializeField] List<Button> ButtonList;
    [SerializeField] List<Animator> buttonAnimator;
    [SerializeField] public MoonManagement SkillsManagement;

    private void Start()
    {
        for(int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].interactable = false;
        }
    }

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
        yield return new WaitForSeconds(0.5f);
        for (int i3 = 0; i3 < ButtonList.Count; i3++)
        {
            ButtonList[i3].interactable = true;
            for(int i2 = 0; i2 < buttonAnimator.Count; i2++)
            {
                yield return new WaitForSeconds(0.3f);
                buttonAnimator[i2].SetTrigger("TriggerFade");
            }

        }
        SkillsManagement.DisableAllSkills();
    }

}
