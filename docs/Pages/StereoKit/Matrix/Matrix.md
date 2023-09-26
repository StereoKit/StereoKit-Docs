---
layout: default
title: Matrix.Matrix
description: This constructor is for manually creating a matrix from a grid of floats! You'll likely want to use one of the static Matrix functions to create a Matrix instead.
---
# [Matrix]({{site.url}}/Pages/StereoKit/Matrix.html).Matrix

<div class='signature' markdown='1'>
```csharp
void Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
```
This constructor is for manually creating a matrix from a
grid of floats! You'll likely want to use one of the static Matrix
functions to create a Matrix instead.
</div>

|  |  |
|--|--|
|float m11|m11|
|float m12|m12|
|float m13|m13|
|float m14|m14|
|float m21|m21|
|float m22|m22|
|float m23|m23|
|float m24|m24|
|float m31|m31|
|float m32|m32|
|float m33|m33|
|float m34|m34|
|float m41|m41|
|float m42|m42|
|float m43|m43|
|float m44|m44|

<div class='signature' markdown='1'>
```csharp
void Matrix(Matrix4x4 matrix)
```
Create a Matrix from the equivalent System.Numerics Matrix
type. You can also implicitly convert between these types, as this
Matrix is backed by the System.Numerics type anyhow.
</div>

|  |  |
|--|--|
|Matrix4x4 matrix|A System.Numerics matrix.|




