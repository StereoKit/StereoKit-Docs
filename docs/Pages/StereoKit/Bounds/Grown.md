---
layout: default
title: Bounds.Grown
description: Grow the Bounds to encapsulate the provided point. Returns the result, and does NOT modify the current bounds.
---
# [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html).Grown

<div class='signature' markdown='1'>
```csharp
Bounds Grown(Vec3 pt)
```
Grow the Bounds to encapsulate the provided point. Returns
the result, and does NOT modify the current bounds.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) pt|The point to encapsulate! This should be in the             same space as the bounds.|
|RETURNS: [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html)|The bounds that also encapsulate the provided point.|

<div class='signature' markdown='1'>
```csharp
Bounds Grown(Bounds box, Matrix boxTransform)
```
Grow the Bounds to encapsulate the provided box after it
has been transformed by the provided matrix transform. This will
transform each corner of the box, and expand the bounds to
encapsulate each point!
</div>

|  |  |
|--|--|
|[Bounds]({{site.url}}/Pages/StereoKit/Bounds.html) box|The box to encapsulate! The corners of this box             are transformed, and then used to grow the Bounds.|
|[Matrix]({{site.url}}/Pages/StereoKit/Matrix.html) boxTransform|The Matrix transform for the box. If             this is just an Identity matrix, you can skip providing a Matrix.|
|RETURNS: [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html)|The bounds that also encapsulate the provided transformed box.|

<div class='signature' markdown='1'>
```csharp
Bounds Grown(Bounds box)
```
Grow the Bounds to encapsulate the provided box.
</div>

|  |  |
|--|--|
|[Bounds]({{site.url}}/Pages/StereoKit/Bounds.html) box|The box to encapsulate!|
|RETURNS: [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html)|The bounds that also encapsulate the provided box.|




