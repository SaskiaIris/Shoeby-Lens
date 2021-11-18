using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationController : MonoBehaviour
{
    [SerializeField]
    private XRController leftTeleportRay;

    [SerializeField]
    private XRController rightTeleportRay;

    [SerializeField]
    private InputHelpers.Button teleportActivationButton;

    [SerializeField]
    private float activationThreshold = 0.1f;

    void Update()
    {
        if(leftTeleportRay || rightTeleportRay) {
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay, rightTeleportRay));
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay, leftTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller, XRController otherHand) {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        InputHelpers.IsPressed(otherHand.inputDevice, teleportActivationButton, out bool otherHandAlreadyActivated, activationThreshold);
        if(otherHandAlreadyActivated) {
            return false;
        } else {
            return isActivated;
        }
        return isActivated;
    }
}