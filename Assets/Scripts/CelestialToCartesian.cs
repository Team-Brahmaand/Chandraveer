using UnityEngine;
using System.Collections.Generic;

public class CelestialToCartesian : MonoBehaviour
{
    public static Vector3[] ConvertAll(List<SatelliteData> satelliteDataList)
    {
        Vector3[] cartesianCoordinates = new Vector3[satelliteDataList.Count];

        for (int i = 0; i < satelliteDataList.Count; i++)
        {
            var data = satelliteDataList[i];
            cartesianCoordinates[i] = ConvertToCartesian(data.RightAscension, data.Declination, data.Distance);
        }

        return cartesianCoordinates;
    }

    private static Vector3 ConvertToCartesian(float ra, float dec, float distance)
    {
        float raRad = ra * Mathf.Deg2Rad;
        float decRad = dec * Mathf.Deg2Rad;

        float x = distance * Mathf.Cos(decRad) * Mathf.Cos(raRad);
        float y = distance * Mathf.Cos(decRad) * Mathf.Sin(raRad);
        float z = distance * Mathf.Sin(decRad);

        return new Vector3(x, y, z);
    }
}
