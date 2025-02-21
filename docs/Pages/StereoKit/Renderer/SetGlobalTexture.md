---
layout: default
title: Renderer.SetGlobalTexture
description: This attaches a texture resource globally across all shaders. StereoKit uses this to attach the sky cubemap for use in reflections across all materials (register 11). It can be used for things like shadowmaps, wind data, etc. Prefer a higher registers (11+) to prevent conflicting with normal Material textures.
---
# [Renderer]({{site.url}}/Pages/StereoKit/Renderer.html).SetGlobalTexture

<div class='signature' markdown='1'>
```csharp
static void SetGlobalTexture(int textureRegister, Tex tex)
```
This attaches a texture resource globally across all
shaders. StereoKit uses this to attach the sky cubemap for use in
reflections across all materials (register 11). It can be used for
things like shadowmaps, wind data, etc. Prefer a higher registers
(11+) to prevent conflicting with normal Material textures.
</div>

|  |  |
|--|--|
|int textureRegister|The texture resource register the             texture will bind to. SK uses register 11 already, so values above             that should be fine.|
|[Tex]({{site.url}}/Pages/StereoKit/Tex.html) tex|The texture to assign globally. Setting null here             will clear any texture that is currently bound.|




