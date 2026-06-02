---
layout: default
title: BackendGraphics
description: This describes the graphics API that StereoKit is using for rendering.
---
# enum BackendGraphics

This describes the graphics API that StereoKit is using for rendering.

## Enum Values

|  |  |
|--|--|
|D3D11|DirectX's Direct3D11 is used for rendering! This is used by default on Windows. (No longer supported)|
|None|An invalid default value.|
|OpenGL_GLX|OpenGL is used for rendering, using GLX (OpenGL Extension to the X Window System) for loading. This is used by default on Linux. (No longer supported)|
|OpenGL_WGL|OpenGL is used for rendering, using WGL (Windows Extensions to OpenGL) for loading. Native developers can configure SK to use this on Windows. (No longer supported)|
|OpenGLES_EGL|OpenGL ES is used for rendering, using EGL (EGL Native Platform Graphics Interface) for loading. This is used by default on Android, and native developers can configure SK to use this on Linux. (No longer supported)|
|Vulkan|Vulkan is used for rendering, this works basically on every platform, and is the only backend StereoKit currently supports!|
|WebGL|WebGL is used for rendering. This is used by default on Web.|
