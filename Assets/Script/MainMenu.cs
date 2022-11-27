using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject HowToPanel;
    public GameObject CreditsPanel;
    public GameObject MainPanel;
    public AudioSource MainMusic;
    public Slider SliderMusic;
    public Music musicScript;

    private void Start()
    {
        AudioListener.volume = SliderMusic.value;
        musicScript.MusicVolume = AudioListener.volume;
    }

    public void DisplayOptions()
    {
        OptionsPanel.SetActive(true);
        HowToPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(false);
    }
    public void DisplayHowToPlay()
    {
        OptionsPanel.SetActive(false);
        HowToPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(false);
    }

    public void DisplayCredits()
    {
        OptionsPanel.SetActive(false);
        HowToPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayMainMenu()
    {
        OptionsPanel.SetActive(false);
        HowToPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }


    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void OnValueChanged()
    {
        AudioListener.volume = SliderMusic.value;
        musicScript.MusicVolume = AudioListener.volume;
    }

}
