---
layout: default
title: Tex.FromCubemap
description: Creates a cubemap texture from a single file! This will load KTX2 files with 6 surfaces, or convert equirectangular images into cubemap images. KTX2 files are the _fastest_ way to load a cubemap, but equirectangular images can be acquired quite easily! Equirectangular images look like an unwrapped globe with the poles all stretched out, and are sometimes referred to as HDRIs.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).FromCubemap

<div class='signature' markdown='1'>
```csharp
static Tex FromCubemap(string cubemapFile, bool sRGBData, int loadPriority)
```
Creates a cubemap texture from a single file! This will
load KTX2 files with 6 surfaces, or convert equirectangular images
into cubemap images. KTX2 files are the _fastest_ way to load a
cubemap, but equirectangular images can be acquired quite easily!
Equirectangular images look like an unwrapped globe with the poles
all stretched out, and are sometimes referred to as HDRIs.
</div>

|  |  |
|--|--|
|string cubemapFile|Filename of the cubemap image.|
|bool sRGBData|Is this image color data in sRGB format,             or is it normal/metal/rough/data that's not for direct display?             sRGB colors get converted to linear color space on the graphics             card, so getting this right can have a big impact on visuals.|
|int loadPriority|The priority sort order for this asset             in the async loading system. Lower values mean loading sooner.|
|RETURNS: [Tex]({{site.url}}/Pages/StereoKit/Tex.html)|A Cubemap texture asset!|




