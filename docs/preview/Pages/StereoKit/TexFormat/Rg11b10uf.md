---
layout: default
title: TexFormat.Rg11b10uf
description: Packed HDR R/G/B as unsigned floats - 11 bits for R and G, 10 for B, no alpha. A great compact HDR format. holds values way beyond the [0,1] range that Rgba32 maxes out at, while still fitting in 32 bpp! Great for HDR render targets and intermediate compute buffers. Not universally supported as a render target, so watch for that!
---
# [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html).Rg11b10uf

<div class='signature' markdown='1'>
static [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) Rg11b10uf
</div>

## Description
Packed HDR R/G/B as unsigned floats - 11 bits for R and G,
10 for B, no alpha. A great compact HDR format: holds values
way beyond the [0,1] range that Rgba32 maxes out at, while
still fitting in 32 bpp! Great for HDR render targets and
intermediate compute buffers. Not universally supported as a
render target, so watch for that!

