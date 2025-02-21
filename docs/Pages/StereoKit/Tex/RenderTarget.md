---
layout: default
title: Tex.RenderTarget
description: This will assemble a texture ready for rendering to! It creates a render target texture with no mip maps and a depth buffer attached.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).RenderTarget

<div class='signature' markdown='1'>
```csharp
static Tex RenderTarget(int width, int height, int multisample, TexFormat colorFormat, TexFormat depthFormat)
```
This will assemble a texture ready for rendering to! It
creates a render target texture with no mip maps and a depth buffer
attached.
</div>

|  |  |
|--|--|
|int width|Width in pixels.|
|int height|Height in pixels|
|int multisample|Multisample level, or MSAA. This should             be 1, 2, 4, 8, or 16. The results will have moother edges with             higher values, but will cost more RAM and time to render. Note that             GL platforms cannot trivially draw a multisample > 1 texture in a             shader.|
|[TexFormat]({{site.url}}/Pages/StereoKit/TexFormat.html) colorFormat|The format of the color surface.|
|[TexFormat]({{site.url}}/Pages/StereoKit/TexFormat.html) depthFormat|The format of the depth buffer. If this             is None, no depth buffer will be attached to this rendertarget.|
|RETURNS: [Tex]({{site.url}}/Pages/StereoKit/Tex.html)|Returns a texture set up as a rendertarget.|




