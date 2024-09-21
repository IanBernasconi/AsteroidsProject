using UnityEngine;

public class PauseController : MonoBehaviour
{
    public Pause pauseScript;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScript.isGamePaused)
            {
                pauseScript.ResumeGame();
            }
            else
            {
                pauseScript.PauseGame();
            }
        }
    }
}