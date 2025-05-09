using UnityEngine;

public class ExitAfterDelay : MonoBehaviour
{
    public float delay = 5f; // Default delay of 5 seconds

    void Start()
    {
        if (delay > 0)
        {
            Invoke(nameof(QuitApplication), delay);
        }
        else
        {
            Debug.LogError("Delay must be greater than 0!");
        }
    }

    void QuitApplication()
    {
        Debug.Log("Quitting application...");

        // Quit the application (works only in a build)
        Application.Quit();

        // If running in the Unity Editor, stop play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
