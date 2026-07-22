---
layout: default
title: Tex.SetSize
description: Set the texture's size without providing any color data. In most cases, you should probably just call SetColors instead, but this can be useful if you're adding color data some other way, such as when blitting or rendering to it.
---
# [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html).SetSize

<div class='signature' markdown='1'>
```csharp
void SetSize(int width, int height, int arrayCount, int msaa)
```
Set the texture's size without providing any color data.
In most cases, you should probably just call SetColors instead,
but this can be useful if you're adding color data some other
way, such as when blitting or rendering to it.
</div>

|  |  |
|--|--|
|int width|Width in pixels of the texture. Powers of two are generally best!|
|int height|Height in pixels of the texture. Powers of two are generally best!|
|int arrayCount|How many surfaces are in this texture? A normal texture only has 1, but it can be useful to have multiple for certain rendering techniques or effects.|
|int msaa|Multisample anti-aliasing, this is only important for render target type textures! This is the number of fragments that are drawn for each pixel to reduce sparkling / aliasing artifacts.|




