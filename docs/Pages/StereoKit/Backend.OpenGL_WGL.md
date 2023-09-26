---
layout: default
title: Backend.OpenGL_WGL
description: When using OpenGL with the WGL loader for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is Windows only, and requires gloabally defining SKG_FORCE_OPENGL when building the core StereoKitC library.
---
# static class Backend.OpenGL_WGL

When using OpenGL with the WGL loader for rendering, this
contains a number of variables that may be useful for doing
advanced rendering tasks. This is Windows only, and requires
gloabally defining SKG_FORCE_OPENGL when building the core
StereoKitC library.

## Static Fields and Properties

|  |  |
|--|--|
|IntPtr [HDC]({{site.url}}/Pages/StereoKit/Backend.OpenGL_WGL/HDC.html)|This is the Handle to Device Context `HDC` StereoKit uses with `wglMakeCurrent`.|
|IntPtr [HGLRC]({{site.url}}/Pages/StereoKit/Backend.OpenGL_WGL/HGLRC.html)|This is the Handle to an OpenGL Rendering Context `HGLRC` StereoKit uses with `wglMakeCurrent`.|
