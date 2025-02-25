using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// An editor script to import .obj files via a menu item.
/// Copies the file into Assets, refreshes the database, then instantiates the model.
/// </summary>
public class OBJImporterEditor : Editor
{
    [MenuItem("Tools/Import OBJ Model")]
    public static void ImportOBJModel()
    {
        // 1) Open file panel for .obj
        string path = EditorUtility.OpenFilePanel("Select OBJ Model", "", "obj");
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("No file selected or invalid path.");
            return;
        }

        // 2) Ensure the file actually exists
        if (!File.Exists(path))
        {
            Debug.LogError($"File does not exist: {path}");
            return;
        }

        // 3) Copy file into Assets
        string fileName = Path.GetFileName(path);
        string destFolder = "Assets/ImportedModels";
        string assetPath = Path.Combine(destFolder, fileName);

        if (!Directory.Exists(destFolder))
            Directory.CreateDirectory(destFolder);

        File.Copy(path, assetPath, true);
        AssetDatabase.Refresh();

        // 4) Load the imported model from assetPath
        GameObject imported = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        if (imported == null)
        {
            Debug.LogError($"Failed to load imported OBJ at: {assetPath}");
            return;
        }

        // 5) Instantiate in the current scene at (0,0,0)
        GameObject instance = PrefabUtility.InstantiatePrefab(imported) as GameObject;
        if (instance != null)
        {
            instance.transform.position = Vector3.zero;
            // Optional: Tag it as "Building" if you want wind deflection
            // instance.tag = "Building";
            Debug.Log($"Successfully imported and instantiated: {fileName}");
        }
        else
        {
            Debug.LogError("Instantiation failed. Check if your .obj is recognized as a valid prefab or model.");
        }
    }
}
