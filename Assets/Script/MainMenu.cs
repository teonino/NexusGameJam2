using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.Loadscene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
