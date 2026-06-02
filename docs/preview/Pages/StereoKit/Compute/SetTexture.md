---
layout: default
title: Compute.SetTexture
description: Bind a texture to a named resource in the shader! If you're writing to it (RWTexture2D), the texture _must_ have TexType.Compute set, and use a format like TexFormat.Rgba128. Read-only Texture2D bindings work with any texture. Fallbacks are resolved at Dispatch time, so textures that are still loading will Just Work.
---
# [Compute]({{site.url}}/preview/Pages/StereoKit/Compute.html).SetTexture

<div class='signature' markdown='1'>
```csharp
bool SetTexture(string name, Tex texture)
```
Bind a texture to a named resource in the shader!
If you're writing to it (RWTexture2D), the texture _must_
have TexType.Compute set, and use a format like
TexFormat.Rgba128. Read-only Texture2D bindings work with
any texture. Fallbacks are resolved at Dispatch time, so
textures that are still loading will Just Work.
</div>

|  |  |
|--|--|
|string name|The texture name in the HLSL shader.             Must match exactly!|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) texture|The texture to bind.|
|RETURNS: bool|True if a matching resource was found in the shader, false if the name didn't match anything.|




