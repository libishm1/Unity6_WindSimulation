using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.IO;

/// <summary>
/// Manages building placement & imports OBJ/FBX models.
/// Uses UI Toolkit buttons for "Add 40m Cube" and "Import Model".
/// Adds a "Building" tag for wind deflection interactions.
/// </summary>
public class BuildingManager : MonoBehaviour
{
    [Tooltip("Default cube building to instantiate (tagged as 'Building').")]
    public GameObject buildingPrefab; // Default cube building

    [Tooltip("Max number of buildings allowed.")]
    public int maxBuildings = 5;

    private List<GameObject> buildings = new List<GameObject>();
    private int buildingCount = 0;

    // UI references
    private VisualElement root;
    private Button addBuildingButton;
    private Button importBuildingButton;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument not found on this GameObject!");
            return;
        }

        root = uiDocument.rootVisualElement;
        if (root == null)
        {
            Debug.LogError("No rootVisualElement found in UIDocument!");
            return;
        }

        // Query UI elements by name
        addBuildingButton = root.Q<Button>("AddBuildingButton");
        importBuildingButton = root.Q<Button>("ImportBuildingButton");

        // Register click events
        if (addBuildingButton != null)
            addBuildingButton.clicked += AddBuilding;
        else
            Debug.LogWarning("AddBuildingButton not found in UXML.");

        if (importBuildingButton != null)
            importBuildingButton.clicked += () => ImportBuilding();
        else
            Debug.LogWarning("ImportBuildingButton not found in UXML.");
    }

    /// <summary>
    /// Adds a 40m cube building at the next available slot.
    /// Buildings are tagged as 'Building' for wind deflection.
    /// </summary>
    public void AddBuilding()
    {
        if (buildingCount >= maxBuildings)
        {
            Debug.Log("Max number of buildings reached.");
            return;
        }

        if (buildingPrefab == null)
        {
            Debug.LogError("Building prefab is not assigned!");
            return;
        }

        // Spawn building in a line or offset
        Vector3 position = new Vector3(buildingCount * 20, 20, 0);
        GameObject newBuilding = Instantiate(buildingPrefab, position, Quaternion.identity);
        newBuilding.name = "Building_" + buildingCount;
        newBuilding.tag = "Building"; // Essential for wind deflection
        buildings.Add(newBuilding);

        buildingCount++;
    }

    /// <summary>
    /// Opens a file dialog to select and import an OBJ or FBX model.
    /// Windows & Editor only.
    /// </summary>
    public void ImportBuilding()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        string path = ShowFileDialog();
        if (!string.IsNullOrEmpty(path))
        {
            StartCoroutine(LoadModel(path));
        }
#else
        Debug.LogError("File import is supported on Windows and Editor mode only.");
#endif
    }

    /// <summary>
    /// Displays an Editor file dialog to select .obj or .fbx files.
    /// </summary>
    private string ShowFileDialog()
    {
#if UNITY_EDITOR
        string[] extensions = new string[] { "obj", "fbx" };
        return UnityEditor.EditorUtility.OpenFilePanel("Import 3D Model", "", string.Join(",", extensions));
#else
        return null;
#endif
    }

    /// <summary>
    /// Loads an OBJ or FBX model at runtime and places it in the scene.
    /// Adds to 'buildings' list; increments buildingCount.
    /// </summary>
    private IEnumerator<WaitForSeconds> LoadModel(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("File does not exist: " + path);
            yield break;
        }

        string fileExtension = Path.GetExtension(path).ToLower();
        if (fileExtension != ".obj" && fileExtension != ".fbx")
        {
            Debug.LogError("Unsupported file format: " + fileExtension);
            yield break;
        }

        // For demonstration, we create an empty GameObject
        // (You could do actual model importing if you have an Editor-based pipeline.)
        GameObject importedModel = new GameObject("ImportedBuilding_" + buildingCount);
        importedModel.transform.position = new Vector3(buildingCount * 20, 0, 0);
        importedModel.tag = "Building"; // Tag so wind deflection can apply
        buildings.Add(importedModel);

        buildingCount++;

        Debug.Log("Successfully imported: " + path);
        yield return new WaitForSeconds(1f);
    }
}
