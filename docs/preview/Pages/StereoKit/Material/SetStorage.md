---
layout: default
title: Material.SetStorage
description: Sets a RW/StructuredBuffer or ByteAddressBuffer on the shader. This is used to provide BIG arrays of data to the GPU, for both reading and writing! These perform very similarly to textures, and can be thought of as big textures of just data!
---
# [Material]({{site.url}}/preview/Pages/StereoKit/Material.html).SetStorage

<div class='signature' markdown='1'>
```csharp
bool SetStorage(string name, ComputeBuffer`1 buffer)
```
Sets a RW/StructuredBuffer or ByteAddressBuffer on the
shader. This is used to provide BIG arrays of data to the
GPU, for both reading and writing! These perform very similarly
to textures, and can be thought of as big textures of just data!
</div>

|  |  |
|--|--|
|string name|Name of the shader parameter in the HLSL.|
|[ComputeBuffer`1]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer.html) buffer|The buffer to assign, or null to clear.|
|RETURNS: bool|True if a matching resource was found in the shader.|




