using UnityEngine;

public class SeparationSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySeparationSound()
    {
        if (audioSource != null)
            audioSource.Play();
    }
}
