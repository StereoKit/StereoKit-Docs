---
layout: default
title: Mouse.posChange
description: How much has the mouse moved during this frame? This is normally just the change in pos, measured in pixels. In relative mouse mode pos is frozen and this becomes the only source of motion, in the mouse's raw device units rather than pixels.
---
# [Mouse]({{site.url}}/preview/Pages/StereoKit/Mouse.html).posChange

<div class='signature' markdown='1'>
[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) posChange
</div>

## Description
How much has the mouse moved during this frame? This is normally just the
change in `pos`, measured in pixels. In relative mouse mode `pos` is frozen
and this becomes the only source of motion, in the mouse's raw device units
rather than pixels.


## Examples

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

