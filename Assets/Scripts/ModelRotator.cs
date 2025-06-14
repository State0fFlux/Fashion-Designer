using UnityEngine;

public class ModelRotator : MonoBehaviour
{
    private Input input;

    private void Awake()
    {
        // Initialize the input action
        input = new Input();
    }

    private void OnEnable()
    {
        input.Model.Enable();
    }
    private void OnDisable()
    {
        input.Model.Disable();
    }

    private void Start()
    {
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, input.Model.Rotate.ReadValue<float>(), 0);
    }
}
