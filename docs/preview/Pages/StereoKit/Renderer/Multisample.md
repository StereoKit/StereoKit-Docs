---
layout: default
title: Renderer.Multisample
description: Allows you to set the multisample (MSAA) level of the render surface. Valid values are 1, 2, 4, and 8, though this is clamped to what the GPU actually supports. Note that while this can greatly smooth out edges, it also increases RAM usage and fill rate. How much it costs depends a lot on the GPU! Tiled renderers, like the mobile chips in most standalone XR headsets, resolve MSAA in tile memory, which makes it nearly free. Desktop GPUs instead pay memory bandwidth for the multisampled surface and for resolving it, so MSAA is far more expensive there, especially at high resolutions. A value of 1 skips the multisampled surface entirely. If known in advance, set this via SKSettings in initialization. This is a _very_ costly change to make. Defaults to 4.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).Multisample

<div class='signature' markdown='1'>
static int Multisample{ get set }
</div>

## Description
Allows you to set the multisample (MSAA) level of the
render surface. Valid values are 1, 2, 4, and 8, though this is
clamped to what the GPU actually supports. Note that while this
can greatly smooth out edges, it also increases RAM usage and
fill rate. How much it costs depends a lot on the GPU! Tiled
renderers, like the mobile chips in most standalone XR headsets,
resolve MSAA in tile memory, which makes it nearly free. Desktop
GPUs instead pay memory bandwidth for the multisampled surface
and for resolving it, so MSAA is far more expensive there,
especially at high resolutions. A value of 1 skips the
multisampled surface entirely. If known in advance, set this via
SKSettings in initialization. This is a _very_ costly change to
make. Defaults to 4.

