---
layout: default
title: Pose.ToMatrix
description: Converts this pose into a transform matrix, incorporating a provided scale value.
---
# [Pose]({{site.url}}/Pages/StereoKit/Pose.html).ToMatrix

<div class='signature' markdown='1'>
```csharp
Matrix ToMatrix(Vec3 scale)
```
Converts this pose into a transform matrix, incorporating
a provided scale value.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) scale|A scale vector! Vec3.One would be an identity             scale.|
|RETURNS: [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html)|A Matrix that transforms to the given pose.|

<div class='signature' markdown='1'>
```csharp
Matrix ToMatrix(float scale)
```
Converts this pose into a transform matrix, incorporating
a provided scale value.
</div>

|  |  |
|--|--|
|float scale|A uniform scale factor! 1 would be an identity             scale.|
|RETURNS: [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html)|A Matrix that transforms to the given pose.|

<div class='signature' markdown='1'>
```csharp
Matrix ToMatrix()
```
Converts this pose into a transform matrix.
</div>

|  |  |
|--|--|
|RETURNS: [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html)|A Matrix that transforms to the given pose.|





## Examples

### Draw Pose

Having a raw and malleable position/orientation available is great,
but with `Pose.ToMatrix`, you can also quickly turn a `Pose` into a
`Matrix` for use with drawing functions or other places where
`Matrix` transforms are needed! `ToMatrix` also has overloads to
include a scale, if one is available.

![Drawing items at a Pose]({{site.screen_url}}/Docs/PoseDraw.jpg)

```csharp
Pose  pose  = new Pose(0,0,-0.5f, Quat.FromAngles(30,45,0));
float scale = 0.5f;

Mesh.Cube.Draw(Material.Default, pose.ToMatrix(scale));
```

