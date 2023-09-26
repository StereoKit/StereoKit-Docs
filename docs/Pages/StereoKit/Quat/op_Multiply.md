---
layout: default
title: Quat.*
description: This is the combination of rotations a and b. Note that order matters here.
---
# [Quat]({{site.url}}/Pages/StereoKit/Quat.html).*

<div class='signature' markdown='1'>
```csharp
static Quat *(Quat a, Quat b)
```
This is the combination of rotations `a` and `b`. Note
that order matters here.
</div>

|  |  |
|--|--|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) a|First Quat.|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) b|Second Quat.|
|RETURNS: [Quat]({{site.url}}/Pages/StereoKit/Quat.html)|A multiplication of the two Quats.|

<div class='signature' markdown='1'>
```csharp
static Vec3 *(Quat a, Vec3 pt)
```
This rotates a point around the origin by the Quat.
</div>

|  |  |
|--|--|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) a|The rotation Quat.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) pt|The point that gets rotated around the origin.|
|RETURNS: [Vec3]({{site.url}}/Pages/StereoKit/Vec3.html)|A rotated point.|

<div class='signature' markdown='1'>
```csharp
static Vec3 *(Vec3 pt, Quat a)
```
This rotates a point around the origin by the Quat.
</div>

|  |  |
|--|--|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) a|The rotation Quat.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) pt|The point that gets rotated around the origin.|
|RETURNS: [Vec3]({{site.url}}/Pages/StereoKit/Vec3.html)|A rotated point.|




