## Unity 6 Wind Simulation
This repository contains a complete, out-of-the-box CFD-like wind simulation project for Unity 6. It replicates the visual aesthetics of Autodesk Flow Design and includes:

Continuous Wind Streamlines with velocity-based color gradients (legend included).
A Wind Source (a Plane) where wind streamlines originate.
A 40m Tall Building Placeholder (Cube scaled to (10, 40, 10)).
A Building Manager to add up to 5 building placeholders or import custom building models (OBJ/FBX).
UI Controls built with Unity’s UI Toolkit to:
Select wind presets (City, Coastal, Mountains, Storm, Custom)
Adjust wind speed, wind direction (X, Y, Z), and turbulence via sliders
Toggle GPU Compute mode (with failsafe CPU fallback)
Toggle EPW (EnergyPlus Weather) data support, load an EPW file, and select a day/hour
Display a wind speed legend (with a color gradient from slow (blue) to fast (red))
An Editor Script to auto-generate a sample scene with all required GameObjects.
The simulation is optimized for real-time performance in Unity 6 (6000.0.39f1 LTS) and automatically falls back to CPU mode if compute shaders aren’t supported.

## Table of Contents
Installation
Scene Setup
Scripts and Files
Usage
File Structure
Features
License
Installation

## Prerequisites
Unity 6 (6000.0.39f1 LTS)
Install via Unity Hub with the following modules:
Windows Build Support (DirectX 12)
Linux/macOS Build Support (Vulkan/Metal)
Universal Render Pipeline (URP)

## Creating the Project
Open Unity Hub and click New Project.
Select the "3D Sample Scene (URP)" template.
Name the project "Wind_Simulation" and choose a save location.
Click Create Project.

## Scene Setup
# Add the Wind Source
In the Unity Editor, select GameObject > 3D Object > Plane.
Rename it WindSource.
Set its Position to (0, 0.5, -10).
Set its Scale to (10, 1, 10).

# Add a 40m Tall Building Placeholder
Select GameObject > 3D Object > Cube.
Rename it Building.
Set its Position to (0, 20, 0) (placing its base at ground level and top at 40m).
Set its Scale to (10, 40, 10).
# Save the Scene
Go to File > Save As.
Save the scene as WindSimulation.unity inside the Assets/Scenes/ folder.
# Scripts and Files
All scripts are located in the Assets/Scripts/ folder. Below is an overview of each script:

# WindFlowManager.cs
Generates and updates wind streamlines based on user-adjustable parameters and turbulence.
(See Section 4.1 below for code.)

# WindUIManager.cs
Connects UI elements (from the UXML file) to the wind simulation, allowing the selection of presets and manual adjustment.
(See Section 4.2 below for code.)

# EPWManager.cs
Provides optional support for loading and parsing an EPW file. Users can select a day and hour to update the wind speed and direction accordingly.
(See Section 4.3 below for code.)

# BuildingManager.cs
Allows the addition (up to 5) and removal of building placeholders (40m tall cubes) via UI.
(See Section 4.4 below for code.)

# ModelImporter.cs
Enables importing of external building models (OBJ/FBX) via a UI button.
(See Section 4.5 below for code.)

# WindLegendUI.cs
Displays a wind speed legend (color gradient with minimum and maximum speed labels).
(See Section 4.6 below for code.)

# CreateSampleScene.cs (Editor Script)
Automatically creates a sample scene with the WindSource, Building, WindManager, BuildingManager, and UI GameObjects.
(See Section 4.7 below for code.)

UXML File
WindUI.uxml
Located in Assets/UI/, this file contains the complete UI layout including dropdowns, sliders, toggles, and buttons.
(See Section 5 below for code.)
Code Sections
4.1 WindFlowManager.cs
(See code block above in the Scripts and Files section.)

4.2 WindUIManager.cs
(See code block above in the Scripts and Files section.)

4.3 EPWManager.cs
(See code block above in the Scripts and Files section.)

4.4 BuildingManager.cs
(See code block above in the Scripts and Files section.)

4.5 ModelImporter.cs
(See code block above in the Scripts and Files section.)

4.6 WindLegendUI.cs
(See code block above in the Scripts and Files section.)

4.7 CreateSampleScene.cs
(See code block above in the Scripts and Files section.)

5. UI Document (WindUI.uxml)
(See code block above in the UI Document section.)

## File Structure
Copy
Edit
Wind_Simulation/
├── Assets/
│   ├── Editor/
│   │   └── CreateSampleScene.cs
│   ├── Prefabs/
│   │   ├── Building.prefab
│   │   └── WindLinePrefab.prefab
│   ├── Scenes/
│   │   └── WindSimulation.unity
│   ├── Scripts/
│   │   ├── BuildingManager.cs
│   │   ├── EPWManager.cs
│   │   ├── ModelImporter.cs
│   │   ├── WindFlowManager.cs
│   │   ├── WindLegendUI.cs
│   │   └── WindUIManager.cs
│   └── UI/
│       └── WindUI.uxml
├── ProjectSettings/
└── README.md
## Usage
# Open the Project in Unity 6:

# Launch Unity Hub, click Add, and select the project folder (Wind_Simulation).
Open the Sample Scene:

# In Unity, navigate to File > Open Scene, then select Assets/Scenes/WindSimulation.unity.
Assign UI Document:

# In your UIManagerObject, ensure that the UIDocument component’s Source Asset is set to Assets/UI/WindUI.uxml.
Run the Simulation:

Press the Play button in the Unity Editor.
Use the UI to:
Select a wind preset from the dropdown and click Apply Preset.
Adjust Wind Speed, Wind Direction (X, Y, Z), and Turbulence via sliders.
Toggle Use GPU Compute (it will automatically fall back to CPU mode if compute shaders are unsupported).
Toggle Use EPW Data and click Load EPW File to import a weather file; then select a Day and Hour to update the wind parameters.
Use Add Building to add up to 5 building placeholders or click Import Building Model to load an external OBJ/FBX file.
View the Wind Speed Legend on the UI, which displays the color gradient from 1 m/s to 20 m/s.
Extra Steps
If you need to auto-generate the sample scene, run the Editor script by selecting Tools > Create Wind Simulation Sample Scene from the Unity Editor menu.
Adjust the velocity gradient in the Inspector on the WindFlowManager component to fine-tune the color mapping.
Customize the UI further by editing the UXML file and adding a USS file for styling if desired.
Conclusion
This project is designed to work out-of-the-box in Unity 6 and provides a robust, interactive CFD-like wind simulation that matches the visual aesthetic of Autodesk Flow Design. Follow the above instructions to install, set up, and run the simulation. Feel free to adjust parameters and extend functionality as needed.

## License
GNU GENERAL PUBLIC LICENSE
Version 3, 29 June 2007

Copyright (C) 2024 

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.

---

### **Summary of GPL v3 License Terms**
1. **Freedom to Use & Modify** – You are free to use, modify, and distribute this software.
2. **Copyleft Requirement** – Any modifications or derivative works must also be open-source under GPL v3.
3. **No Warranty** – This software is provided "as-is" without any guarantees.

For full legal terms, visit [GNU.org](https://www.gnu.org/licenses/gpl-3.0.html).
