---
layout: default
title: Model.GetMesh
description: [Obsolete] For removal in v0.4. Use Nodes/Visuals.Mesh instead. Gets a link to the Mesh asset used by the model subset! Note that this is not necessarily a unique mesh, and could be shared in a number of other places. Consider copying and replacing it if you intend to modify it!
---
# [Model]({{site.url}}/Pages/StereoKit/Model.html).GetMesh

<div class='signature' markdown='1'>
```csharp
Mesh GetMesh(int subsetIndex)
```
[Obsolete] For removal in v0.4. Use Nodes/Visuals.Mesh
instead. Gets a link to the Mesh asset used by the model subset!
Note that this is not necessarily a unique mesh, and could be
shared in a number of other places. Consider copying and
replacing it if you intend to modify it!
</div>

|  |  |
|--|--|
|int subsetIndex|Index of the model subset to get the             Mesh for, should be less than SubsetCount.|
|RETURNS: [Mesh]({{site.url}}/Pages/StereoKit/Mesh.html)|A link to the Mesh asset used by the model subset at subsetIndex|




