---
layout: default
title: MouseMode.Relative
description: The cursor is invisible and locked in place, which is what you want for mouse-look style camera control. The mouse's position stops moving, and its position change becomes the only source of motion - reported in pixel-equivalent units, free of pointer acceleration, and never running out of room at the edge of the screen.
---
# [MouseMode]({{site.url}}/preview/Pages/StereoKit/MouseMode.html).Relative

<div class='signature' markdown='1'>
static [MouseMode]({{site.url}}/preview/Pages/StereoKit/MouseMode.html) Relative
</div>

## Description
The cursor is invisible and locked in place, which is what you want for
mouse-look style camera control. The mouse's position stops moving, and
its position change becomes the only source of motion - reported in
pixel-equivalent units, free of pointer acceleration, and never running
out of room at the edge of the screen.


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

