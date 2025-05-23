# OverlaySharp

> A transparent, clickable, resizable, always-on-top overlay framework for .NET 8 — powered by ImGui.NET  
> Designed for game ESPs, visual overlays, cheat menus, or diagnostic UIs.

**Created by [BRUUUH]**

---

### ✅ Features

- Transparent + topmost Form overlay
- Fully clickable or click-through (toggle with `F1`)
- ImGui.NET rendering (no unsafe code, no D3D required)
- Dual positioning system: raw `Vector2` or anchor keywords like `"bottom center"`
- Draw helpers: text, lines, boxes, circles
- Toggle overlay visibility with `F2`
- Auto-follow target process (e.g. games, emulators)
- Default watermark: `OverlaySharp by BRUUUH`
- Lightweight, NuGet-ready architecture

---

### 📦 Installation

#### NuGet (coming soon)
```bash
dotnet add package OverlaySharp
```

#### Manual
1. Clone/download this repo
2. Build in **Release**
3. Reference `OverlaySharp.dll` in your own project

---

## 📘 Usage Documentation

### 1. Create Your Custom Overlay Class

```csharp
using OverlaySharp;
using ImGuiNET;
using System.Drawing;
using System.Numerics;

public class MyESP : Overlay
{
    public MyESP() : base(new OverlayConfig()) {}

    protected override void Render()
    {
        OverlayDraw.DrawText("top center", "OverlaySharp by BRUUUH", Color.LimeGreen);
        OverlayDraw.DrawBox(new Vector2(100, 200), 150, 80, Color.Red);
        OverlayDraw.DrawLine("bottom left", "top right", Color.Yellow, 1.5f);
        OverlayDraw.DrawCircle("center", 60, Color.Aqua);
    }
}
```

---

### 2. Attach to a Process & Run

```csharp
using System.Diagnostics;
using System.Windows.Forms;

var proc = Process.GetProcessesByName("HD-Player").FirstOrDefault();
if (proc == null) return;

var overlay = new MyESP();
overlay.AttachTo(proc.MainWindowHandle);
Application.Run(overlay);
```

> Replace `"HD-Player"` with the name of your target process (game, emulator, etc.)

---

### 3. Anchor Keywords (Built-in Positioning)

OverlaySharp supports anchor keywords to easily position elements without using raw coordinates.

**Examples:**
- `"top left"`, `"top center"`, `"top right"`
- `"middle left"`, `"center"` / `"middle center"`, `"middle right"`
- `"bottom left"`, `"bottom center"`, `"bottom right"`

Or use raw:
```csharp
new Vector2(300, 500)
```

---

### 4. Drawing API Summary

| Method | Description |
|--------|-------------|
| `OverlayDraw.DrawText(pos, string, Color)` | Draws text |
| `OverlayDraw.DrawBox(pos, width, height, Color)` | Draws rectangle |
| `OverlayDraw.DrawLine(start, end, Color)` | Draws a line |
| `OverlayDraw.DrawCircle(center, radius, Color)` | Draws circle |

Position can be either:
- `Vector2`
- or anchor string like `"bottom right"`

---

### ⌨️ Hotkeys

| Key | Action |
|-----|--------|
| `F1` | Toggle click-through (mouse passthrough) |
| `F2` | Toggle visibility (show/hide overlay)    |

---

### ❗ Requirements

- .NET 8.0 SDK
- Windows OS (WinForms base)
- `ImGui.NET` package (already referenced internally)

---

### 📦 Publishing to NuGet (For You)

In your `.csproj`:

```xml
<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
<PackageId>OverlaySharp</PackageId>
<Version>1.0.0</Version>
<Authors>BRUUUH</Authors>
<Description>A transparent overlay framework using ImGui.NET for .NET 8</Description>
```

Then:
```bash
dotnet build -c Release
dotnet nuget push bin/Release/OverlaySharp.1.0.0.nupkg --api-key YOUR_KEY --source https://api.nuget.org/v3/index.json
```

---

### 💡 Coming Soon

- `OverlaySharp.DirectX` for high-performance rendering
- `DrawHealthBar`, `DrawFilledBox`, and advanced ESP helpers
- Streamer mode (`SetWindowDisplayAffinity`)
- Runtime UI settings / config panel

---

### 📄 License

MIT License. Free to use, modify, and fork.  
Respect the watermark, or rewrite your own overlay 😤

---

## ⭐ If you build something with OverlaySharp, star the repo & tag @BRUUUH on GitHub
