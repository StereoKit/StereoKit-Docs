---
layout: default
title: Transparency.MSAA
description: Also known as Alpha To Coverage, this mode uses MSAA samples to create transparency. This works with a z-buffer and therefore functionally behaves more like an opaque material, but has a quantized number of "transparent values" it supports rather than a full range of  0-255 or 0-1. For 4x MSAA, this will give only 4 different transparent values, 8x MSAA only 8, etc. From a performance perspective, MSAA usually is only costly around triangle edges, but using this mode, MSAA is used for the whole triangle.
---
# [Transparency]({{site.url}}/Pages/StereoKit/Transparency.html).MSAA

<div class='signature' markdown='1'>
static [Transparency]({{site.url}}/Pages/StereoKit/Transparency.html) MSAA
</div>

## Description
Also known as Alpha To Coverage, this mode uses MSAA samples to
create transparency. This works with a z-buffer and therefore
functionally behaves more like an opaque material, but has a
quantized number of "transparent values" it supports rather than
a full range of  0-255 or 0-1. For 4x MSAA, this will give only
4 different transparent values, 8x MSAA only 8, etc.
From a performance perspective, MSAA usually is only costly
around triangle edges, but using this mode, MSAA is used for the
whole triangle.


## Examples

### MSAA (Alpha to Coverage)
Here's an example material with a transparency mode that utilizes
MSAA samples for blending. Also known as Alpha To Coverage, this
takes advantage of the fact that MSAA can generate multiple
fragments per-pixel while utilizing the zbuffer, and then blend
them together before presenting the image. This means you can dodge
a couple of z-sorting artifacts, but with a limited/quantized
number of transparency "values" equivalent to the number of MSAA
samples.
```csharp
matMSAABlend = Material.Default.Copy();
matMSAABlend.Transparency = Transparency.MSAA;
matMSAABlend[MatParamName.ColorTint] = new Color(1, 1, 1, 0.75f);
```
![MSAA transparency example]({{site.screen_url}}/MaterialMSAABlend.jpg)

