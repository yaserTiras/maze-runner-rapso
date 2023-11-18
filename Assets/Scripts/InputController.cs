using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public CharacterInputs inputs;
    private Vector2 inputValues;
    public Vector2 InputValues { get => inputValues; }

    private void Awake()
    {
        inputs = new CharacterInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Character.Movements.performed += OnPerformed;
        inputs.Character.Movements.canceled += OnCanceled;
    }

    private void OnCanceled(InputAction.CallbackContext obj)
    {
        inputValues = Vector2.zero;
    }

    private void OnPerformed(InputAction.CallbackContext obj)
    {
        inputValues = obj.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
