---
layout: default
title: Backend
description: This class exposes some of StereoKit's backend functionality. This allows for tighter integration with certain platforms, but also means your code becomes less portable. Everything in this class should be guarded by availability checks.
---
# static class Backend

This class exposes some of StereoKit's backend functionality.
This allows for tighter integration with certain platforms, but also
means your code becomes less portable. Everything in this class should
be guarded by availability checks.

## Static Fields and Properties

|  |  |
|--|--|
|[BackendGraphics]({{site.url}}/preview/Pages/StereoKit/BackendGraphics.html) [Graphics]({{site.url}}/preview/Pages/StereoKit/Backend/Graphics.html)|This describes the graphics API that StereoKit is using for rendering. StereoKit is Vulkan-only, so this will report [`BackendGraphics.Vulkan`]({{site.url}}/preview/Pages/StereoKit/BackendGraphics/Vulkan.html) on all supported platforms.|
|[BackendPlatform]({{site.url}}/preview/Pages/StereoKit/BackendPlatform.html) [Platform]({{site.url}}/preview/Pages/StereoKit/Backend/Platform.html)|What kind of platform is StereoKit running on? This can be important to tell you what APIs or functionality is available to the app.|
|[BackendXRType]({{site.url}}/preview/Pages/StereoKit/BackendXRType.html) [XRType]({{site.url}}/preview/Pages/StereoKit/Backend/XRType.html)|What technology is being used to drive StereoKit's XR functionality? OpenXR is the most likely candidate here, but if you're running the flatscreen Simulator, or running in the web with WebXR, then this will reflect that.|
