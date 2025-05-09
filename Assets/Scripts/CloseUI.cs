using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject uiGameObject; // Assign UI GameObject in inspector

    public void HideUI()
    {
        if (uiGameObject != null)
        {
            uiGameObject.SetActive(false); // Disable the UI GameObject
        }
    }
}
