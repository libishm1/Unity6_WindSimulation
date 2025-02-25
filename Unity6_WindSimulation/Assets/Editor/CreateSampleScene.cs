using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

/// <summary>
/// Auto-generates a sample scene with a WindSource plane & a 40m building, plus optional managers.
/// </summary>
public class CreateSampleScene : MonoBehaviour
{
    [MenuItem("Tools/Create Wind Simulation Sample Scene")]
    public static void CreateScene()
    {
        // Create a new scene without the default camera & light
        Scene scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
        scene.name = "WindSimulation";

        // Remove default camera and directional light
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            if (go.name == "Main Camera" || go.name == "Directional Light")
                GameObject.DestroyImmediate(go);
        }

        // Create WindSource (Plane)
        GameObject windSource = GameObject.CreatePrimitive(PrimitiveType.Plane);
        windSource.name = "WindSource";
        windSource.transform.position = new Vector3(0, 0.5f, -10);
        windSource.transform.localScale = new Vector3(10, 1, 10);

        // Create Building (Cube) as a 40m placeholder
        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.name = "Building";
        building.transform.position = new Vector3(0, 20, 0);
        building.transform.localScale = new Vector3(10, 40, 10);
        building.tag = "Building";

        // Optionally attach managers or UI prefabs if needed

        // Save the scene to Assets/Scenes/
        string scenePath = "Assets/Scenes/WindSimulation.unity";
        EditorSceneManager.SaveScene(scene, scenePath);
        AssetDatabase.Refresh();

        Debug.Log("Sample Scene Created & Saved: " + scenePath);
    }
}
