---
layout: default
title: Color.Lerp
description: This will linearly blend between two different colors! Best done on linear colors, rather than gamma corrected colors, but will work either way. This will not clamp the percentage to the 0-1 range.
---
# [Color]({{site.url}}/Pages/StereoKit/Color.html).Lerp

<div class='signature' markdown='1'>
```csharp
static Color Lerp(Color a, Color b, float t)
```
This will linearly blend between two different colors!
Best done on linear colors, rather than gamma corrected colors, but
will work either way. This will not clamp the percentage to the 0-1
range.
</div>

|  |  |
|--|--|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) a|The first color, this will be the result if `t` is             0.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) b|The second color, this will be the result if `t` is             1.|
|float t|A percentage representing the blend between `a` and             `b`. This is _not_ clamped to the 0-1 range, and will result in             extrapolation outside this range.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|A blended color.|




