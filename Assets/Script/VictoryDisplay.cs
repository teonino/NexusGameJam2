using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDisplay : MonoBehaviour
{
    [SerializeField] Animator BlackscreenAnimator;

    private void Awake()
    {
        print("AwakeTriggered");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnEnable()
    {
        print("OnEnableTriggered");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("AnimLaunched");
        BlackscreenAnimator.SetTrigger("TriggerNotFade");
    }
}
