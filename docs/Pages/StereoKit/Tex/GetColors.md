---
layout: default
title: Tex.GetColors
description: Retrieve the color data of the texture from the GPU. This can be a very slow operation, so use it cautiously. If the color array is the correct size, it will not be re-allocated.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).GetColors

<div class='signature' markdown='1'>
```csharp
void GetColors(Color32[]& colorData, int mipLevel)
```
Retrieve the color data of the texture from the GPU. This
can be a very slow operation, so use it cautiously. If the color
array is the correct size, it will not be re-allocated.
</div>

|  |  |
|--|--|
|Color32[]& colorData|An array of colors that will be filled out             with the texture's data. It can be null, or an incorrect size. If             so, it will be reallocated to the correct size.|
|int mipLevel|Retrieves the color data for a specific             mip-mapping level. This function will log a fail and return a black             array if an invalid mip-level is provided.|

<div class='signature' markdown='1'>
```csharp
Color32[] GetColors(int mipLevel)
```
Retrieve the color data of the texture from the GPU. This
can be a very slow operation, so use it cautiously.
</div>

|  |  |
|--|--|
|int mipLevel|Retrieves the color data for a specific             mip-mapping level. This function will log a fail and return a black             array if an invalid mip-level is provided.|
|RETURNS: Color32[]|The texture's color values in an array sized Width*Height.|




