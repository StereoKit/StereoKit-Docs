---
layout: default
title: Renderer.GetClip
description: This retrieves the current near and far clipping planes for the perspective matrix of the primary draw surface.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).GetClip

<div class='signature' markdown='1'>
```csharp
static void GetClip(Single& nearPlane, Single& farPlane)
```
This retrieves the current near and far clipping planes
for the perspective matrix of the primary draw surface.
</div>

|  |  |
|--|--|
|Single& nearPlane|The GPU discards pixels that are too             close to the camera, this is that distance! It will be larger             than zero, due to the projection math, which also means that             numbers too close to zero will produce z-fighting artifacts. This             has an enforced minimum of 0.001, but will probably be closer to             0.1.|
|Single& farPlane|At what distance from the camera does the             GPU discard pixel? This is not true distance, but rather Z-axis             distance from zero in View Space coordinates!|




