using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequentialAudioPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips; // List of audio clips to play in sequence
    public List<int> triggerIndices;  // Indices of audio clips after which functions are triggered
    public List<float> delays;        // List of delays (in seconds) between audio clips

    private AudioSource audioSource;
    private bool isPlaying = false; // Ensure only one sequence plays at a time

    public RocketSimulation rocketSimulationScript;
    public CountdownTimer countdownTimerScript;

    void Awake()
    {
        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (rocketSimulationScript == null)
        {
            // Find Rocket GameObject and get the RocketSimulation script from it
            GameObject rocketObject = GameObject.FindGameObjectWithTag("Rocket");
            if (rocketObject != null)
            {
                rocketSimulationScript = rocketObject.GetComponent<RocketSimulation>();
            }
            else
            {
                Debug.LogError("Rocket GameObject not found!");
            }
        }

        if (countdownTimerScript == null)
        {
            // Find Countdown Timer script in the scene
            countdownTimerScript = FindObjectOfType<CountdownTimer>();
            if (countdownTimerScript == null)
            {
                Debug.LogError("CountdownTimer script not found in the scene!");
            }
        }
    }

    // Public function to start the audio sequence
    public void StartAudioSequence()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayAudioSequence());
        }
    }

    private IEnumerator PlayAudioSequence()
    {
        isPlaying = true;

        for (int i = 0; i < audioClips.Count; i++)
        {
            if (audioClips[i] == null) continue;

            if (triggerIndices.Contains(i))
            {
                TriggerFunction(i); // Call function before playing the audio
            }

            // Play the current audio clip
            audioSource.clip = audioClips[i];
            audioSource.Play();

            // Wait until the audio clip finishes
            yield return new WaitForSeconds(audioSource.clip.length);

            if (i == 5)
            {
                StartRocketLaunch();
            }

            // Add delay if specified
            if (i < delays.Count && delays[i] > 0)
            {
                yield return new WaitForSeconds(delays[i]);
            }
        }

        isPlaying = false;

        Debug.Log("All audio clips have finished playing.");
    }


    private void TriggerFunction(int audioIndex)
    {
        // Call your custom functions here based on the audioIndex
        switch (audioIndex)
        {
            case 5:
                StartCountdown();
                break;
            // case 6:
            //     StartRocketLaunch();
            //     break;
            default:
                Debug.Log($"Triggered function after audio index: {audioIndex}");
                break;
        }
    }

    private void StartCountdown()
    {
        if (countdownTimerScript != null)
        {
            countdownTimerScript.StartCountdown();
            Debug.Log("Countdown started!");
        }
        else
        {
            Debug.LogError("CountdownTimer script is not assigned!");
        }
    }

    private void StartRocketLaunch()
    {
        if (rocketSimulationScript != null)
        {
            rocketSimulationScript.StartLaunch(); // Trigger the StartLaunch function from RocketSimulation script
        }
        else
        {
            Debug.LogError("RocketSimulation script is not assigned!");
        }
    }

    // Example functions to be triggered
    private void FunctionForAudio1()
    {
        Debug.Log("Function triggered after Audio 1.");
        // Your custom logic here
    }

    private void FunctionForAudio3()
    {
        Debug.Log("Function triggered after Audio 3.");
        // Your custom logic here
    }
}
