using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Pause_Menu;

    public bool isGamePaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0;
        Pause_Menu.SetActive(true);
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause_Menu.SetActive(false);
        isGamePaused = false;
    }
}
