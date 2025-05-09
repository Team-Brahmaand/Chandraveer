using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRPhysicsRaycast : MonoBehaviour
{
    public Transform rayOrigin; // Assign the controller or camera as the origin
    public float maxDistance = 10f; // Adjust ray length

    void Update()
    {
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out RaycastHit hit, maxDistance))
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.forward * hit.distance, Color.green);

            if (hit.collider.CompareTag("Interactable")) // Ensure objects have this tag
            {
                Debug.Log("Hit: " + hit.collider.name);
                // Add interaction logic here, like enabling/disabling objects
            }
        }
        else
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.forward * maxDistance, Color.red);
        }
    }
}
