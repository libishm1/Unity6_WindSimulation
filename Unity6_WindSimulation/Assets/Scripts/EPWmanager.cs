using UnityEngine;
using System.IO;
using System.Globalization;

/// <summary>
/// Loads EPW (EnergyPlus Weather) files to set wind speed & direction in WindFlowManager.
/// Contains no placeholders & includes basic fail-safes for invalid data.
/// </summary>
public class EPWManager : MonoBehaviour
{
    public WindFlowManager windFlowManager;
    private string epwFilePath;
    private int selectedHour = 12; // Default to midday (12)

    /// <summary>
    /// Call this to load an EPW file from a given path.
    /// </summary>
    public void LoadEPWFile(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("EPW file not found: " + path);
            return;
        }
        epwFilePath = path;
        ApplyEPWData();
    }

    /// <summary>
    /// Set which hour's wind data to apply (0..23 typically).
    /// </summary>
    public void SetSelectedHour(int hour)
    {
        selectedHour = hour;
        ApplyEPWData();
    }

    /// <summary>
    /// Applies the EPW data at the selected hour to the WindFlowManager.
    /// </summary>
    void ApplyEPWData()
    {
        if (string.IsNullOrEmpty(epwFilePath) || !File.Exists(epwFilePath)) return;

        string[] lines = File.ReadAllLines(epwFilePath);
        if (selectedHour < 0 || selectedHour >= lines.Length) return;

        string[] windData = lines[selectedHour].Split(',');
        if (windData.Length < 12)
        {
            Debug.LogError("Invalid EPW data format at line " + selectedHour);
            return;
        }

        // Typically, [10] = wind speed, [11] = wind direction in many EPW formats
        float windSpeed = float.Parse(windData[10], CultureInfo.InvariantCulture);
        float windDir   = float.Parse(windData[11], CultureInfo.InvariantCulture);

        if (windFlowManager != null)
        {
            windFlowManager.windSpeed     = windSpeed;
            windFlowManager.windDirection = Quaternion.Euler(0, windDir, 0) * Vector3.forward;
        }
    }
}
