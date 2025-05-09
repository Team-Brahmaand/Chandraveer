using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to play in sequence
    private AudioSource audioSource; // Reference to the AudioSource component
    private int currentClipIndex = 0; // Tracks the current clip being played

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure there are clips to play
        if (audioClips.Length > 0 && audioSource != null)
        {
            StartCoroutine(PlayAudioClips());
        }
        else
        {
            Debug.LogWarning("No audio clips assigned or AudioSource missing.");
        }
    }

    // Coroutine to play audio clips sequentially
    private IEnumerator PlayAudioClips()
    {
        while (currentClipIndex < audioClips.Length)
        {
            // Assign the current audio clip to the AudioSource
            audioSource.clip = audioClips[currentClipIndex];

            // Play the current clip
            audioSource.Play();

            // Wait until the current clip finishes
            yield return new WaitForSeconds(audioSource.clip.length);

            // Move to the next clip
            currentClipIndex++;
        }
    }
}
