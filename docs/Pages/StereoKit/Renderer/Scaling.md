---
layout: default
title: Renderer.Scaling
description: OpenXR has a recommended default for the main render surface, this variable allows you to set SK's surface to a multiple of the recommended size. Note that the final resolution may also be clamped or quantized. Only works in XR mode. If known in advance, set this via SKSettings in initialization. This is a _very_ costly change to make. Consider if ViewportScaling will work for you instead, and prefer that.
---
# [Renderer]({{site.url}}/Pages/StereoKit/Renderer.html).Scaling

<div class='signature' markdown='1'>
static float Scaling{ get set }
</div>

## Description
OpenXR has a recommended default for the main render
surface, this variable allows you to set SK's surface to a multiple
of the recommended size. Note that the final resolution may also be
clamped or quantized. Only works in XR mode. If known in advance,
set this via SKSettings in initialization. This is a _very_ costly
change to make. Consider if ViewportScaling will work for you
instead, and prefer that.

