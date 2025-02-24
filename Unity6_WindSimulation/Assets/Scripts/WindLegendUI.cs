using UnityEngine;
using UnityEngine.UIElements;

public class WindLegendUI : MonoBehaviour
{
    private VisualElement windLegend;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument not found on this GameObject!");
            return;
        }

        var root = uiDocument.rootVisualElement;
        windLegend = root.Q<VisualElement>("WindLegend");

        if (windLegend == null)
        {
            Debug.LogError("WindLegend UI Element not found!");
            return;
        }

        UpdateWindLegend();
    }

    /// <summary>
    /// Updates the wind legend color gradient dynamically.
    /// </summary>
    public void UpdateWindLegend()
    {
        if (windLegend != null)
        {
            // Set a background gradient for wind speed visualization
            windLegend.style.backgroundColor = new StyleColor(new Color(0, 0, 1)); // Start with blue
            windLegend.style.unityBackgroundImageTintColor = new Color(1, 0, 0, 1); // End with red
        }
    }
}
