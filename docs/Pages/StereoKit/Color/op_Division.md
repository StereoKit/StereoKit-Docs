---
layout: default
title: Color./
description: This will divide a color linearly, including alpha. Best done on a color in linear space. No clamping is applied.
---
# [Color]({{site.url}}/Pages/StereoKit/Color.html)./

<div class='signature' markdown='1'>
```csharp
static Color /(Color a, float b)
```
This will divide a color linearly, including alpha. Best
done on a color in linear space. No clamping is applied.
</div>

|  |  |
|--|--|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) a|The source color.|
|float b|The float to divide by.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|A divided color.|

<div class='signature' markdown='1'>
```csharp
static Color /(Color a, Color b)
```
This will divide a color component-wise against another
color, including alpha. Best done on colors in linear space. No
clamping is applied.
</div>

|  |  |
|--|--|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) a|The first color.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) b|The second color.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|A divided color.|




