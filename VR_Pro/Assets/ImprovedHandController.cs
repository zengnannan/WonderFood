using UnityEngine.InputSystem;
using UnityEngine;

public class ImprovedHandController : MonoBehaviour
{
    [SerializeField] private InputActionReference controllerActionGrip;
    [SerializeField] private InputActionReference controllerActionTrigger;

    private Animator _handAnimator;

    private void Awake()
    {
        controllerActionGrip.action.performed += GripPress;
        controllerActionTrigger.action.performed += TriggerPress;

        _handAnimator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        controllerActionGrip.action.performed -= GripPress;
        controllerActionTrigger.action.performed -= TriggerPress;
    }

    private void TriggerPress(InputAction.CallbackContext obj) =>
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());

    private void GripPress(InputAction.CallbackContext obj) =>
        _handAnimator.SetFloat("Grip", obj.ReadValue<float>());


}
