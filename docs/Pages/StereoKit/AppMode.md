---
layout: default
title: AppMode
description: Specifies a type of display mode StereoKit uses, like Mixed Reality headset display vs. a PC display, or even just rendering to an offscreen surface, or not rendering at all!
---
# enum AppMode

Specifies a type of display mode StereoKit uses, like
Mixed Reality headset display vs. a PC display, or even just
rendering to an offscreen surface, or not rendering at all!

## Enum Values

|  |  |
|--|--|
|None|No mode has been specified, default behavior will be used. StereoKit will pick XR in this case.|
|Offscreen|No display at all! StereoKit won't even render to a texture unless requested to. This may be good for running tests on a server, or doing graphics related tool or CLI work.|
|Simulator|Creates a flat window, and simulates some XR functionality. Great for development and debugging.|
|Window|Creates a flat window and displays to that, but doesn't simulate XR at all. You will need to control your own camera here. This can be useful if using StereoKit for non-XR 3D applications.|
|XR|Creates an OpenXR or WebXR instance, and drives display/input through that.|
