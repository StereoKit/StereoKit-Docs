---
layout: default
title: Font.FromFamily
description: Loads font from a specified list of font family names
---
# [Font]({{site.url}}/Pages/StereoKit/Font.html).FromFamily

<div class='signature' markdown='1'>
```csharp
static Font FromFamily(string fontFamily)
```
Loads font from a specified list of font family names
</div>

|  |  |
|--|--|
|string fontFamily|List of font family names separated by comma(,)             similar to a list of names css allows.|
|RETURNS: [Font]({{site.url}}/Pages/StereoKit/Font.html)|A font from the given font family names, Most of the OS provide fallback fonts, hence there will always be a set of fonts.|




