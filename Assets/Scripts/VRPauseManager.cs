using UnityEngine;

public class VRPauseManager : MonoBehaviour
{

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseSimulation()
    {
        Time.timeScale = 0;
    }

    public void ResumeSimulation()
    {
        Time.timeScale = 1;
    }

    public void QuitApplication()
    {
        Debug.Log("Exiting application.");
        Application.Quit();
    }
}
