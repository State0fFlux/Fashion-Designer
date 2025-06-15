using UnityEngine;
using UnityEngine.UI;

public class PaletteManager : MonoBehaviour
{
    public ColorPalette palette; // Assign this in the Inspector
    public GameObject shadePrefab; // Assign a prefab with a SpriteRenderer in the Inspector

    public Color[] GetColors()
    {
        return palette.colors;
    }

    private void Start()
    {
        // Create the color palette at the start
        float spacing = shadePrefab.GetComponent<RectTransform>().rect.width * 1.1f; // Space between squares
        float totalWidth = (palette.colors.Length - 1) * spacing;

        float startX = -totalWidth / 2f; // Center the row
        for (int i = 0; i < palette.colors.Length; i++)
        {
            GameObject shade = Instantiate(shadePrefab, transform);
            RectTransform rt = shade.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(startX + i * spacing, 0); // Position relative to anchor
            shade.GetComponent<Image>().color = palette.colors[i];
        }
    }
}
