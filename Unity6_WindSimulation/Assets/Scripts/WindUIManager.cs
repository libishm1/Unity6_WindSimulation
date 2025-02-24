using UnityEngine;
using UnityEngine.UIElements;

public class WindUIManager : MonoBehaviour
{
    public WindFlowManager windManager;
    private Slider windSpeedSlider;
    private Slider turbulenceSlider;
    private Button applyButton;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument not found on this GameObject!");
            return;
        }

        var root = uiDocument.rootVisualElement;
        windSpeedSlider = root.Q<Slider>("WindSpeedSlider");
        turbulenceSlider = root.Q<Slider>("TurbulenceSlider");
        applyButton = root.Q<Button>("ApplyButton");

        if (windSpeedSlider == null || turbulenceSlider == null || applyButton == null)
        {
            Debug.LogError("One or more UI elements not found in the UXML file!");
            return;
        }

        applyButton.clicked += ApplySettings;
    }

    void ApplySettings()
    {
        if (windManager == null)
        {
            Debug.LogError("WindFlowManager is not assigned!");
            return;
        }
        windManager.windSpeed = windSpeedSlider.value;
        windManager.turbulenceStrength = turbulenceSlider.value;
    }
}
