using System;
using UnityEngine;
using UnityEngine.UI;

public class MakeupApplier : MonoBehaviour
{
    public float brushStrength = 3f; // How quickly the color blends in

    private MakeupManager manager;
    private Image image;
    private Input input;

    private void Awake()
    {
        // Initialize the input action
        input = new Input();
    }

    private void OnEnable()
    {
        input.UI.Enable();
    }
    private void OnDisable()
    {
        input.UI.Disable();
    }

    private void Start()
    {
        manager = FindAnyObjectByType<MakeupManager>(); // assumes only one MakeupManager in the scene
        image = GetComponent<Image>();
    }

    private void Update()
    {
        print(image.color.a);
        if (IsApplying())
        {
            ApplyColor();
        }
    }

    private bool IsApplying()
    {
        bool isMouseOver = GetComponent<BoxCollider2D>().OverlapPoint(input.UI.Position.ReadValue<Vector2>());
        return isMouseOver && input.UI.LeftMouseHold.ReadValue<float>() == 1 && input.UI.DeltaX.ReadValue<float>() != 0;
    }

    /* REPLACE ABOVE WITH THIS WHEN TIME FOR 3D MODEL PAINTING??
    private bool IsApplying()
    {
        // Get mouse position in screen space
        Vector2 screenPos = input.UI.Position.ReadValue<Vector2>();

        // Create a ray from the camera through the screen point
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        // Cast the ray
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Check if this object is what was hit
            return hit.collider.gameObject == this.gameObject
                && input.UI.LeftMouseHold.ReadValue<float>() > 0.5f
                && Mathf.Abs(input.UI.DeltaX.ReadValue<float>()) > 0.01f;
        }

        return false;
    }*/


    private void ApplyColor()
    {

        Color target = manager.GetColor();

        if (target.a == 0f) // handle eraser
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(image.color.a - Time.deltaTime * brushStrength)); // fade out gradually
        }
        else
        {
            if (image.color.a == 0f) // starting from transparent
            {
                image.color = new Color(target.r, target.g, target.b, 0f);
            }

            float currentAlpha = image.color.a;
            image.color = Color.Lerp(image.color, target, Time.deltaTime * brushStrength); // blend gradually
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha + Time.deltaTime * brushStrength)); // ensure alpha is clamped between 0 and 1
        }
    }
}
