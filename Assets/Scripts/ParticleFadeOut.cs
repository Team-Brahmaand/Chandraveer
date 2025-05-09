using UnityEngine;
using System.Collections;

public class ParticleFadeOut : MonoBehaviour
{
    public ParticleSystem particleSystem; // Assign your Particle System in the Inspector
    public float delay = 2f; // Time before fade-out starts
    public float fadeDuration = 5f; // Time taken to fade out particles

    private ParticleSystem.MainModule mainModule;
    private int initialMaxParticles;

    private void Start()
    {
        if (particleSystem != null)
        {
            mainModule = particleSystem.main;
            initialMaxParticles = mainModule.maxParticles;
            StartCoroutine(FadeOutParticles());
        }
    }

    private IEnumerator FadeOutParticles()
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float progress = elapsedTime / fadeDuration;
            mainModule.maxParticles = Mathf.RoundToInt(Mathf.Lerp(initialMaxParticles, 0, progress));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainModule.maxParticles = 0; // Ensure it reaches 0
    }
}
