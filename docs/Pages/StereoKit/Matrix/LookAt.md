---
layout: default
title: Matrix.LookAt
description: A transformation that describes one position looking at another point. This is particularly useful for describing camera transforms!
---
# [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html).LookAt

<div class='signature' markdown='1'>
```csharp
static Matrix LookAt(Vec3 from, Vec3 at)
```
A transformation that describes one position looking at
another point. This is particularly useful for describing camera
transforms!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) from|The location the transform is looking from, or             the position of the 'camera'.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) at|The location the transform is looking towards, or             the subject of the 'camera'.|
|RETURNS: [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html)|A common camera-like transform matrix.|

<div class='signature' markdown='1'>
```csharp
static Matrix LookAt(Vec3 from, Vec3 at, Vec3 up)
```
A transformation that describes one position looking at
another point. This is particularly useful for describing camera
transforms!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) from|The location the transform is looking from, or             the position of the 'camera'.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) at|The location the transform is looking towards, or             the subject of the 'camera'.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) up|This controlls the roll value of the lookat             transform, this would be the direction the top of the camera is             facing. In most cases, this is just Vec3.Up.|
|RETURNS: [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html)|A common camera-like transform matrix.|




