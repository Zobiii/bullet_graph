from pathlib import Path

# Inhalt der README.md-Datei
readme_content = """# 🎯 BulletGraph

**BulletGraph** is a lightweight 2D ballistic trajectory simulator built with C# and WinForms.  
Enter your initial height, launch angle, and speed — and watch the projectile fly!

---

## 🚀 Features

- 🔢 Input-based simulation (Height, Angle, Speed)
- 📈 Real-time trajectory graph
- 🧠 Accurate physics using gravity and motion equations
- 📐 Scaled graph output with auto-adjusting axes
- 🎯 Max height and impact distance displayed live
- 💡 Clean modular structure: Core, Rendering, UI

---

## 📷 Screenshot

![BulletGraph UI Preview](preview.png)

---

## 🧱 Project Structure

- `Core/` – Physics, constants, time management
- `Rendering/` – Graph rendering and drawing logic
- `Simulation/` – Bullet models and updates
- `UI/` – Forms and input controls
- `Logging/` – Optional debug and info logs

---

## 🛠️ Getting Started

### Requirements

- .NET 8.0 or newer
- Visual Studio 2022 or VS Code

### Run Locally

```bash
git clone https://github.com/yourname/BulletGraph.git
cd BulletGraph
dotnet build
dotnet run
