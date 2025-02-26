---
layout: default
title: Vec3.Vec3
description: Creates a vector from x, y, and z values! StereoKit uses a right-handed metric coordinate system, where +x is to the right, +y is upwards, and -z is forward.
---
# [Vec3]({{site.url}}/Pages/StereoKit/Vec3.html).Vec3

<div class='signature' markdown='1'>
```csharp
void Vec3(float x, float y, float z)
```
Creates a vector from x, y, and z values! StereoKit uses
a right-handed metric coordinate system, where +x is to the
right, +y is upwards, and -z is forward.
</div>

|  |  |
|--|--|
|float x|The x axis.|
|float y|The y axis.|
|float z|The z axis.|

<div class='signature' markdown='1'>
```csharp
void Vec3(Vector3 v)
```
Initialize from a System.Numerics vector, this can also be
done by an implicit or explicit cast/assignment.
</div>

|  |  |
|--|--|
|Vector3 v|A System.Numerics vector.|

<div class='signature' markdown='1'>
```csharp
void Vec3(float xyz)
```
Creates a vector with all values the same! StereoKit uses
a right-handed metric coordinate system, where +x is to the
right, +y is upwards, and -z is forward.
</div>

|  |  |
|--|--|
|float xyz|The x,y,and z axis.|




