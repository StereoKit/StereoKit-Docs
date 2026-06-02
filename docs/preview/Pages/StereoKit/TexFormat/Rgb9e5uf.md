---
layout: default
title: TexFormat.Rgb9e5uf
description: Shared-exponent HDR R/G/B with 9-bit mantissa per channel and a 5-bit shared exponent. A compact HDR format that packs values way beyond the [0,1] range into just 32 bpp! No alpha though, and sharing the exponent means all three channels need similar magnitudes - perfect for environment maps! Usually sample-only; GPUs typically can't render to it.
---
# [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html).Rgb9e5uf

<div class='signature' markdown='1'>
static [TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) Rgb9e5uf
</div>

## Description
Shared-exponent HDR R/G/B with 9-bit mantissa per channel
and a 5-bit shared exponent. A compact HDR format that packs
values way beyond the [0,1] range into just 32 bpp! No alpha
though, and sharing the exponent means all three channels
need similar magnitudes - perfect for environment maps!
Usually sample-only; GPUs typically can't render to it.

