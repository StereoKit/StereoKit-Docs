---
layout: default
title: MouseMode
description: How should the mouse cursor behave? This is only relevant on backends with a real cursor to control, the Simulator and Window backends. Elsewhere, the mode is remembered, but has nothing to act on.
---
# enum MouseMode

How should the mouse cursor behave? This is only relevant on backends with a
real cursor to control, the Simulator and Window backends. Elsewhere, the
mode is remembered, but has nothing to act on.

## Enum Values

|  |  |
|--|--|
|Hidden|The cursor is invisible, but behaves exactly as it does in normal mode. The mouse's position is still valid, and it can still leave the window.|
|Normal|The cursor is visible, and free to move anywhere, including outside the window. This is the default.|
|Relative|The cursor is invisible and locked in place, which is what you want for mouse-look style camera control. The mouse's position stops moving, and its position change becomes the only source of motion - reported in pixel-equivalent units, free of pointer acceleration, and never running out of room at the edge of the screen.|

## Examples

### Mouse-look camera control
`MouseMode.Relative` hides the cursor and pins it in place, so the
mouse can produce motion forever without ever reaching the edge of the
screen. `Mouse.pos` stops moving in this mode, and `Mouse.posChange` is
where all the motion shows up.

Note that the Simulator uses right click for its own flycam, so this is
best tried in the Window backend.
```csharp
static Vec2 lookAngle;
static void MouseLook()
{
	// Capture the mouse for as long as the right button is held
	if      (Input.Key(Key.MouseRight).IsJustActive  ()) Input.MouseMode = MouseMode.Relative;
	else if (Input.Key(Key.MouseRight).IsJustInactive()) Input.MouseMode = MouseMode.Normal;

	if (Input.MouseMode == MouseMode.Relative)
		lookAngle -= Input.Mouse.posChange * 0.1f;
}
```

### Mouse look
`MouseMode.Relative` is what you want for mouse-look style camera
control. The cursor is hidden and pinned in place, so `Mouse.pos` stops
changing, and `Mouse.posChange` becomes the only report of mouse motion.
The pointer never reaches the edge of the screen, so the view can keep
turning as far as the user cares to spin.

Capture the mouse only while the user is actually looking around, and
hand it back when they let go, so the rest of the time they still have a
cursor to click with. Note that `posChange` is an amount of motion rather
than a speed, so unlike a velocity it should _not_ be scaled by
`Time.Stepf`. Doing that would tie the sensitivity to the frame rate.
```csharp
float lookYaw;
float lookPitch;
void MouseLook()
{
	// The Simulator mode already provides a mouselook, and XR doesn't need
	// one, so this is only really useful in Window mode.
	if (SK.Settings.mode != AppMode.Window)
		return;

	if (Input.Key(Key.MouseRight).IsJustActive  ()) Input.MouseMode = MouseMode.Relative;
	if (Input.Key(Key.MouseRight).IsJustInactive()) Input.MouseMode = MouseMode.Normal;
	if (Input.MouseMode != MouseMode.Relative) return;

	// Relative mode reports raw mouse units instead of pixels, so this is
	// degrees per unit of motion, and wants tuning by feel.
	const float sensitivity = 0.1f;
	lookYaw   -= Input.Mouse.posChange.x * sensitivity;
	lookPitch -= Input.Mouse.posChange.y * sensitivity;
	// Stop just shy of straight up and down, or the view rolls over the top
	lookPitch  = Math.Clamp(lookPitch, -89.9f, 89.9f);

	Renderer.CameraRoot = Matrix.R(lookPitch, lookYaw, 0);
}
```

