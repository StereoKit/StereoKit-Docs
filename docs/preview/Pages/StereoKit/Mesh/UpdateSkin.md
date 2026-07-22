---
layout: default
title: Mesh.UpdateSkin
description: Drives the per-frame CPU deformation for a skinned Mesh. SetSkin must have been called first. This walks every vertex, blends the bone transforms by weight, and re-uploads the deformed vertices to the GPU.  bonePalette holds the current world-space transform for each bone, in the same coordinate system the resting transforms passed to SetSkin were authored in. Its length must match the bone count supplied to SetSkin.  Because deformation mutates this Mesh's vertex buffer in place, two entities driven by different bone palettes need their own Mesh instance — use Copy on a shared source mesh to get per-instance deformation.
---
# [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html).UpdateSkin

<div class='signature' markdown='1'>
```csharp
void UpdateSkin(Matrix[] bonePalette)
```
Drives the per-frame CPU deformation for a skinned
Mesh. SetSkin must have been called first. This walks every
vertex, blends the bone transforms by weight, and re-uploads
the deformed vertices to the GPU.

`bonePalette` holds the current world-space transform for
each bone, in the same coordinate system the resting
transforms passed to SetSkin were authored in. Its length
must match the bone count supplied to SetSkin.

Because deformation mutates this Mesh's vertex buffer in
place, two entities driven by different bone palettes need
their own Mesh instance — use Copy on a shared source mesh
to get per-instance deformation.
</div>

|  |  |
|--|--|
|Matrix[] bonePalette|World-space transform per bone for this frame. Length must match the bone count supplied to SetSkin.|




