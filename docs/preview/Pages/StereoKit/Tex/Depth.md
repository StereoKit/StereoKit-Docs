---
layout: default
title: Tex.Depth
description: The depth of the texture, in pixels. Only meaningful for 3D (volume) textures created with TexType.Volume — for 2D, array, and cubemap textures this is 1. This will be a blocking call if AssetState is less than LoadedMeta.
---
# [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html).Depth

<div class='signature' markdown='1'>
int Depth{ get }
</div>

## Description
The depth of the texture, in pixels. Only meaningful
for 3D (volume) textures created with TexType.Volume — for 2D,
array, and cubemap textures this is 1. This will be a blocking
call if AssetState is less than LoadedMeta.

