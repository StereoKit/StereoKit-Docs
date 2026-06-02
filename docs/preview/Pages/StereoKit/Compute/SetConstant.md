---
layout: default
title: Compute.SetConstant
description: Sets a constant/uniform buffer (cbuffer) on the shader. This is for smaller chunks of data (16kb max) that can be read from faster than textures or StructuredBuffers.
---
# [Compute]({{site.url}}/preview/Pages/StereoKit/Compute.html).SetConstant

<div class='signature' markdown='1'>
```csharp
bool SetConstant(string name, MaterialBuffer`1 buffer)
```
Sets a constant/uniform buffer (cbuffer) on the shader.
This is for smaller chunks of data (16kb max) that can be read from
faster than textures or StructuredBuffers.
</div>

|  |  |
|--|--|
|string name|Name of the shader parameter in the HLSL.|
|[MaterialBuffer`1]({{site.url}}/preview/Pages/StereoKit/MaterialBuffer.html) buffer|The buffer to assign, or null to clear.|
|RETURNS: bool|True if a matching resource was found in the shader.|




