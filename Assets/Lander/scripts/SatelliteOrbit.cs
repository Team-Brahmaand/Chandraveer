using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    public Transform moon; // Assign the Moon's transform in the inspector
    public float orbitSpeed = 360f / 30f; // Speed of orbiting
    public float rotationSpeed = 50f; // Speed of satellite's self-rotation
    public float distanceFromMoon = 5f; // Distance from the moon

    private float angle = 0f;

    void Update()
    {
        if (moon == null)
        {
            Debug.LogError("Moon transform is not assigned!");
            return;
        }

        // Calculate new position for longitudinal orbit (pole-to-pole)
        angle += orbitSpeed * Time.deltaTime;
        float x = moon.position.x;
        float y = moon.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * distanceFromMoon;
        float z = moon.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * distanceFromMoon;
        transform.position = new Vector3(x, y, z);

        // Keep satellite rotation stable without flipping
        transform.up = (transform.position - moon.position).normalized;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
