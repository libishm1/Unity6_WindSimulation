using UnityEngine;
using UnityEditor;

public class CreateSampleScene : MonoBehaviour
{
    [MenuItem("Tools/Create Wind Simulation Sample Scene")]
    static void CreateScene()
    {
        GameObject windSource = GameObject.CreatePrimitive(PrimitiveType.Plane);
        windSource.name = "WindSource";

        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.name = "Building";
        building.transform.position = new Vector3(0, 20, 0);
        building.transform.localScale = new Vector3(10, 40, 10);

        Debug.Log("Sample Scene Created!");
    }
}
