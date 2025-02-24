using UnityEngine;
using System.IO;

public class EPWManager : MonoBehaviour
{
    public WindFlowManager windManager;

    public void LoadEPW(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("EPW file not found: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length < 10)
        {
            Debug.LogError("Invalid EPW file format!");
            return;
        }

        // Example: Extract wind speed and direction from a specific line
        string[] data = lines[8].Split(',');
        if (data.Length > 7)
        {
            float windSpeed = float.Parse(data[6]);
            float windDirection = float.Parse(data[5]);

            windManager.windSpeed = windSpeed;
            windManager.windDirection = new Vector3(Mathf.Cos(windDirection * Mathf.Deg2Rad), 0, Mathf.Sin(windDirection * Mathf.Deg2Rad));
        }
    }
}
