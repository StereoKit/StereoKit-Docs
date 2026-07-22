---
layout: default
title: Font.FromFamily
description: Loads font from a specified list of font family names
---
# [Font]({{site.url}}/preview/Pages/StereoKit/Font.html).FromFamily

<div class='signature' markdown='1'>
```csharp
static Font FromFamily(string fontFamily)
```
Loads font from a specified list of font family names
</div>

|  |  |
|--|--|
|string fontFamily|List of font family names separated by comma(,) similar to a list of names css allows.|
|RETURNS: [Font]({{site.url}}/preview/Pages/StereoKit/Font.html)|A font from the given font family names. If none of them match a usable font, this falls back to StereoKit's builtin font, so this will always be a valid asset.|




