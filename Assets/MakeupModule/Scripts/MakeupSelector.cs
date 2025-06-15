using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MakeupSelector : MonoBehaviour
{

    private MakeupManager manager;
    private Image image;
    private Color color;
    private Toggle toggle;

    private void Start()
    {
        manager = FindAnyObjectByType<MakeupManager>(); // assumes only one MakeupManager in the scene
        image = GetComponent<Image>();
        color = image.color;

        toggle = GetComponent<Toggle>();
        toggle.group = FindAnyObjectByType<ToggleGroup>(); // assumes a ToggleGroup exists in the scene
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn && manager != null)
        {
            manager.SetColor(color);
        }
    }

    public Color GetColor()
    {
        return color;
    }
}