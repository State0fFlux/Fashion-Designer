using UnityEngine;
using UnityEngine.UI;

public class MakeupManager : MonoBehaviour
{

    // Stuff for selected color
    private Color selectedColor = Color.clear; // Current makeup color on brush
    public GameObject currentSelectedColor; // Assign a GameObject to display the current selected color

    public void SetColor(Color color)
    {
        selectedColor = color; // Update the selected color
    }

    public Color GetColor()
    {
        return selectedColor; // Return the current selected color
    }

    public void SelectEraser()
    {
        SetColor(Color.clear); // Set the selected color to clear for erasing
    }

    // Update is called once per frame
    void Update()
    {
        currentSelectedColor.GetComponent<Image>().color = GetColor(); // Update the current selected color display
    }
}
