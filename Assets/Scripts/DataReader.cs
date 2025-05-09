using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Add this namespace for LINQ methods like ToList

public class DataReader : MonoBehaviour
{
    public string jsonFilePath = "satellite_data.json"; // Path to the JSON file
    public List<SatelliteData> SatelliteDataList; // The list that will hold the satellite data

    void Start()
    {
        LoadSatelliteData();
    }

    private void LoadSatelliteData()
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, jsonFilePath);

        if (File.Exists(fullPath))
        {
            string jsonData = File.ReadAllText(fullPath);
            // Convert the array to a List using ToList
            SatelliteDataList = JsonHelper.FromJson<SatelliteData>(jsonData).ToList();

            // Log the loaded data
            if (SatelliteDataList != null && SatelliteDataList.Count > 0)
            {
                Debug.Log($"Loaded {SatelliteDataList.Count} data points.");
            }
            else
            {
                Debug.LogError("Loaded data list is empty.");
            }
        }
        else
        {
            Debug.LogError($"File not found at path: {fullPath}");
            SatelliteDataList = new List<SatelliteData>();
        }
    }
}
