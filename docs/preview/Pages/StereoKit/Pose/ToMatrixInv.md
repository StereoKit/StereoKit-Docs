---
layout: default
title: Pose.ToMatrixInv
description: Converts this pose into the inverse of the Pose's transform matrix. This can be used to transform points from the space represented by the Pose into world space.
---
# [Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html).ToMatrixInv

<div class='signature' markdown='1'>
```csharp
Matrix ToMatrixInv(Vec3 scale)
```
Converts this pose into the inverse of the Pose's
transform matrix. This can be used to transform points from the
space represented by the Pose into world space.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) scale|A scale vector! Vec3.One would be an identity scale.|
|RETURNS: [Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html)|A Matrix that transforms from the given pose.|

<div class='signature' markdown='1'>
```csharp
Matrix ToMatrixInv(float scale)
```
Converts this pose into the inverse of the Pose's
transform matrix. This can be used to transform points from the
space represented by the Pose into world space.
</div>

|  |  |
|--|--|
|float scale|A scale vector! Vec3.One would be an identity scale.|
|RETURNS: [Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html)|A Matrix that transforms from the given pose.|

<div class='signature' markdown='1'>
```csharp
Matrix ToMatrixInv()
```
Converts this pose into the inverse of the Pose's
transform matrix. This can be used to transform points from the
space represented by the Pose into world space.
</div>

|  |  |
|--|--|
|RETURNS: [Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html)|A Matrix that transforms from the given pose.|




