---
layout: default
title: Color.Implicit Conversions
description: This allows for implicit conversion to Color32. This does _not_ convert from linear to gamma corrected, or clamp to 0-1 first.
---
# [Color]({{site.url}}/Pages/StereoKit/Color.html).Implicit Conversions

<div class='signature' markdown='1'>
```csharp
static Color32 Implicit Conversions(Color c)
```
This allows for implicit conversion to Color32. This does
_not_ convert from linear to gamma corrected, or clamp to 0-1
first.
</div>

|  |  |
|--|--|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) c|A 128 bit color to crush down.|
|RETURNS: [Color32]({{site.url}}/Pages/StereoKit/Color32.html)|A crushed down color.|




