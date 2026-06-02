---
layout: default
title: Mesh.Copy
description: Creates an independent duplicate of this Mesh. Vertices, indices, bounds, and (if present) skin data are copied; the new Mesh has its own GPU buffers and shares no state with the source.  This is useful when one source mesh is shared across N animated entities. UpdateSkin mutates the target mesh's vertex buffer in place, so each entity needs its own Mesh instance to deform independently.  The source Mesh must have KeepData set to true.
---
# [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html).Copy

<div class='signature' markdown='1'>
```csharp
Mesh Copy()
```
Creates an independent duplicate of this Mesh.
Vertices, indices, bounds, and (if present) skin data are
copied; the new Mesh has its own GPU buffers and shares no
state with the source.

This is useful when one source mesh is shared across N
animated entities: UpdateSkin mutates the target mesh's
vertex buffer in place, so each entity needs its own Mesh
instance to deform independently.

The source Mesh must have KeepData set to true.
</div>

|  |  |
|--|--|
|RETURNS: [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html)|A new Mesh that shares no GPU state with this one.|




