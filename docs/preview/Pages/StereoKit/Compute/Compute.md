---
layout: default
title: Compute.Compute
description: Create a Compute dispatch from a shader that has a compute stage! If the shader doesn't have a compute stage, this will fail.
---
# [Compute]({{site.url}}/preview/Pages/StereoKit/Compute.html).Compute

<div class='signature' markdown='1'>
```csharp
void Compute(Shader computeShader)
```
Create a Compute dispatch from a shader that has a
compute stage! If the shader doesn't have a compute stage,
this will fail.
</div>

|  |  |
|--|--|
|[Shader]({{site.url}}/preview/Pages/StereoKit/Shader.html) computeShader|A shader containing a compute stage.|

<div class='signature' markdown='1'>
```csharp
void Compute(string shaderFilename)
```
Create a Compute dispatch from a shader file! The
file should be a compiled .sks shader with a compute stage.
</div>

|  |  |
|--|--|
|string shaderFilename|The filename of a compiled shader asset containing a compute stage.|




