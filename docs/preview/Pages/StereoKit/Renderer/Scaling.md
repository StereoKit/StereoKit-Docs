---
layout: default
title: Renderer.Scaling
description: This sets the size of the surface StereoKit renders to, as a multiple of the display's own resolution. In XR that's a multiple of OpenXR's recommended size, and in a window it's a multiple of the window's size, where the result is stretched back over the window at present. Note that the final resolution may also be clamped or quantized. Values above 1 have no effect in the Simulator and Window app modes, since a window is already at the display's real resolution. This property still reports what you set, so an app that also runs in XR keeps its setting. If known in advance, set this via SKSettings in initialization. This is a _very_ costly change to make, since it reallocates the render surface. Consider if ViewportScaling will work for you instead, and prefer that.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).Scaling

<div class='signature' markdown='1'>
static float Scaling{ get set }
</div>

## Description
This sets the size of the surface StereoKit renders to, as
a multiple of the display's own resolution. In XR that's a multiple
of OpenXR's recommended size, and in a window it's a multiple of the
window's size, where the result is stretched back over the window at
present. Note that the final resolution may also be clamped or
quantized. Values above 1 have no effect in the Simulator and Window
app modes, since a window is already at the display's real
resolution. This property still reports what you set, so an app
that also runs in XR keeps its setting. If known in advance, set
this via SKSettings in initialization. This is a _very_ costly
change to make, since it reallocates the render surface. Consider if
ViewportScaling will work for you instead, and prefer that.

