---
layout: default
title: Tex.GetColorData
description: Retrieve the color data of the texture from the GPU. This can be a very slow operation, so use it cautiously.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).GetColorData

<div class='signature' markdown='1'>
```csharp
T[] GetColorData(int mipLevel, int structPerPixel)
```
Retrieve the color data of the texture from the GPU. This
can be a very slow operation, so use it cautiously.
</div>

|  |  |
|--|--|
|int mipLevel|Retrieves the color data for a specific             mip-mapping level. This function will log a fail and return a black             array if an invalid mip-level is provided.|
|int structPerPixel|The number of `T` that fit in a single             pixel. For example, if your texture format is RGBA128, and your T             is float, this value would be 4.|
|RETURNS: T[]|The texture's color values in an array sized Width*Height*structPerPixel.|

<div class='signature' markdown='1'>
```csharp
void GetColorData(T[]& colorData, int mipLevel, int structPerPixel)
```
Retrieve the color data of the texture from the GPU. This
can be a very slow operation, so use it cautiously.
</div>

|  |  |
|--|--|
|T[]& colorData|An array of colors that will be filled out             with the texture's data. It can be null, or an incorrect size. If             so, it will be reallocated to the correct size.|
|int mipLevel|Retrieves the color data for a specific             mip-mapping level. This function will log a fail and return a black             array if an invalid mip-level is provided.|
|int structPerPixel|The number of `T` that fit in a single             pixel. For example, if your texture format is RGBA128, and your T             is float, this value would be 4.|





## Examples

### Get data from a Tex
Reading texture data from a Tex can be a slow operation, since
texture memory lives on the GPU, and isn't generally optimized for
readability. But, sometimes you still have to do it! Just remember
to avoid doing it too often or casually, and be cautious about how
you treat the large amounts of memory involved.
```csharp
// Reading colors can be as simple as this! Remember to select a color
// format that matches the data stored in the texture, as StereoKit
// will not convert the data for you. Most images from file are 32 bit
// RGBA images!
Tex texture = Tex.FromFile("floor.png");
Color32[] colors = texture.GetColorData<Color32>();

// For a more complex texture, such as this generated texture with 32
// bits per channel, we can load the data into a float array, with 4
// floats per-pixel! A `Color` would probably be fine here too.
Tex texture2 = Tex.GenColor(Color.White, 16, 16, TexType.Image, TexFormat.Rgba128);
float[] colors2 = texture2.GetColorData<float>(0, 4);
```

