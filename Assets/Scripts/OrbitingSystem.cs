using UnityEngine;

public class OrbitingSystem : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform centerObject; // The object to orbit around (e.g., Sun for planets)
    public float orbitSpeed = 10f; // Speed of the orbit

    [Header("Rotation Settings")]
    public bool enableRotation = true; // Toggle object self-rotation
    public float rotationSpeed = 30f; // Speed of self-rotation

    private Vector3 orbitAxis = Vector3.up; // Orbit around the Y-axis by default

    void Update()
    {
        // Orbit around the center object
        if (centerObject != null)
        {
            transform.RotateAround(centerObject.position, orbitAxis, orbitSpeed * Time.deltaTime);
        }

        // Self-rotation
        if (enableRotation)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
        Debug.Log("This is a test log");

    }
}
