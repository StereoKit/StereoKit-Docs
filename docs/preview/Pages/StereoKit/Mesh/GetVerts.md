---
layout: default
title: Mesh.GetVerts
description: This marshalls the vertex data of a custom format Mesh into an array of T. T's [VertComponent] derived format must exactly match the format the Mesh was created with, and KeepData must be true for vertex data to be available.  Due to the way marshalling works, this is _not_ a cheap function!
---
# [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html).GetVerts

<div class='signature' markdown='1'>
```csharp
Vertex[] GetVerts()
```
This marshalls the vertex data of a custom format Mesh
into an array of T. T's [VertComponent] derived format must exactly
match the format the Mesh was created with, and KeepData must be
true for vertex data to be available.

Due to the way marshalling works, this is _not_ a cheap function!
</div>

|  |  |
|--|--|
|RETURNS: Vertex[]|An array of vertices representing the Mesh, or null if KeepData is false.|




