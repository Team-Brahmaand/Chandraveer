using UnityEngine;

public class DisableAnimationForTime : MonoBehaviour
{
    public Animator animator; // Assign the Animator component in Inspector
    public float disableDuration = 36f; // Duration to disable the animation

    void Start()
    {

        if (animator == null)
            animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.enabled = false; // Disable animation
            Invoke("EnableAnimation", disableDuration); // Enable it back after time
        }
    }

    void EnableAnimation()
    {
        if (animator != null)
        {
            animator.enabled = true; // Enable animation
            Debug.Log("Animation re-enabled after " + disableDuration + " seconds.");
        }
    }
}