using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Connects UI sliders/toggles/buttons to WindFlowManager,
/// enabling real-time adjustments for wind speed, turbulence,
/// vortex intensity, height-based wind, and GPU fallback.
/// </summary>
public class WindUIManager : MonoBehaviour
{
    [Tooltip("Reference to the WindFlowManager for applying UI changes.")]
    public WindFlowManager windFlowManager;

    private Slider windSpeedSlider;
    private Slider turbulenceSlider;
    private Slider vortexIntensitySlider;
    private Slider heightWindSlider;
    private Toggle gpuToggle;
    private Button applyButton;

    void Start()
    {
        // Retrieve UIDocument
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("No UIDocument found on this GameObject for WindUIManager!");
            return;
        }

        // Query the root visual element
        var root = uiDocument.rootVisualElement;
        if (root == null)
        {
            Debug.LogError("UIDocument has no rootVisualElement!");
            return;
        }

        // Query each UI element by name
        windSpeedSlider      = root.Q<Slider>("WindSpeedSlider");
        turbulenceSlider     = root.Q<Slider>("TurbulenceSlider");
        vortexIntensitySlider= root.Q<Slider>("VortexIntensitySlider");
        heightWindSlider     = root.Q<Slider>("HeightWindSlider");
        gpuToggle            = root.Q<Toggle>("GPUToggle");
        applyButton          = root.Q<Button>("ApplyButton");

        // Register the click event
        if (applyButton != null)
            applyButton.clicked += ApplyWindSettings;
        else
            Debug.LogWarning("ApplyButton not found in UXML. Wind settings won't be applied.");
    }

    /// <summary>
    /// Reads UI slider/toggle values & applies them to the simulation.
    /// </summary>
    void ApplyWindSettings()
    {
        if (windFlowManager == null)
        {
            Debug.LogError("WindFlowManager reference not set in WindUIManager!");
            return;
        }

        if (windSpeedSlider != null)
            windFlowManager.windSpeed = windSpeedSlider.value;

        if (turbulenceSlider != null)
            windFlowManager.turbulenceScale = turbulenceSlider.value;

        if (vortexIntensitySlider != null)
            windFlowManager.vortexIntensity = vortexIntensitySlider.value;

        if (heightWindSlider != null)
            windFlowManager.heightWindFactor = heightWindSlider.value;

        if (gpuToggle != null)
            windFlowManager.useGPU = gpuToggle.value;
    }
}
