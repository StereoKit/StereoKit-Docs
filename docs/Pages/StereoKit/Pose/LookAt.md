---
layout: default
title: Pose.LookAt
description: Creates a Pose that looks from one location in the direction of another location. This leaves "Up" as the +Y axis.
---
# [Pose]({{site.url}}/Pages/StereoKit/Pose.html).LookAt

<div class='signature' markdown='1'>
```csharp
static Pose LookAt(Vec3 from, Vec3 at)
```
Creates a Pose that looks from one location in the
direction of another location. This leaves "Up" as the +Y axis.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) from|Starting location.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) at|Lookat location.|
|RETURNS: [Pose]({{site.url}}/Pages/StereoKit/Pose.html)|A pose at position `from`, oriented to look towards `at`.|




