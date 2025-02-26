---
layout: default
title: Material.Transparency
description: What type of transparency does this Material use? Default is None. Transparency has an impact on performance, and draw order. Check the Transparency enum for details.
---
# [Material]({{site.url}}/Pages/StereoKit/Material.html).Transparency

<div class='signature' markdown='1'>
[Transparency]({{site.url}}/Pages/StereoKit/Transparency.html) Transparency{ get set }
</div>

## Description
What type of transparency does this Material use?
Default is None. Transparency has an impact on performance, and
draw order. Check the Transparency enum for details.


## Examples

### Additive Transparency
Here's an example material with additive transparency.
Transparent materials typically don't write to the depth buffer,
but this may vary from case to case. Note that the material's
alpha does not play any role in additive transparency! Instead,
you could make the material's tint darker.
```csharp
matAlphaAdd = Material.Default.Copy();
matAlphaAdd.Transparency = Transparency.Add;
matAlphaAdd.DepthWrite   = false;
```
![Additive transparency example]({{site.screen_url}}/MaterialAlphaAdd.jpg)
### Alpha Blending
Here's an example material with an alpha blend transparency.
Transparent materials typically don't write to the depth buffer,
but this may vary from case to case. Here we're setting the alpha
through the material's Tint value, but the diffuse texture's
alpha and the instance render color's alpha may also play a part
in the final alpha value.
```csharp
matAlphaBlend = Material.Default.Copy();
matAlphaBlend.Transparency = Transparency.Blend;
matAlphaBlend.DepthWrite   = false;
matAlphaBlend[MatParamName.ColorTint] = new Color(1, 1, 1, 0.75f);
```
![Alpha blend example]({{site.screen_url}}/MaterialAlphaBlend.jpg)
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

