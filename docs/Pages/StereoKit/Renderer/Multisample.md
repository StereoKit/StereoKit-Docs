---
layout: default
title: Renderer.Multisample
description: Allows you to set the multisample (MSAA) level of the render surface. Valid values are 1, 2, 4, 8, 16, though some OpenXR runtimes may clamp this to lower values. Note that while this can greatly smooth out edges, it also greatly increases RAM usage and fill rate, so use it sparingly. Only works in XR mode. If known in advance, set this via SKSettings in initialization. This is a _very_ costly change to make.
---
# [Renderer]({{site.url}}/Pages/StereoKit/Renderer.html).Multisample

<div class='signature' markdown='1'>
static int Multisample{ get set }
</div>

## Description
Allows you to set the multisample (MSAA) level of the
render surface. Valid values are 1, 2, 4, 8, 16, though some OpenXR
runtimes may clamp this to lower values. Note that while this can
greatly smooth out edges, it also greatly increases RAM usage and
fill rate, so use it sparingly. Only works in XR mode. If known in
advance, set this via SKSettings in initialization. This is a
_very_ costly change to make.

