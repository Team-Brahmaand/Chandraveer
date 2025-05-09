using UnityEngine;

public class DisableOrbitForThisObject : MonoBehaviour
{
    public float disableTime = 30f; // Time in seconds

    void Start()
    {
        Invoke("DisableOrbitScript", disableTime);
    }

    void DisableOrbitScript()
    {
        SatelliteOrbit orbitScript = GetComponent<SatelliteOrbit>();
        if (orbitScript != null)
        {
            orbitScript.enabled = false;
            Debug.Log(gameObject.name + " has stopped orbiting.");
        }
    }
}
