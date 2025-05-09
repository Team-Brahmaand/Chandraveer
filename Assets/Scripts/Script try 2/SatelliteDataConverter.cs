using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;

public class SatelliteDataConverter : MonoBehaviour
{
    public string csvFileName = "satellite_dummy_data.csv";
    public GameObject satelliteObject;
    public TextMeshProUGUI infoText; // TextMeshPro UI element to display data

    private List<(float time, float ra, float dec, float distance, Vector3 position)> satelliteData = new List<(float, float, float, float, Vector3)>();
    private int currentIndex = 1; // Start from the second point, as the first is the initial position
    private Vector3 targetPosition;
    private float segmentTravelTime = 1.0f;
    private float elapsedTime = 0.0f;

    private void Start()
    {
        LoadAndConvertData();
    }

    private void Update()
    {
        if (currentIndex >= satelliteData.Count) return;

        if (satelliteObject != null)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / segmentTravelTime);

            satelliteObject.transform.position = Vector3.Lerp(
                satelliteData[currentIndex - 1].position,
                targetPosition,
                progress
            );

            if (progress >= 1.0f)
            {
                MoveToNextPoint();
            }
        }
        else
        {
            Debug.LogWarning("Satellite Object is not assigned.");
        }
    }

    private void MoveToNextPoint()
    {
        if (currentIndex < satelliteData.Count - 1)
        {
            currentIndex++;
            SetNextTarget();
        }
        else
        {
            Debug.Log("All points processed.");
        }
    }

    private void SetNextTarget()
    {
        if (currentIndex == 0 || currentIndex >= satelliteData.Count) return;

        var (time, ra, dec, distance, position) = satelliteData[currentIndex];
        targetPosition = position;

        float distanceToNext = Vector3.Distance(satelliteData[currentIndex - 1].position, targetPosition);
        segmentTravelTime = 1.0f; // Time interval between points
        elapsedTime = 0.0f;

        Debug.Log(
            $"Time: {time}s | RA: {ra:F2}°, Dec: {dec:F2}°, Distance: {distance:F2} km | " +
            $"Target Position (x, y, z): {position.x:F2}, {position.y:F2}, {position.z:F2} | " +
            $"Distance to next: {distanceToNext:F2} units"
        );

        // Update the TextMeshPro UI element
        if (infoText != null)
        {
            infoText.text = $"RA: {ra:F2}°\nDec: {dec:F2}°\nDistance: {distance:F2} km";
        }
    }

    private void LoadAndConvertData()
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, csvFileName);
        Debug.Log($"Attempting to load CSV file from: {fullPath}");

        StartCoroutine(LoadCSVData(fullPath));
    }

    private IEnumerator LoadCSVData(string fullPath)
    {
        using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(fullPath))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                string[] lines = request.downloadHandler.text.Split('\n');
                ProcessCSVData(lines);
            }
            else
            {
                Debug.LogError($"Failed to load CSV file: {request.error}");
            }
        }
    }

    private void ProcessCSVData(string[] lines)
    {
        satelliteData.Clear(); // Clear any existing data
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            if (values.Length < 4)
            {
                Debug.LogWarning($"Invalid data format at line {i + 1}");
                continue;
            }

            try
            {
                float time = float.Parse(values[0], CultureInfo.InvariantCulture);
                float ra = float.Parse(values[1], CultureInfo.InvariantCulture);
                float dec = float.Parse(values[2], CultureInfo.InvariantCulture);
                float distance = float.Parse(values[3], CultureInfo.InvariantCulture);

                Vector3 position = ConvertToCartesian(ra, dec, distance);
                satelliteData.Add((time, ra, dec, distance, position));
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error parsing data at line {i + 1}: {ex.Message}");
            }
        }

        if (satelliteData.Count > 0)
        {
            satelliteObject.transform.position = satelliteData[0].position; // Start at the first position
            SetNextTarget();
            Debug.Log($"Successfully loaded {satelliteData.Count} satellite data points.");
        }
        else
        {
            Debug.LogError("No valid data points loaded.");
        }
    }

    private Vector3 ConvertToCartesian(float rightAscension, float declination, float distance)
    {
        float raRad = rightAscension * Mathf.Deg2Rad;
        float decRad = declination * Mathf.Deg2Rad;

        float x = distance * Mathf.Cos(decRad) * Mathf.Cos(raRad);
        float y = distance * Mathf.Cos(decRad) * Mathf.Sin(raRad);
        float z = distance * Mathf.Sin(decRad);

        return new Vector3(x, y, z);
    }
}
