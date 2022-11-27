using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] Animator BlackscreenAnimator;
    [SerializeField] Animator VictoryAnimator;
    [SerializeField] Animator GameOverAnimator;
    [SerializeField] List<Button> ButtonList;
    [SerializeField] List<Animator> buttonAnimator;
    [SerializeField] public MoonManagement SkillsManagement;
    [SerializeField] MoonManagement MoonScript;

    private void Start()
    {
        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].interactable = false;
        }
    }

    public IEnumerator Victory()
    {
        yield return new WaitForSeconds(0.8f);
        BlackscreenAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(1.5f);
        VictoryAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(0.5f);
        for (int i3 = 0; i3 < ButtonList.Count; i3++)
        {
            ButtonList[i3].interactable = true;
            for (int i2 = 0; i2 < buttonAnimator.Count; i2++)
            {
                yield return new WaitForSeconds(0.3f);
                buttonAnimator[i2].SetTrigger("TriggerFade");
            }

        }
        SkillsManagement.DisableAllSkills();
    }
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.8f);
        BlackscreenAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(1.5f);
        GameOverAnimator.SetTrigger("TriggerFade");
        yield return new WaitForSeconds(0.5f);
        for (int i3 = 0; i3 < ButtonList.Count; i3++)
        {
            ButtonList[i3].interactable = true;
            for (int i2 = 0; i2 < buttonAnimator.Count; i2++)
            {
                yield return new WaitForSeconds(0.3f);
                buttonAnimator[i2].SetTrigger("TriggerFade");
            }

        }
        SkillsManagement.DisableAllSkills();
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.8f);
        BlackscreenAnimator.SetTrigger("TriggerFade");
        SceneManager.LoadScene("Game");
        
    }

}
