---
layout: default
title: Model.GetMaterial
description: [Obsolete] For removal in v0.4. Use Nodes/Visuals.Material instead. Gets a link to the Material asset used by the model subset! Note that this is not necessarily a unique material, and could be shared in a number of other places. Consider copying and replacing it if you intend to modify it!
---
# [Model]({{site.url}}/Pages/StereoKit/Model.html).GetMaterial

<div class='signature' markdown='1'>
```csharp
Material GetMaterial(int subsetIndex)
```
[Obsolete] For removal in v0.4. Use Nodes/Visuals.Material
instead. Gets a link to the Material asset used by the model
subset! Note that this is not necessarily a unique material, and
could be shared in a number of other places. Consider copying and
replacing it if you intend to modify it!
</div>

|  |  |
|--|--|
|int subsetIndex|Index of the model subset to get the             Material for, should be less than SubsetCount.|
|RETURNS: [Material]({{site.url}}/Pages/StereoKit/Material.html)|A link to the Material asset used by the model subset at subsetIndex|




