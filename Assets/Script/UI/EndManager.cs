using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] Animator BlackscreenAnimator;
    [SerializeField] Animator VictoryAnimator;
    [SerializeField] Animator BackgroundAnimator;
    [SerializeField] List<Button> ButtonList;
    [SerializeField] List<Animator> buttonAnimator;
    [SerializeField] public MoonManagement SkillsManagement;
    [SerializeField] MoonManagement MoonScript;
    [SerializeField] GameObject BlackScreen;

    private void Start()
    {
        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].interactable = false;
        }
    }

    private void Update()
    {
        print(ButtonList[0].interactable);
    }

    public IEnumerator Victory()
    {
        yield return new WaitForSeconds(0.8f);
        BlackscreenAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(1.5f);
        BackgroundAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(1f);
        BlackScreen.SetActive(false);
        VictoryAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(0.5f);
        for (int i3 = 0; i3 < ButtonList.Count; i3++)
        {
            ButtonList[i3].interactable = true;
        }
        for (int i4 = 0; i4 < buttonAnimator.Count; i4++)
        {
            buttonAnimator[i4].SetTrigger("TriggerFade");
        }

        SkillsManagement.DisableAllSkills();
    }

    public IEnumerator Respawn()
    {
        
        BlackscreenAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Game");
        
    }

}
