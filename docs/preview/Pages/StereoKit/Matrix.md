---
layout: default
title: Matrix
description: A Matrix in StereoKit is a 4x4 grid of numbers that is used to represent a transformation for any sort of position or vector! This is an oversimplification of what a matrix actually is, but it's accurate in this case.  Matrices are really useful for transforms because you can chain together all sorts of transforms into a single Matrix! A Matrix transform really shines when applied to many positions, as the more expensive operations get cached within the matrix values.  Multiple matrix transforms can be combined by multiplying them. In StereoKit, to create a matrix that first scales an object, followed by rotating it, and finally translating it you would use this order.  Matrix M = Matrix.S(...) * Matrix.R(...) * Matrix.T(...);  This order is related to the fact that StereoKit uses row-major order to store matrices. Note that in other 3D frameworks and certain 3D math references you may find column-major matrices, which would need the reverse order (i.e. T*R*S), so please keep this in mind when creating transformations.  Matrices are prominently used within shaders for mesh transforms!
---
# struct Matrix

A Matrix in StereoKit is a 4x4 grid of numbers that is used
to represent a transformation for any sort of position or vector!
This is an oversimplification of what a matrix actually is, but it's
accurate in this case.

Matrices are really useful for transforms because you can chain
together all sorts of transforms into a single Matrix! A Matrix
transform really shines when applied to many positions, as the more
expensive operations get cached within the matrix values.

Multiple matrix transforms can be combined by multiplying them. In
StereoKit, to create a matrix that first scales an object, followed by
rotating it, and finally translating it you would use this order:

`Matrix M = Matrix.S(...) * Matrix.R(...) * Matrix.T(...);`

This order is related to the fact that StereoKit uses row-major order
to store matrices. Note that in other 3D frameworks and certain 3D math
references you may find column-major matrices, which would need the
reverse order (i.e. T*R*S), so please keep this in mind when creating
transformations.

Matrices are prominently used within shaders for mesh transforms!

## Instance Fields and Properties

|  |  |
|--|--|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) [Inverse]({{site.url}}/preview/Pages/StereoKit/Matrix/Inverse.html)|Creates an inverse matrix! If the matrix takes a point from a -> b, then its inverse takes the point from b -> a.|
|Matrix4x4 [m]({{site.url}}/preview/Pages/StereoKit/Matrix/m.html)|The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [Pose]({{site.url}}/preview/Pages/StereoKit/Matrix/Pose.html)|Extracts translation and rotation information from the transform matrix, and makes a Pose from it! Not exactly fast. This is backed by Decompose, so if you need any additional info, it's better to just call Decompose instead.|
|[Quat]({{site.url}}/preview/Pages/StereoKit/Quat.html) [Rotation]({{site.url}}/preview/Pages/StereoKit/Matrix/Rotation.html)|A slow function that returns the rotation quaternion embedded in this transform matrix. This is backed by Decompose, so if you need any additional info, it's better to just call Decompose instead.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [Scale]({{site.url}}/preview/Pages/StereoKit/Matrix/Scale.html)|Returns the scale embedded in this transform matrix. Not exactly cheap, requires 3 sqrt calls, but is cheaper than calling Decompose.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [Translation]({{site.url}}/preview/Pages/StereoKit/Matrix/Translation.html)|A fast Property that will return or set the translation component embedded in this transform matrix.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) [Transposed]({{site.url}}/preview/Pages/StereoKit/Matrix/Transposed.html)|Creates a matrix that has been transposed! Transposing is like rotating the matrix 90 clockwise, or turning the rows into columns. This can be useful for inverting orthogonal matrices, or converting matrices for use in a math library that uses different conventions!|

## Instance Methods

|  |  |
|--|--|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix/Matrix.html)|This constructor is for manually creating a matrix from a grid of floats! You'll likely want to use one of the static Matrix functions to create a Matrix instead.|
|[Decompose]({{site.url}}/preview/Pages/StereoKit/Matrix/Decompose.html)|Returns this transformation matrix to its original translation, rotation and scale components. Not exactly a cheap function. If this is not a transform matrix, there's a chance this call will fail, and return false.|
|[Invert]({{site.url}}/preview/Pages/StereoKit/Matrix/Invert.html)|Inverts this Matrix! If the matrix takes a point from a -> b, then its inverse takes the point from b -> a.|
|[Transform]({{site.url}}/preview/Pages/StereoKit/Matrix/Transform.html)|Transforms a point through the Matrix! This is basically just multiplying a vector (x,y,z,1) with the Matrix.|
|[TransformNormal]({{site.url}}/preview/Pages/StereoKit/Matrix/TransformNormal.html)|Transforms a point through the Matrix, but excluding translation! This is great for transforming vectors that are -directions- rather than points in space. Use this to transform normals and directions. The same as multiplying (x,y,z,0) with the Matrix.|
|[Transpose]({{site.url}}/preview/Pages/StereoKit/Matrix/Transpose.html)|Transposes this Matrix! Transposing is like rotating the matrix 90 clockwise, or turning the rows into columns. This can be useful for inverting orthogonal matrices, or converting matrices for use in a math library that uses different conventions!|

## Static Fields and Properties

|  |  |
|--|--|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) [Identity]({{site.url}}/preview/Pages/StereoKit/Matrix/Identity.html)|An identity Matrix is the matrix equivalent of '1'! Transforming anything by this will leave it at the exact same place.|

## Static Methods

|  |  |
|--|--|
|[LookAt]({{site.url}}/preview/Pages/StereoKit/Matrix/LookAt.html)|A transformation that describes one position looking at another point. This is particularly useful for describing camera transforms!|
|[Orthographic]({{site.url}}/preview/Pages/StereoKit/Matrix/Orthographic.html)|This creates a matrix used for projecting 3D geometry onto a 2D surface for rasterization. Orthographic projection matrices will preserve parallel lines. This is great for 2D scenes or content.|
|[Perspective]({{site.url}}/preview/Pages/StereoKit/Matrix/Perspective.html)|This creates a matrix used for projecting 3D geometry onto a 2D surface for rasterization. Perspective projection matrices will cause parallel lines to converge at the horizon. This is great for normal looking content.|
|[R]({{site.url}}/preview/Pages/StereoKit/Matrix/R.html)|Create a rotation matrix from a Quaternion.|
|[S]({{site.url}}/preview/Pages/StereoKit/Matrix/S.html)|Creates a scaling Matrix, where scale can be different on each axis (non-uniform).|
|[T]({{site.url}}/preview/Pages/StereoKit/Matrix/T.html)|Translate. Creates a translation Matrix!|
|[TR]({{site.url}}/preview/Pages/StereoKit/Matrix/TR.html)|Translate, Rotate. Creates a transform Matrix using these components!|
|[TRS]({{site.url}}/preview/Pages/StereoKit/Matrix/TRS.html)|Translate, Rotate, Scale. Creates a transform Matrix using all these components!|
|[TS]({{site.url}}/preview/Pages/StereoKit/Matrix/TS.html)|Translate, Scale. Creates a transform Matrix using both these components!|

## Operators

|  |  |
|--|--|
|[Implicit Conversions]({{site.url}}/preview/Pages/StereoKit/Matrix/op_Implicit.html)|Allows implicit conversion from System.Numerics.Matrix4x4 to StereoKit.Matrix.|
|[*]({{site.url}}/preview/Pages/StereoKit/Matrix/op_Multiply.html)|Multiplies two matrices together! This is a great way to combine transform operations. Note that StereoKit's matrices are row-major, and multiplication order is important! To translate, then scale, multiply in order of 'translate * scale'.|
