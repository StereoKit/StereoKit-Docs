---
layout: default
title: SKSettings.depthMode
description: What kind of depth buffer should StereoKit use? A fast one, a detailed one, one that uses stencils? By default StereoKit will let the XR runtime choose, which typically results in fast, 16bit depth buffers for battery powered devices, and detailed 32bit depth buffers on PCs. If the requested mode is not available, StereoKit will fall back to the XR runtime's preference.
---
# [SKSettings]({{site.url}}/preview/Pages/StereoKit/SKSettings.html).depthMode

<div class='signature' markdown='1'>
[DepthMode]({{site.url}}/preview/Pages/StereoKit/DepthMode.html) depthMode
</div>

## Description
What kind of depth buffer should StereoKit use? A fast
one, a detailed one, one that uses stencils? By default StereoKit
will let the XR runtime choose, which typically results in fast,
16bit depth buffers for battery powered devices, and detailed 32bit
depth buffers on PCs. If the requested mode is not available,
StereoKit will fall back to the XR runtime's preference.

