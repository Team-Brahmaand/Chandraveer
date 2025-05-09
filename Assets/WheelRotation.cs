using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float speed = 100f; // Rotation speed
    public Vector3 rotationAxis = Vector3.right; // Default axis for wheel rotation
    public float duration = 10f; // Duration of rotation
    public float startDelay = 60f; // Delay before rotation starts

    private float timer = 0f;
    private bool isRotating = false;
    private float delayTimer = 0f;

    void Update()
    {
        if (!isRotating)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= startDelay)
            {
                isRotating = true;
                timer = 0f;
            }
        }

        if (isRotating)
        {
            transform.Rotate(rotationAxis * speed * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                isRotating = false;
                enabled = false; // Disable the script after the duration
            }
        }
    }
}
