---
layout: default
title: Mesh.Mesh
description: Creates an empty Mesh asset. Use SetVerts and SetInds to add data to it!
---
# [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html).Mesh

<div class='signature' markdown='1'>
```csharp
void Mesh()
```
Creates an empty Mesh asset. Use SetVerts and SetInds to
add data to it!
</div>

<div class='signature' markdown='1'>
```csharp
void Mesh(Vertex[] vertices, UInt32[] indices, MeshData flags, int priority)
```
Creates a Mesh asset and sets its vertex and index
data with control over upload behavior. This is a shorthand
for creating a Mesh and calling SetData on it.
</div>

|  |  |
|--|--|
|Vertex[] vertices|An array of vertices for the mesh. Null is okay here, but may require a special shader.|
|UInt32[] indices|A list of face indices, must be a multiple of 3.|
|[MeshData]({{site.url}}/preview/Pages/StereoKit/MeshData.html) flags|Flags controlling upload behavior. See MeshData for options.|
|int priority|Loading priority for async upload. Lower values load sooner.|




