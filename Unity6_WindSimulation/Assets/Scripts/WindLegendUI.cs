using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Dynamically creates a 1D gradient texture based on windSpeedGradient
/// and applies it to the "WindLegend" VisualElement background.
/// </summary>
public class WindLegendUI : MonoBehaviour
{
    [Tooltip("A gradient (blue-to-red, etc.) for displaying wind speed range.")]
    public Gradient windSpeedGradient;

    [Tooltip("Minimum wind speed displayed in the legend.")]
    public float minSpeed = 0f;

    [Tooltip("Maximum wind speed displayed in the legend.")]
    public float maxSpeed = 20f;

    // Adjust textureWidth as needed for finer gradient resolution
    private const int textureWidth = 256;
    private const int textureHeight = 1;
    
    private VisualElement windLegend;
    private Texture2D legendTexture;

    void Start()
    {
        // Retrieve the UIDocument & "WindLegend" element
        var uiDoc = GetComponent<UIDocument>();
        if (uiDoc == null)
        {
            Debug.LogError("No UIDocument found on this GameObject for WindLegendUI.");
            return;
        }

        var root = uiDoc.rootVisualElement;
        windLegend = root.Q<VisualElement>("WindLegend");

        if (windLegend == null)
        {
            Debug.LogError("No 'WindLegend' VisualElement found in this UI.");
            return;
        }

        // Generate and apply the gradient texture
        legendTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        GenerateGradientTexture();
        legendTexture.Apply();

        // Assign the texture as a background image
        windLegend.style.backgroundImage = new StyleBackground(legendTexture);
    }

    /// <summary>
    /// Creates a 1D horizontal gradient texture that maps from minSpeed to maxSpeed.
    /// </summary>
    private void GenerateGradientTexture()
    {
        for (int x = 0; x < textureWidth; x++)
        {
            // Normalized t from 0..1
            float t = (float)x / (textureWidth - 1);

            // Evaluate color in the gradient at t
            // (In advanced usage, you could map t to wind speeds between minSpeed..maxSpeed)
            Color c = windSpeedGradient.Evaluate(t);

            // Set pixel color
            legendTexture.SetPixel(x, 0, c);
        }
    }
}
