---
layout: default
title: Backend.OpenGL_GLX
description: When using OpenGL with the GLX loader for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is the default rendering backend for Linux.
---
# static class Backend.OpenGL_GLX

When using OpenGL with the GLX loader for rendering, this
contains a number of variables that may be useful for doing
advanced rendering tasks. This is the default rendering backend for
Linux.

## Static Fields and Properties

|  |  |
|--|--|
|IntPtr [Context]({{site.url}}/Pages/StereoKit/Backend.OpenGL_GLX/Context.html)|This is the `GLXContext` that StereoKit uses with `glXMakeCurrent`|
|IntPtr [Display]({{site.url}}/Pages/StereoKit/Backend.OpenGL_GLX/Display.html)|This is the `Display*` from X used to create the GLX context.|
|IntPtr [Drawable]({{site.url}}/Pages/StereoKit/Backend.OpenGL_GLX/Drawable.html)|This is the `GLXDrawable` that StereoKit uses with `glXMakeCurrent`.|
