---
layout: default
title: TexFormat.Bc2RgbaSrgb
description: BC2/DXT3 sRGB with explicit 4-bit alpha, 8 bpp. Alpha gets 16 discrete levels - fine for blocky or dithered alpha but bands hard on smooth gradients. Bc3 is usually a better choice for smooth alpha; Bc2 is mostly historical.
---
# [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html).Bc2RgbaSrgb

<div class='signature' markdown='1'>
static [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) Bc2RgbaSrgb
</div>

## Description
BC2/DXT3 sRGB with explicit 4-bit alpha, 8 bpp. Alpha gets
16 discrete levels - fine for blocky or dithered alpha but
bands hard on smooth gradients. Bc3 is usually a better
choice for smooth alpha; Bc2 is mostly historical.

