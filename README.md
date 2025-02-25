# Unity 6 Wind Simulation
This repository contains a complete, out-of-the-box CFD-like wind simulation project for Unity 6. It replicates the visual aesthetics of Autodesk Forma Flow Design and includes:

## 🌪 Features
✅ **Continuous Wind Streamlines** with velocity-based color gradients (legend included).  
✅ **Wind Source (Plane)** where wind streamlines originate.  
✅ **40m Tall Building Placeholders** (Cubes scaled to `(10, 40, 10)`).  
✅ **Building Manager** to add up to 5 building placeholders or import custom models (OBJ/FBX).  
✅ **UI Controls (Unity UI Toolkit) to:**  
   - Select **wind presets** (City, Coastal, Mountains, Storm, Custom).  
   - Adjust **wind speed, direction (X, Y, Z), turbulence, vortex intensity, and height-based wind effects**.  
   - Toggle **GPU Compute mode** (auto CPU fallback if unsupported).  
   - Toggle **EPW weather data** (select day/hour for real-world wind).  
   - Display a **wind speed legend** (color gradient from slow (blue) to fast (red)).  
✅ **Editor Script** to auto-generate a sample scene with all required GameObjects.  

This simulation is **optimized for real-time performance in Unity 6 (6000.0.39f1 LTS)** with GPU acceleration **(fallback to CPU if unsupported).**  

---

## 📌 Table of Contents
1. [Installation](#installation)  
2. [Scene Setup](#scene-setup)  
3. [Scripts and Files](#scripts-and-files)  
4. [Usage](#usage)  
5. [File Structure](#file-structure)  
6. [Features](#features)  
7. [License](#license)  

---

## 📥 Installation

### Prerequisites  
- **Unity 6 (6000.0.39f1 LTS)**  
- Install via Unity Hub with:  
  - ✅ **Windows Build Support (DirectX 12)**  
  - ✅ **Linux/macOS Build Support (Vulkan/Metal)**  
  - ✅ **Universal Render Pipeline (URP)**  

### Creating the Project  
1. **Open Unity Hub** → Click **New Project**.  
2. **Select** the `"3D Sample Scene (URP)"` template.  
3. **Set Name:** `"Wind_Simulation"` → **Choose Save Location**.  
4. **Click Create Project**.  

---

## 🌪 Scene Setup

### **1️⃣ Add the Wind Source**  
- **Unity Editor** → `GameObject > 3D Object > Plane`  
- **Rename:** `WindSource`  
- **Position:** `(0, 0.5, -10)`  
- **Scale:** `(10, 1, 10)`  

### **2️⃣ Add a 40m Tall Building Placeholder**  
- **Unity Editor** → `GameObject > 3D Object > Cube`  
- **Rename:** `Building`  
- **Position:** `(0, 20, 0)`  
- **Scale:** `(10, 40, 10)`  

### **3️⃣ Save the Scene**  
- **File > Save As** → `WindSimulation.unity` inside `Assets/Scenes/`  

---

## 🖥️ Scripts and Files

### **1️⃣ `WindFlowManager.cs`**  
- **Handles wind physics calculations.**  
- Uses **Bezier curves for wind paths** & **Flow Noise for turbulence**.  
- **GPU Compute Shader Toggle (auto CPU fallback).**  

### **2️⃣ `WindUIManager.cs`**  
- **Connects UI sliders** to wind speed, turbulence, and vortex intensity.  
- **Adds GPU toggle switch (CPU fallback if unsupported).**  

### **3️⃣ `BuildingManager.cs`**  
- **Adds/removes buildings dynamically via UI.**  
- **Buildings automatically interact with wind streamlines.**  

### **4️⃣ `EPWManager.cs`**  
- **Loads real-world wind data** from **EPW weather files**.  
- **Users can select date/hour** from UI.  

### **5️⃣ `WindLegendUI.cs`**  
- **Displays color-coded wind speed legend** (blue = slow, red = fast).  

### **6️⃣ `CreateSampleScene.cs` (Editor Script)**  
- **Auto-generates Wind Source, Buildings, UI, & WindManager.**  

### **7️⃣ `WindUI.uxml`**  
- **Controls UI layout (sliders, buttons, toggles).**  
- **Allows real-time adjustments.**  

---

## 📂 File Structure

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
│   │   ├── WindFlowManager.cs
│   │   ├── WindLegendUI.cs
│   │   ├── WindUIManager.cs
│   ├── UI/
│   │   └── WindUI.uxml
└── README.md
```

---

## 🎮 Usage

### **1️⃣ Open the Project in Unity 6**
- **Unity Hub** → Click **Add** → Select the project folder (`Wind_Simulation`).  

### **2️⃣ Open the Sample Scene**
- **Unity Editor** → `File > Open Scene` → Select `Assets/Scenes/WindSimulation.unity`.  

### **3️⃣ Assign UI Document**
- **In UIManagerObject**, ensure **UIDocument** component is linked to `Assets/UI/WindUI.uxml`.  

### **4️⃣ Run the Simulation**
1. **Press Play** in the Unity Editor.  
2. **Use the UI to:**  
   - **Select a wind preset** from the dropdown.  
   - **Adjust Wind Speed, Wind Direction (X, Y, Z), and Turbulence.**  
   - **Toggle GPU Compute Mode (fallback to CPU if unsupported).**  
   - **Load EPW Weather Data** (`Load File` → Select Date & Hour).  
   - **Add Buildings (max 5) or Import Custom OBJ/FBX Models.**  
   - **View the Wind Speed Legend** (color gradient).  

---

## 🛠 Extra Steps

✅ **Auto-Generate Sample Scene**
- **Run Editor Script:** `Tools > Create Wind Simulation Sample Scene`.  

✅ **Adjust Velocity Gradient**
- **Inspector → WindFlowManager → Modify Gradient**.  

✅ **Customize UI Further**
- **Edit `WindUI.uxml`** (for styling).  

---

## 📝 License

**GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007**  

🔹 **This program is free software**: You can redistribute & modify it under **GPL v3**.  
🔹 **No Warranty**: This software is provided **"as-is"** without guarantees.  

For full legal terms, visit: [GNU.org](https://www.gnu.org/licenses/gpl-3.0.html).

---

## 🎯 Final Notes

✅ **Full GPU/CPU fail-safe system included.**  
✅ **Supports real-world wind conditions via EPW files.**  
✅ **Toggle between CPU & GPU compute shaders.**  
✅ **Wind turbulence, vortex strength, and deflection dynamically calculated.**  

🚀 **Next Steps?**  
1️⃣ **Higher fidelity wind simulation with more turbulence?**  
2️⃣ **Better GPU optimization for large-scale city modeling?**  
3️⃣ **A `.unitypackage` for one-click import?**  

Let me know how you'd like to refine it further! 🚀  
