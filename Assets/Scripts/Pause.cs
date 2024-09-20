using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Pause_Menu;
    // Start is called before the first frame update

    public void PauseGame()
    {
        Time.timeScale = 0;
        Pause_Menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause_Menu.SetActive(false);
    }
}
