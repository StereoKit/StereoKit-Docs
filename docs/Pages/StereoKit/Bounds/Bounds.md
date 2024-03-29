---
layout: default
title: Bounds.Bounds
description: Creates a bounding box object!
---
# [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html).Bounds

<div class='signature' markdown='1'>
```csharp
void Bounds(Vec3 center, Vec3 totalDimensions)
```
Creates a bounding box object!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) center|The exact center of the box.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) totalDimensions|The total size of the box, from one             end to the other. This is the width, height, and depth of the             Bounds.|

<div class='signature' markdown='1'>
```csharp
void Bounds(Vec3 totalDimensions)
```
Creates a bounding box object centered around zero!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) totalDimensions|The total size of the box, from one             end to the other. This is the width, height, and depth of the             Bounds.|

<div class='signature' markdown='1'>
```csharp
void Bounds(float totalDimensionX, float totalDimensionY, float totalDimensionZ)
```
Creates a bounding box object centered around zero!
</div>

|  |  |
|--|--|
|float totalDimensionX|Total size on the X axis.|
|float totalDimensionY|Total size on the Y axis.|
|float totalDimensionZ|Total size on the Z axis.|




