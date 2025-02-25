# Unity 6 Wind Simulation – Beginner Guide

## 🌪 Overview
Welcome to the **Unity 6 Wind Simulation Project**! This real-time simulation includes:
- **Streamline wind visualization** with **color-coded velocity & turbulence**.
- **Adjustable wind properties** (speed, turbulence, vortex intensity, GPU toggle).
- **Building deflection system** (wind redirects around objects).
- **Real-world weather data support** (via EPW files).

Designed for **novices**, this guide will help you **set up & run** the simulation in **Unity 6**.

---

## 📥 Installation & Setup

### ✅ 1. Prerequisites
- **Unity Hub** with **Unity 6 (6000.0.39f1 LTS)** installed.
- **Universal Render Pipeline (URP)** enabled.
- **Windows/Linux/macOS Build Support**.

### ✅ 2. Creating a New Unity Project
1. Open **Unity Hub** → **New Project**.
2. Select **"3D Sample Scene (URP)"** template.
3. Name it **"Wind_Simulation"** → Click **Create**.

### ✅ 3. Adding the Wind Simulation Files
1. **Download** this repository.
2. Copy **`Assets/`**, **`ProjectSettings/`**, and **`Packages/`** into your new project folder.
3. Open Unity **(if not open)** → Click **Add Project** → Select the folder.
4. **Wait for Unity to re-import**.

---

## 🎮 Running the Simulation

### 🎬 1. Open the Scene
- **Project Window** → `Assets/Scenes/WindSimulation.unity` → **Double-click to open**.

### 🎛 2. Assign the UI
1. **Find the GameObject** with `WindUIManager.cs` (e.g. `UIManagerObject`).
2. **In the Inspector**, set **UIDocument > Source Asset** to `WindUI.uxml`.

### ▶ 3. Press Play
- The wind simulation **runs in real time**.
- UI appears with **sliders, toggles & buttons**.

---

## 🌟 Features & Controls

### 🏙 **Building Management**
- **`Add Building`** → Places a **40m cube** as a wind obstacle.
- **`Import OBJ`** → Loads custom **building models** (`.obj` or `.fbx`).

### 💨 **Wind Controls**
- **`Wind Speed`** → Adjusts airflow velocity.
- **`Turbulence`** → Controls random swirls.
- **`Vortex Intensity`** → Increases eddies & rotation.
- **`Height-Based Wind`** → Higher buildings face stronger winds.
- **`GPU Compute`** → If supported, **faster wind updates** (else, CPU fallback).

### 🌀 **Real-World Wind Data (EPW)**
- **Load an `.epw` file** → WindSpeed & Direction auto-adjust to real weather.

---

## 🛠 Additional Tools

### 📂 **Importing OBJ/FBX Models**
- **Click "Import Building Model"** → Select `.obj` or `.fbx`.
- The model **loads into the scene** and acts as a wind obstacle.

### 🔧 **Auto-Generate Sample Scene** *(Editor-Only)*
- **Unity Menu** → `"Tools > Create Wind Simulation Sample Scene"`.

---

## 🏗 How the Wind Works

### 🌊 **Wind Lines (Streamlines)**
- Generated using **Bezier curves** for **smooth airflow**.
- Color-coded: **Blue = Slow**, **Red = Fast**.

### ⛩ **Building Deflection**
- **Wind bends around obstacles** tagged `"Building"`.
- Uses **Physics OverlapSphere** to detect structures.

### ⚙ **GPU/CPU Performance**
- If **GPU Compute** is supported, it’s **10x faster**.
- If **GPU isn’t available**, it **automatically switches to CPU**.

---

## 📜 License: GPL v3

- **✅ You can modify & share this project freely**.
- **⚠ If you distribute changes, they must remain open-source**.
- **⚠ No Warranty: Use at your own risk.**

Full license: [GNU GPL v3](https://www.gnu.org/licenses/gpl-3.0.html)

---

### 🎯 **Ready to Start?** Press **Play** & enjoy your **real-time wind simulation**! 🚀
