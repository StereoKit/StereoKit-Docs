---
layout: default
title: TexFormat.Rgba64s
description: Red/Green/Blue/Transparency data channels, at 16 bits per-channel! This is not common, but you might encounter it with raw photos, or HDR images. The s postfix indicates that the raw color data is stored as a signed 16 bit integer, which is then normalized into the -1, +1 floating point range on the GPU.
---
# [TexFormat]({{site.url}}/Pages/StereoKit/TexFormat.html).Rgba64s

<div class='signature' markdown='1'>
static [TexFormat]({{site.url}}/Pages/StereoKit/TexFormat.html) Rgba64s
</div>

## Description
Red/Green/Blue/Transparency data channels, at 16 bits
per-channel! This is not common, but you might encounter it with
raw photos, or HDR images. The s postfix indicates that the raw
color data is stored as a signed 16 bit integer, which is then
normalized into the -1, +1 floating point range on the GPU.

