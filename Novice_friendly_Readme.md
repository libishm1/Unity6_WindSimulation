# Unity 6 Wind Simulation – Novice Guide

## 1. Overview
Welcome to the **Unity 6 Wind Simulation Project**! This system provides:
- **Real-time wind flow** with **streamlines**, **turbulence**, **building deflection**, and **EPW weather data**.
- **UI Controls** to adjust **wind speed, turbulence, vortex intensity, GPU toggle,** etc.
- **Building Manager** to add or import buildings.
- **Failsafes** to ensure no placeholders or missing references.

**Perfect for novices** who want a quick, interactive wind simulation in **Unity 6**.

---

## 2. Installation & Setup

### 2.1 Prerequisites
1. **Unity Hub** with **Unity 6 (6000.0.39f1 LTS)** installed.
2. **Windows Build Support (DirectX 12)**, **Linux/macOS Build Support (Vulkan/Metal)**, and **Universal Render Pipeline (URP)** modules.

### 2.2 Creating a New Project
1. **Open Unity Hub** → **New Project**.
2. Select **"3D Sample Scene (URP)"** as the template.
3. Name it **"Wind_Simulation"** (or any name you like) → Choose a save location.
4. Click **Create**.

### 2.3 Adding This Wind Simulation Project
1. **Download** or **clone** this project’s files.
2. **Copy** the **Assets**, **Packages** (if included), and **ProjectSettings** folders **into your new project folder**.
3. **Open Unity** → **Add Project** (if needed) → Wait for re-import.
4. In the **Project window**, confirm you see folders like:
   - **`Assets/Scripts/`**
   - **`Assets/UI/`**
   - **`Assets/Scenes/`**  
   - **`ProjectSettings/`** (optional, if included)

---

## 3. Running the Scene

### 3.1 Open `WindSimulation.unity`
1. In Unity, **Project Window** → **Assets/Scenes/WindSimulation.unity**.
2. Double-click to open.

### 3.2 Ensure `WindUI.uxml` is Assigned
1. **Find** the object that has **`WindUIManager.cs`** (e.g. `UIManagerObject`).
2. **UIDocument** → Set **Source Asset** to **`WindUI.uxml`**.

### 3.3 Press Play
1. **Unity Editor** → **Play** button.
2. You should see **wind lines** across the scene.
3. **UI** appears with **sliders & toggles** for wind parameters.

---

## 4. Using the UI & Features

1. **Adjust Wind Speed** → See wind lines move faster or slower.
2. **Turbulence & Vortex Intensity** → Increase swirling & eddying around the lines.
3. **Height-Based Wind** → Higher `Y` positions see stronger wind.
4. **GPU Toggle** → If GPU supports compute shaders, it tries GPU mode. Otherwise, it falls back to CPU.
5. **EPWManager** → If assigned, load an `.epw` file to set wind speed/direction from real data.
6. **Add Buildings** → Use **`BuildingManager`** to place up to 5 building prefabs.
7. **Import OBJ** → Either from the **UI button** or the optional **Editor script** (`OBJImporterEditor`) in the Tools menu. Instantiates a new building model.

---

## 5. Final Steps for Novice Users

1. **Play & Experiment**: Move your camera around to see wind lines from different angles.
2. **Adjust Sliders**: Try maxing out vortex intensity or lowering wind speed to watch changes in real time.
3. **Add Buildings**: Place multiple structures and watch how wind lines bend around them.
4. **Import a `.obj`** (like a simple building mesh) to see it in the wind flow.
5. **Load an EPW file** if you want real-world wind data (like from your local weather station).

---

## 6. License 
**GNU GENERAL PUBLIC LICENSE v3**  
This project is free software under the GPLv3. You can redistribute and/or modify it, but it **comes with no warranty**.

---

### **You're all set!** This guide ensures a **smooth, out-of-the-box experience** with **Unity 6**. If you have further questions, feel free to extend the project. 🚀

