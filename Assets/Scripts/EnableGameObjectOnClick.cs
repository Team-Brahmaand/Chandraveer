using UnityEngine;
using UnityEngine.UI;

public class EnableGameObjectOnClick : MonoBehaviour
{
    public GameObject objectToEnable; // Assign the GameObject in the Inspector
    public Button triggerButton; // Assign the UI Button in the Inspector

    void Start()
    {
        if (triggerButton != null)
        {
            triggerButton.onClick.AddListener(EnableObject);
        }
    }

    public void EnableObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
    }
}
