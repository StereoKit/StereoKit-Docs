---
layout: default
title: TexFormat.Bc1RgbSrgb
description: BC1/DXT1 sRGB RGB, no alpha, 4 bpp. Each 4x4 block of pixels gets squished into 8 bytes, so a texture only takes a quarter of Rgba32's memory. Quality is good for opaque diffuse textures, though artifacts can show up in smooth gradients. Widely supported on desktop and console GPUs - not so much on mobile.
---
# [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html).Bc1RgbSrgb

<div class='signature' markdown='1'>
static [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) Bc1RgbSrgb
</div>

## Description
BC1/DXT1 sRGB RGB, no alpha, 4 bpp. Each 4x4 block of pixels
gets squished into 8 bytes, so a texture only takes a
quarter of Rgba32's memory. Quality is good for opaque
diffuse textures, though artifacts can show up in smooth
gradients. Widely supported on desktop and console GPUs -
not so much on mobile.

