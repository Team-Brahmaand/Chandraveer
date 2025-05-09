using UnityEngine;
using UnityEngine.XR;

public class HapticFeedbackTrigger : MonoBehaviour
{
    public XRNode leftHand = XRNode.LeftHand;
    public XRNode rightHand = XRNode.RightHand;

    public float hapticAmplitude = 0.5f; // Intensity (0 to 1)
    public float hapticDuration = 0.2f;  // Duration in seconds

    private InputDevice leftController;
    private InputDevice rightController;

    void Start()
    {
        leftController = InputDevices.GetDeviceAtXRNode(leftHand);
        rightController = InputDevices.GetDeviceAtXRNode(rightHand);
    }

    void Update()
    {
        // Check and trigger haptics for the left hand
        if (leftController.isValid && leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerValue) && leftTriggerValue > 0.1f)
        {
            SendHapticImpulse(leftController);
        }

        // Check and trigger haptics for the right hand
        if (rightController.isValid && rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerValue) && rightTriggerValue > 0.1f)
        {
            SendHapticImpulse(rightController);
        }
    }

    void SendHapticImpulse(InputDevice device)
    {
        device.SendHapticImpulse(0, hapticAmplitude, hapticDuration);
    }
}
