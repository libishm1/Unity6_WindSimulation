using UnityEngine;
using System.Collections.Generic;

public class WindFlowManager : MonoBehaviour
{
    public int gridSizeX = 15;
    public int gridSizeY = 7;
    public int gridSizeZ = 15;
    public float cellSpacing = 1.5f;
    public float windSpeed = 5.0f;
    public Vector3 windDirection = new Vector3(1, 0, 0);
    public float turbulenceStrength = 1.2f;
    public float noiseScale = 0.4f;
    public GameObject windLinePrefab;
    public Gradient velocityGradient;

    private List<GameObject> windLines = new List<GameObject>();
    private float timeOffset;

    void Start()
    {
        if (windLinePrefab == null)
        {
            Debug.LogError("WindLinePrefab is missing! Please assign it in the inspector.");
            return;
        }
        timeOffset = Random.Range(0f, 100f);
        GenerateWindLines();
    }

    void Update()
    {
        UpdateWindLines();
    }

    void GenerateWindLines()
    {
        GameObject plane = GameObject.Find("WindSource");
        if (plane == null)
        {
            Debug.LogError("WindSource not found in the scene!");
            return;
        }
        Vector3 planePosition = plane.transform.position;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 offset = new Vector3(x * cellSpacing, y * cellSpacing, z * cellSpacing);
                    Vector3 startPosition = planePosition + offset;
                    GameObject line = Instantiate(windLinePrefab, startPosition, Quaternion.identity, transform);
                    windLines.Add(line);
                }
            }
        }
    }

    void UpdateWindLines()
    {
        foreach (GameObject line in windLines)
        {
            Vector3 startPos = line.transform.position;
            float turbulenceX = (Mathf.PerlinNoise(startPos.z * noiseScale, Time.time) - 0.5f) * turbulenceStrength;
            float turbulenceY = (Mathf.PerlinNoise(startPos.x * noiseScale, Time.time) - 0.5f) * turbulenceStrength;
            float turbulenceZ = (Mathf.PerlinNoise(startPos.y * noiseScale, Time.time) - 0.5f) * turbulenceStrength;
            Vector3 turbulence = new Vector3(turbulenceX, turbulenceY, turbulenceZ);
            Vector3 finalWindVector = (windDirection.normalized * windSpeed) + turbulence;
            Vector3 endPos = startPos + finalWindVector * 0.5f;
            float speedMagnitude = finalWindVector.magnitude;

            LineRenderer lr = line.GetComponent<LineRenderer>();
            if (lr != null)
            {
                lr.SetPosition(0, startPos);
                lr.SetPosition(1, endPos);
                lr.startWidth = Mathf.Lerp(0.05f, 0.2f, speedMagnitude / 10f);
                lr.endWidth = 0.02f;
                lr.material.color = velocityGradient.Evaluate(speedMagnitude / 10f);
            }
        }
    }
}

