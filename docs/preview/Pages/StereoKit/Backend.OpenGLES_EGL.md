---
layout: default
title: Backend.OpenGLES_EGL
description: When using OpenGL ES with the EGL loader for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is the default rendering backend for Android, and Linux builds can be configured to use this with the SK_LINUX_EGL cmake option when building the core StereoKitC library.
---
# static class Backend.OpenGLES_EGL

When using OpenGL ES with the EGL loader for rendering,
this contains a number of variables that may be useful for doing
advanced rendering tasks. This is the default rendering backend for
Android, and Linux builds can be configured to use this with the
SK_LINUX_EGL cmake option when building the core StereoKitC
library.

## Static Fields and Properties

|  |  |
|--|--|
|IntPtr [Context]({{site.url}}/preview/Pages/StereoKit/Backend.OpenGLES_EGL/Context.html)|This is the `EGLContext` StereoKit receives from `eglCreateContext`. (No longer supported, always returns IntPtr.Zero)|
|IntPtr [Display]({{site.url}}/preview/Pages/StereoKit/Backend.OpenGLES_EGL/Display.html)|This is the `EGLDisplay` StereoKit receives from `eglGetDisplay` (No longer supported, always returns IntPtr.Zero)|
