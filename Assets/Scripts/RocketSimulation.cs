using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RocketSimulation : MonoBehaviour
{
    public float initialSpeed = 0f;
    public float acceleration = 10f;
    public float targetHeight = 100f; // Set the height at which to enable the GameObject
    private float currentSpeed;
    private bool isLaunching = false;

    public GameObject[] Effects;
    public GameObject objectToEnable; // Assign this in the Inspector

    private AudioSource audioSource; // Audio Source for launch sound

    [Header("Haptic Feedback Settings")]
    public InputActionReference leftHapticAction;
    public InputActionReference rightHapticAction;
    public float hapticIntensity = 1.0f;
    public float hapticDuration = 3.0f;

    private bool hasEnabledObject = false; // Prevent enabling multiple times

    void Start()
    {
        currentSpeed = initialSpeed;
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        // Get the AudioSource component attached to this GameObject
        audioSource = camera.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the Rocket! Please attach one.");
        }
    }

    void Update()
    {
        if (isLaunching)
        {
            currentSpeed += acceleration * Time.deltaTime;
            transform.position += Vector3.up * currentSpeed * Time.deltaTime;

            if (!hasEnabledObject && transform.position.y >= targetHeight)
            {
                EnableTargetObject();
                StopLaunch(); // Stop audio when target height is reached
            }
        }
    }

    private void EnableTargetObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
            hasEnabledObject = true; // Prevent repeated enabling
            Debug.Log("Target object enabled at height: " + transform.position.y);
        }
        else
        {
            Debug.LogError("No GameObject assigned to enable!");
        }
    }

    public void StartLaunch()
    {
        foreach(GameObject effect in Effects)
        {
            effect.SetActive(true);
        }
        isLaunching = true;
        StartCoroutine(TriggerHapticFeedback());

        // Play launch sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void StopLaunch()
    {
        isLaunching = false;

        // Stop the launch sound
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        Debug.Log("Launch stopped at target height.");
    }

    private System.Collections.IEnumerator TriggerHapticFeedback()
    {
        if (leftHapticAction != null)
        {
            leftHapticAction.action?.PerformInteractiveRebinding();
            leftHapticAction.action?.ReadValue<float>();
        }
        if (rightHapticAction != null)
        {
            rightHapticAction.action?.PerformInteractiveRebinding();
            rightHapticAction.action?.ReadValue<float>();
        }

        float elapsedTime = 0;
        while (elapsedTime < hapticDuration)
        {
            leftHapticAction.action?.ApplyBindingOverride("<XRController>/haptic");
            rightHapticAction.action?.ApplyBindingOverride("<XRController>/haptic");
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
