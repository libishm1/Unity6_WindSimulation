using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles wind simulation (GPU or CPU fallback), Bezier curve streamlines,
/// building deflection, vortex intensity, height-based wind, and flow noise.
/// </summary>
public class WindFlowManager : MonoBehaviour
{
    // ----- GPU Toggle -----
    public bool useGPU = false;       // If true, tries to use compute shaders
    public ComputeShader windComputeShader;
    private bool isGPUSupported;

    // ----- Grid Setup -----
    public int gridSizeX = 15;
    public int gridSizeY = 10;
    public int gridSizeZ = 20;
    public float cellSpacing = 2.0f;

    // ----- Wind Properties -----
    public float windSpeed = 5.0f;
    public Vector3 windDirection = new Vector3(1, 0, 0);
    public float vortexIntensity = 1.2f;
    public float turbulenceScale = 0.6f;
    public float heightWindFactor = 1.0f;

    // ----- Visualization -----
    public GameObject windLinePrefab;
    public Gradient velocityGradient;

    // ----- Internal Storage -----
    private List<GameObject> windLines = new List<GameObject>();

    void Start()
    {
        // Check if GPU compute is supported
        isGPUSupported = SystemInfo.supportsComputeShaders;
        if (!isGPUSupported) useGPU = false;

        // Generate wind lines
        GenerateWindLines();
    }

    void Update()
    {
        if (useGPU && isGPUSupported && windComputeShader != null)
        {
            RunComputeShaderSimulation();
        }
        else
        {
            UpdateWindLinesCPU();
        }
    }

    /// <summary>
    /// GPU-based approach (placeholder). 
    /// Falls back to CPU if unsupported or if windComputeShader == null.
    /// </summary>
    void RunComputeShaderSimulation()
    {
        // TODO: Implement compute shader logic here
        // e.g., windComputeShader.Dispatch(kernelIndex, threadGroupsX, threadGroupsY, threadGroupsZ);
        
        // For now, fallback to CPU to avoid breaking behavior
        UpdateWindLinesCPU();
    }

    /// <summary>
    /// CPU-based approach with flow noise + building deflection + height-based wind.
    /// </summary>
    void UpdateWindLinesCPU()
    {
        foreach (GameObject line in windLines)
        {
            if (!line) continue; // Fail-safe

            Vector3 startPos = line.transform.position;
            Vector3 windVector = ComputeWindField(startPos);

            // We use a Bezier curve with 3 points
            Vector3 controlPoint = startPos + windVector * 0.25f;
            Vector3 endPos = startPos + windVector * 0.5f;

            float speedMagnitude = windVector.magnitude;

            LineRenderer lr = line.GetComponent<LineRenderer>();
            if (lr != null)
            {
                lr.positionCount = 3;
                lr.SetPosition(0, startPos);
                lr.SetPosition(1, controlPoint);
                lr.SetPosition(2, endPos);
                lr.startWidth = Mathf.Lerp(0.05f, 0.2f, speedMagnitude / 10f);
                lr.endWidth = 0.02f;
                lr.material.color = velocityGradient.Evaluate(speedMagnitude / 10f);
            }
        }
    }

    /// <summary>
    /// Generates wind lines in a 3D grid. 
    /// Creates the prefab or a programmatic line if needed.
    /// </summary>
    void GenerateWindLines()
    {
        if (windLinePrefab == null)
        {
            Debug.LogError("WindLinePrefab is missing. Please assign it in the inspector.");
            return;
        }

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 startPosition = new Vector3(x * cellSpacing, y * cellSpacing, z * cellSpacing);
                    GameObject line = Instantiate(windLinePrefab, startPosition, Quaternion.identity, transform);
                    windLines.Add(line);
                }
            }
        }
    }

    /// <summary>
    /// Combines base wind, vortex flow noise, building deflection, and height-based wind factor.
    /// </summary>
    Vector3 ComputeWindField(Vector3 position)
    {
        // Base wind direction
        Vector3 baseWind = windDirection.normalized * windSpeed;

        // Flow Noise for vortex-like turbulence
        Vector3 turbulence = ComputeFlowNoise(position);

        // Building deflection around obstacles
        Vector3 deflection = ComputeBuildingDeflection(position);

        // Height-based effect: wind stronger at higher altitudes
        Vector3 heightEffect = new Vector3(0, position.y * heightWindFactor * 0.1f, 0);

        return baseWind + turbulence + deflection + heightEffect;
    }

    /// <summary>
    /// Creates flow noise (3D) to simulate swirling turbulence (vortexIntensity).
    /// </summary>
    Vector3 ComputeFlowNoise(Vector3 position)
    {
        float offset = Time.time * 0.1f;
        float noiseX = Mathf.PerlinNoise(position.y * turbulenceScale, position.z * turbulenceScale + offset);
        float noiseY = Mathf.PerlinNoise(position.x * turbulenceScale, position.z * turbulenceScale + offset);
        float noiseZ = Mathf.PerlinNoise(position.x * turbulenceScale, position.y * turbulenceScale + offset);

        return new Vector3(noiseX, noiseY, noiseZ) * vortexIntensity;
    }

    /// <summary>
    /// Redirects wind away from "Building"-tagged objects within a small sphere.
    /// </summary>
    Vector3 ComputeBuildingDeflection(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 5f);
        Vector3 deflection = Vector3.zero;

        foreach (var col in colliders)
        {
            if (col && col.CompareTag("Building"))
            {
                Vector3 directionAway = (position - col.transform.position).normalized;
                float distanceFactor = Mathf.Clamp01(1f - (Vector3.Distance(position, col.transform.position) / 5f));
                deflection += directionAway * distanceFactor * 2f;
            }
        }
        return deflection;
    }
}
