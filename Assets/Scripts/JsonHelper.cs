using UnityEngine;
using System;

public class JsonHelper
{
    // Helper function to parse JSON arrays
    public static T[] FromJson<T>(string json)
    {
        // Wrap the JSON in an object with an array field
        string wrappedJson = "{\"items\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrappedJson);
        return wrapper.items;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
