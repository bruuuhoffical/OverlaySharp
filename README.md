# OverlaySharp

> A transparent, clickable, resizable, always-on-top overlay framework for .NET 8 — powered by ImGui.NET  
> Designed for game ESPs, visual overlays, or diagnostic UIs.

**Created by [BRUUUH]**

---

### ✅ Features

- Transparent + topmost Form overlay
- Fully clickable or click-through (toggle with F1)
- Built-in ImGui.NET rendering (no unsafe code)
- Draw text, lines, boxes, circles
- Dual positioning system: raw `Vector2` or anchor keywords like `"bottom center"`
- Hotkey toggle for click-through (`F1`) and show/hide (`F2`)
- Overlay watermark: `OverlaySharp by BRUUUH`
- Supports any Windows target process window

---

### 📦 Installation

#### NuGet (coming soon)
```bash
dotnet add package OverlaySharp

# How to Use OverlaySharp (Full Docs Section)

⚙️ Step-by-Step Usage

1. Create Your ESP Class

Inherit from Overlay and override Render():

using OverlaySharp;
using ImGuiNET;
using System.Drawing;
using System.Numerics;

public class MyESP : Overlay
{
    public MyESP() : base(new OverlayConfig()) {}

    protected override void Render()
    {
        // ✅ Easy: anchor-based
        OverlayDraw.DrawText("top center", "OverlaySharp by BRUUUH", Color.LimeGreen);

        // ✅ Raw: pixel positions
        OverlayDraw.DrawBox(new Vector2(100, 200), 150, 80, Color.Red);

        // ✅ Draw line between 2 anchor points
        OverlayDraw.DrawLine("bottom left", "top right", Color.Yellow, 1.5f);
    }
}


---

2. Launch Overlay from Your App

using System.Diagnostics;
using System.Windows.Forms;

var process = Process.GetProcessesByName("HD-Player").FirstOrDefault();
if (process == null) return;

var overlay = new MyESP();
overlay.AttachTo(process.MainWindowHandle);
Application.Run(overlay);

> Replace "HD-Player" with the process name of the game/app you want to overlay.




---

🔤 Positioning Options

You can use either:

Raw Position	Anchor Keyword

new Vector2(150, 300)	"top left"
new Vector2(500, 100)	"middle center"
new Vector2(900, 700)	"bottom right"


Supported anchors:

"top left", "top center", "top right"

"middle left", "center" / "middle center", "middle right"

"bottom left", "bottom center", "bottom right"



---

🎨 Drawing API Summary

Method	Usage

OverlayDraw.DrawText(pos, text, color)	Draw text
OverlayDraw.DrawBox(pos, width, height, color, thickness)	Draw outline box
OverlayDraw.DrawLine(start, end, color, thickness)	Draw line
OverlayDraw.DrawCircle(center, radius, color)	Draw circle


PosHow to Use OverlaySharp (Full Docs Section)

⚙️ Step-by-Step Usage

1. Create Your ESP Class

Inherit from Overlay and override Render():

using OverlaySharp;
using ImGuiNET;
using System.Drawing;
using System.Numerics;

public class MyESP : Overlay
{
    public MyESP() : base(new OverlayConfig()) {}

    protected override void Render()
    {
        // ✅ Easy: anchor-based
        OverlayDraw.DrawText("top center", "OverlaySharp by BRUUUH", Color.LimeGreen);

        // ✅ Raw: pixel positions
        OverlayDraw.DrawBox(new Vector2(100, 200), 150, 80, Color.Red);

        // ✅ Draw line between 2 anchor points
        OverlayDraw.DrawLine("bottom left", "top right", Color.Yellow, 1.5f);
    }
}


---

2. Launch Overlay from Your App

using System.Diagnostics;
using System.Windows.Forms;

var process = Process.GetProcessesByName("HD-Player").FirstOrDefault();
if (process == null) return;

var overlay = new MyESP();
overlay.AttachTo(process.MainWindowHandle);
Application.Run(overlay);

> Replace "HD-Player" with the process name of the game/app you want to overlay.




---

🔤 Positioning Options

You can use either:

Raw Position	Anchor Keyword

new Vector2(150, 300)	"top left"
new Vector2(500, 100)	"middle center"
new Vector2(900, 700)	"bottom right"


Supported anchors:

"top left", "top center", "top right"

"middle left", "center" / "middle center", "middle right"

"bottom left", "bottom center", "bottom right"



---

🎨 Drawing API Summary

Method	Usage

OverlayDraw.DrawText(pos, text, color)	Draw text
OverlayDraw.DrawBox(pos, width, height, color, thickness)	Draw outline box
OverlayDraw.DrawLine(start, end, color, thickness)	Draw line
OverlayDraw.DrawCircle(center, radius, color)	Draw circle


Position can be Vector2 or anchor string like "center".


---

⌨️ Hotkeys

Key	Action

F1	Toggle click-through (on/off)
F2	Show/hide overlay



---

✅ NuGet Package (when ready)

dotnet add package OverlaySharp

> Until then, clone the repo, build in Release, and reference OverlaySharp.dll manually.




---

❗ Requirements

.NET 8.0

Windows OS (WinForms-based)

Reference ImGui.NET NuGet package (already handled)
How to Use OverlaySharp (Full Docs Section)

⚙️ Step-by-Step Usage

1. Create Your ESP Class

Inherit from Overlay and override Render():

using OverlaySharp;
using ImGuiNET;
using System.Drawing;
using System.Numerics;

public class MyESP : Overlay
{
    public MyESP() : base(new OverlayConfig()) {}

    protected override void Render()
    {
        // ✅ Easy: anchor-based
        OverlayDraw.DrawText("top center", "OverlaySharp by BRUUUH", Color.LimeGreen);

        // ✅ Raw: pixel positions
        OverlayDraw.DrawBox(new Vector2(100, 200), 150, 80, Color.Red);

        // ✅ Draw line between 2 anchor points
        OverlayDraw.DrawLine("bottom left", "top right", Color.Yellow, 1.5f);
    }
}


---

2. Launch Overlay from Your App

using System.Diagnostics;
using System.Windows.Forms;

var process = Process.GetProcessesByName("HD-Player").FirstOrDefault();
if (process == null) return;

var overlay = new MyESP();
overlay.AttachTo(process.MainWindowHandle);
Application.Run(overlay);

> Replace "HD-Player" with the process name of the game/app you want to overlay.




---

🔤 Positioning Options

You can use either:

Raw Position	Anchor Keyword

new Vector2(150, 300)	"top left"
new Vector2(500, 100)	"middle center"
new Vector2(900, 700)	"bottom right"


Supported anchors:

"top left", "top center", "top right"

"middle left", "center" / "middle center", "middle right"

"bottom left", "bottom center", "bottom right"



---

🎨 Drawing API Summary

Method	Usage

OverlayDraw.DrawText(pos, text, color)	Draw text
OverlayDraw.DrawBox(pos, width, height, color, thickness)	Draw outline box
OverlayDraw.DrawLine(start, end, color, thickness)	Draw line
OverlayDraw.DrawCircle(center, radius, color)	Draw circle


Position can be Vector2 or anchor string like "center".


---

⌨️ Hotkeys

Key	Action

F1	Toggle click-through (on/off)
F2	Show/hide overlay



---

✅ NuGet Package (when ready)

dotnet add package OverlaySharp

> Until then, clone the repo, build in Release, and reference OverlaySharp.dll manually.




---

❗ Requirements

.NET 8.0

Windows OS (WinForms-based)

Reference ImGui.NET NuGet package (already handled)
