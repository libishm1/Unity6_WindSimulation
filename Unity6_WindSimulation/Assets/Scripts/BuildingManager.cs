using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.IO;

public class BuildingManager : MonoBehaviour
{
    public GameObject buildingPrefab; // Default cube building
    public int maxBuildings = 5; // Max buildings allowed
    private List<GameObject> buildings = new List<GameObject>();
    private int buildingCount = 0;

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
        addBuildingButton = root.Q<Button>("AddBuildingButton");
        importBuildingButton = root.Q<Button>("ImportBuildingButton");

        if (addBuildingButton != null)
            addBuildingButton.clicked += AddBuilding;

        if (importBuildingButton != null)
            importBuildingButton.clicked += () => ImportBuilding();
    }

    /// <summary>
    /// Adds a 40m cube building at the next available slot
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

        Vector3 position = new Vector3(buildingCount * 20, 20, 0);
        GameObject newBuilding = Instantiate(buildingPrefab, position, Quaternion.identity);
        newBuilding.name = "Building_" + buildingCount;
        buildings.Add(newBuilding);
        buildingCount++;
    }

    /// <summary>
    /// Opens a file dialog to select and import an OBJ or FBX model
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
        Debug.LogError("File import is currently supported on Windows and Editor mode only.");
#endif
    }

    /// <summary>
    /// Shows a file dialog to select OBJ/FBX files
    /// </summary>
    private string ShowFileDialog()
    {
        string[] extensions = new string[] { "obj", "fbx" };
        return UnityEditor.EditorUtility.OpenFilePanel("Import 3D Model", "", string.Join(",", extensions));
    }

    /// <summary>
    /// Loads an OBJ or FBX model at runtime
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

        GameObject importedModel = new GameObject("ImportedBuilding_" + buildingCount);
        importedModel.transform.position = new Vector3(buildingCount * 20, 0, 0);
        buildings.Add(importedModel);
        buildingCount++;

        Debug.Log("Successfully imported: " + path);
        yield return new WaitForSeconds(1f);
    }
}
