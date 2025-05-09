using UnityEngine;
using UnityEngine.UI;


public class GlobalUIHaptics : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor leftHandInteractor;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor rightHandInteractor;
    public float amplitude = 0.5f;
    public float duration = 0.1f;

    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => TriggerHaptics());
        }
    }

    void TriggerHaptics()
    {
        if (leftHandInteractor is UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor leftDirect)
            leftDirect.xrController?.SendHapticImpulse(amplitude, duration);
        
        if (rightHandInteractor is UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor rightDirect)
            rightDirect.xrController?.SendHapticImpulse(amplitude, duration);
    }
}
