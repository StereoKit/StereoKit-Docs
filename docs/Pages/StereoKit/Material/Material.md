---
layout: default
title: Material.Material
description: Creates a material from a shader, and uses the shader's default settings. If the shader is null, a warning will be added to the log, and this Material will default to using an Unlit shader. Uses an auto-generated id.
---
# [Material]({{site.url}}/Pages/StereoKit/Material.html).Material

<div class='signature' markdown='1'>
```csharp
void Material(Shader shader)
```
Creates a material from a shader, and uses the shader's
default settings. If the shader is null, a warning will be added to
the log, and this Material will default to using an Unlit shader.
Uses an auto-generated id.
</div>

|  |  |
|--|--|
|[Shader]({{site.url}}/Pages/StereoKit/Shader.html) shader|Any valid shader, null is okay, but will log a             warning and default to Unlit.|

<div class='signature' markdown='1'>
```csharp
void Material(string shaderFilename)
```
Loads a Shader asset and creates a Material using it. If
the shader fails to load, a warning will be added to the log, and
this Material will default to using an Unlit shader. Uses an
auto-generated id.
</div>

|  |  |
|--|--|
|string shaderFilename|The filename of a Shader asset. If the             file is not present, the Shader will default to Unlit.|

<div class='signature' markdown='1'>
```csharp
void Material(string id, string shaderFilename)
```
Loads a Shader asset and creates a Material using it. If
the shader fails to load, a warning will be added to the log, and
this Material will default to using an Unlit shader. Uses an
auto-generated id.
</div>

|  |  |
|--|--|
|string id|Set the material's id to this.|
|string shaderFilename|The filename of a Shader asset. If the             file is not present, the Shader will default to Unlit.|

<div class='signature' markdown='1'>
```csharp
void Material(string id, Shader shader)
```
Creates a material from a shader, and uses the shader's
default settings. If the shader is null, a warning will be added to
the log, and this Material will default to using an Unlit shader.
</div>

|  |  |
|--|--|
|string id|Set the material's id to this.|
|[Shader]({{site.url}}/Pages/StereoKit/Shader.html) shader|Any valid shader, null is okay, but will log a             warning and default to Unlit.|




