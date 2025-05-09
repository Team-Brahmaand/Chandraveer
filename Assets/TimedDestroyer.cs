using UnityEngine;

public class TimedDeactivator : MonoBehaviour
{
    // Public GameObjects to deactivate and reactivate
    public GameObject object1; // Deactivate at 15 seconds
    public GameObject object2; // Deactivate at 17 seconds
    public GameObject object3; // Deactivate at 17 seconds
    public GameObject object4; // Deactivate at 25 seconds

    // Animation playback times (in seconds)
    private float deactivateTime1 = 15f;
    private float deactivateTime2 = 17f;
    private float deactivateTime4 = 25f;

    // Duration of the animation (in seconds)
    public float animationDuration = 30f;

    private float animationStartTime;

    void Start()
    {
        // Record the time the animation starts playing
        animationStartTime = Time.time;
    }

    void Update()
    {
        // Check elapsed time since the animation started
        float elapsedTime = Time.time - animationStartTime;

        // Deactivate objects at their respective times
        if (object1 != null && elapsedTime >= deactivateTime1 && object1.activeSelf)
        {
            object1.SetActive(false);
        }

        if (object2 != null && elapsedTime >= deactivateTime2 && object2.activeSelf)
        {
            object2.SetActive(false);
        }

        if (object3 != null && elapsedTime >= deactivateTime2 && object3.activeSelf)
        {
            object3.SetActive(false);
        }

        if (object4 != null && elapsedTime >= deactivateTime4 && object4.activeSelf)
        {
            object4.SetActive(false);
        }

        // Reactivate all objects when the animation ends
        if (elapsedTime >= animationDuration)
        {
            if (object1 != null) object1.SetActive(true);
            if (object2 != null) object2.SetActive(true);
            if (object3 != null) object3.SetActive(true);
            if (object4 != null) object4.SetActive(true);

            // Optionally, stop further updates after reactivation
            enabled = false;
        }
    }
}
