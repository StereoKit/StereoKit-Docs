---
layout: default
title: Bounds.*
description: This operator will create a new Bounds that has been properly scaled up by the float. This does affect the center position of the Bounds.
---
# [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html).*

<div class='signature' markdown='1'>
```csharp
static Bounds *(Bounds a, float b)
```
This operator will create a new Bounds that has been
properly scaled up by the float. This does affect the center
position of the Bounds.
</div>

|  |  |
|--|--|
|[Bounds]({{site.url}}/Pages/StereoKit/Bounds.html) a|The source Bounds.|
|float b|A scalar multiplier for the Bounds.|
|RETURNS: [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html)|A new Bounds that has been scaled.|

<div class='signature' markdown='1'>
```csharp
static Bounds *(Bounds a, Vec3 b)
```
This operator will create a new Bounds that has been
properly scaled up by the Vec3. This does affect the center
position of the Bounds.
</div>

|  |  |
|--|--|
|[Bounds]({{site.url}}/Pages/StereoKit/Bounds.html) a|The source Bounds.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) b|A Vec3 multiplier for the Bounds.|
|RETURNS: [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html)|A new Bounds that has been scaled.|




