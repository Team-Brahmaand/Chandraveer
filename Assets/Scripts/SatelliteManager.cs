using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SatelliteManager : MonoBehaviour
{
    public GameObject satellite; // Reference to the satellite GameObject
    public float movementSpeed = 1f; // Speed of movement
    private DataReader dataReader;
    private Vector3[] cartesianCoordinates;
    private int currentPointIndex = 0; // Tracks current position index
    private bool isMoving = false;

    void Start()
    {
        dataReader = FindObjectOfType<DataReader>();
        dataReader.SatelliteDataList = new List<SatelliteData>
    {
        new SatelliteData { RightAscension = 10f, Declination = 20f, Distance = 100f },
        new SatelliteData { RightAscension = 15f, Declination = 25f, Distance = 105f }
    };
        // Ensure the DataReader is found
        if (dataReader == null)
        {
            Debug.LogError("DataReader not found in the scene.");
            return;
        }

        // Log the count of the SatelliteDataList and check if it's valid
        if (dataReader.SatelliteDataList == null)
        {
            Debug.LogError("SatelliteDataList is null.");
            return;
        }

        if (dataReader.SatelliteDataList.Count == 0)
        {
            Debug.LogError("SatelliteDataList is empty.");
            return;
        }

        // Log first few data points
        Debug.Log($"Loaded {dataReader.SatelliteDataList.Count} data points.");
        foreach (var data in dataReader.SatelliteDataList.Take(5))  // Log the first 5 points for quick validation
        {
            Debug.Log($"RA: {data.RightAscension}, Dec: {data.Declination}, Distance: {data.Distance}");
        }

        cartesianCoordinates = CelestialToCartesian.ConvertAll(dataReader.SatelliteDataList);

        // Log the Cartesian coordinates
        foreach (var point in cartesianCoordinates)
        {
            Debug.Log($"Converted Cartesian Point: {point}");
        }

        // Ensure there are valid Cartesian coordinates to move the satellite
        if (cartesianCoordinates.Length > 0)
        {
            satellite.transform.position = cartesianCoordinates[0]; // Set initial position
            isMoving = true; // Start moving
            Debug.Log("Satellite movement initialized.");
        }
        else
        {
            Debug.LogError("No valid Cartesian coordinates.");
        }
    }

    void Update()
    {
        // If satellite movement is enabled, update its position
        if (isMoving && cartesianCoordinates != null && cartesianCoordinates.Length > 1)
        {
            MoveSatellite();
        }
    }

    private void MoveSatellite()
    {
        Vector3 targetPoint = cartesianCoordinates[currentPointIndex];

        // Log the movement process for debugging
        Debug.Log($"Moving from {satellite.transform.position} to {targetPoint}");

        // Move the satellite to the target point
        satellite.transform.position = Vector3.MoveTowards(
            satellite.transform.position,
            targetPoint,
            movementSpeed * Time.deltaTime
        );

        // Check if the satellite has reached the target point
        if (satellite.transform.position == targetPoint)
        {
            currentPointIndex++;
            Debug.Log($"Reached Point {currentPointIndex}");

            // Restart if the satellite has gone through all points
            if (currentPointIndex >= cartesianCoordinates.Length)
            {
                currentPointIndex = 0; // Loop back to the start
                Debug.Log("Orbit complete. Restarting.");
            }
        }
    }
}
