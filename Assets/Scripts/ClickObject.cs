using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ClickObject : MonoBehaviour
{
    public GameObject uiGameObject; // Assign UI GameObject in inspector
    private XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(ShowUI);
        }
    }

    public void ShowUI(SelectEnterEventArgs args)
    {
        if (uiGameObject != null)
        {
            uiGameObject.SetActive(true); // Enable the assigned UI GameObject
        }
    }
}
