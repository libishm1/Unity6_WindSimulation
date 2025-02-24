# Unity 6 Wind Simulation

This repository contains a complete, out-of-the-box CFD-like wind simulation project for Unity 6. It replicates the visual aesthetics of Autodesk Flow Design and includes:

## Features
- **Continuous Wind Streamlines** with velocity-based color gradients (legend included).
- **A Wind Source** (a Plane) where wind streamlines originate.
- **A 40m Tall Building Placeholder** (Cube scaled to (10, 40, 10)).
- **A Building Manager** to add up to 5 building placeholders or import custom building models (OBJ/FBX).
- **UI Controls** built with Unity’s UI Toolkit:
  - Select wind presets (City, Coastal, Mountains, Storm, Custom)
  - Adjust wind speed, wind direction (X, Y, Z), and turbulence via sliders
  - Toggle GPU Compute mode (with failsafe CPU fallback)
  - Toggle EPW (EnergyPlus Weather) data support, load an EPW file, and select a day/hour
  - Display a wind speed legend (with a color gradient from slow (blue) to fast (red))
- **An Editor Script** to auto-generate a sample scene with all required GameObjects.
- **Optimized for real-time performance** in Unity 6 (6000.0.39f1 LTS) and automatically falls back to CPU mode if compute shaders aren’t supported.

## Table of Contents
- [Installation](#installation)
- [Scene Setup](#scene-setup)
- [Scripts and Files](#scripts-and-files)
- [Usage](#usage)
- [File Structure](#file-structure)
- [License](#license)

# Installation

## Prerequisites
- **Unity 6 (6000.0.39f1 LTS)**
  - Install via Unity Hub with the following modules:
    - Windows Build Support (DirectX 12)
    - Linux/macOS Build Support (Vulkan/Metal)
    - Universal Render Pipeline (URP)

## Creating the Project
1. Open Unity Hub and click **New Project**.
2. Select the **"3D Sample Scene (URP)"** template.
3. Name the project **"Wind_Simulation"** and choose a save location.
4. Click **Create Project**.

# Scene Setup

## Add the Wind Source
1. In the Unity Editor, select **GameObject > 3D Object > Plane**.
2. Rename it **WindSource**.
3. Set its **Position** to **(0, 0.5, -10)**.
4. Set its **Scale** to **(10, 1, 10)**.

## Add a 40m Tall Building Placeholder
1. Select **GameObject > 3D Object > Cube**.
2. Rename it **Building**.
3. Set its **Position** to **(0, 20, 0)** *(placing its base at ground level and top at 40m)*.
4. Set its **Scale** to **(10, 40, 10)**.

## Save the Scene
1. Go to **File > Save As**.
2. Save the scene as **WindSimulation.unity** inside **Assets/Scenes/**.

# Scripts and Files

All scripts are located in **Assets/Scripts/**. Below is an overview of each script:

- **WindFlowManager.cs** - Generates and updates wind streamlines based on user-adjustable parameters and turbulence.
- **WindUIManager.cs** - Connects UI elements (from the UXML file) to the wind simulation, allowing the selection of presets and manual adjustment.
- **EPWManager.cs** - Provides optional support for loading and parsing an EPW file. Users can select a day and hour to update the wind speed and direction accordingly.
- **BuildingManager.cs** - Allows the addition (up to 5) and removal of building placeholders (40m tall cubes) via UI.
- **ModelImporter.cs** - Enables importing of external building models (OBJ/FBX) via a UI button.
- **WindLegendUI.cs** - Displays a wind speed legend (color gradient with minimum and maximum speed labels).
- **CreateSampleScene.cs (Editor Script)** - Automatically creates a sample scene with the WindSource, Building, WindManager, BuildingManager, and UI GameObjects.

# File Structure
```
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
```

# License

### GNU GENERAL PUBLIC LICENSE v3 (GPL-3.0)
```
Version 3, 29 June 2007

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
```

