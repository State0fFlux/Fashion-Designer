using UnityEngine;

[CreateAssetMenu(fileName = "ColorPalette", menuName = "Makeup/Color Palette", order = 1)]
public class ColorPalette : ScriptableObject
{
    public Color[] colors = new Color[4]; // Array of colors in the palette
    public string paletteName;

    private void OnValidate()
    {
#if UNITY_EDITOR
        paletteName = name; // 'name' is the asset file name without extension
        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i].a < 1f) // Ensure alpha is not too low
            {
                colors[i].a = 1f; // Set alpha to 1 if it's too low
            }
        }
#endif
    }
}
