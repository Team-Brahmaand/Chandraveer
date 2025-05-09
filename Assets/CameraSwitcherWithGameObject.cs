using UnityEngine;

public class CameraSwitcherWithGameObject : MonoBehaviour
{
    public GameObject targetObject; // GameObject to enable when switching back to camera1
    public float Delay = 5f; // Delay before switching to camera2 (in seconds)

    void Start()
    {
        Invoke("EnableNextPanel", Delay);
    }

    void EnableNextPanel()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
